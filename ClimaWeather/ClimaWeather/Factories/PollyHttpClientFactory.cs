using Flurl.Http.Configuration;
using Polly;
using Polly.Retry;
using Polly.Timeout;
using Polly.Wrap;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ClimaWeather.Factories {
    public class PollyHttpClientFactory : DefaultHttpClientFactory {
        public override HttpMessageHandler CreateMessageHandler() {
            return new PolicyHandler {
                InnerHandler = base.CreateMessageHandler()
            };
        }
    }
    public class PolicyHandler : DelegatingHandler {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            return Policies.PolicyStrategy.ExecuteAsync(ct => base.SendAsync(request, ct), cancellationToken);
        }
    }

    public static class Policies {
        private static AsyncTimeoutPolicy<HttpResponseMessage> TimeoutPolicy {
            get {
                return Policy.TimeoutAsync<HttpResponseMessage>(600, (context, timeSpan, task) => {
                    Debug.WriteLine($"[App|Policy]: Timeout delegate fired after {timeSpan.Seconds} seconds");
                    return Task.CompletedTask;
                });
            }
        }

        private static AsyncRetryPolicy<HttpResponseMessage> RetryPolicy {
            get {
                var statusParaRetentar = new[] { HttpStatusCode.BadGateway, HttpStatusCode.GatewayTimeout, HttpStatusCode.RequestTimeout };

                return Policy
                    .HandleResult<HttpResponseMessage>(r => statusParaRetentar.Contains(r.StatusCode))
                    .Or<TimeoutRejectedException>()
                    .WaitAndRetryAsync(new[]
                        {
                        TimeSpan.FromSeconds(1),
                        TimeSpan.FromSeconds(2),
                        TimeSpan.FromSeconds(5)
                        },
                        (delegateResult, retryCount) => {
                            Debug.WriteLine($"[App|Policy]: Retry delegate fired, attempt {retryCount}");
                        });
            }
        }

        public static AsyncPolicyWrap<HttpResponseMessage> PolicyStrategy => Policy.WrapAsync(RetryPolicy, TimeoutPolicy);
    }
}
