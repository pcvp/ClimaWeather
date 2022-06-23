using ClimaWeather.Helpers;
using CSharpFunctionalExtensions;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ClimaWeather.Services.ApiClient.Base {

    public abstract class BaseApiClient {
        private readonly string _baseAddress;

        public BaseApiClient(string baseAddress) {
            _baseAddress = baseAddress;
        }

        protected BaseApiClient(Uri baseAddress) {
            _baseAddress = baseAddress.ToString();
        }

        protected abstract string ResourceName { get; }

        protected Url ResourceUrl {
            get {
                return _baseAddress.AppendPathSegment(ResourceName);
            }
        }

        protected async Task<Maybe<T>> RequestGet<T>(object queryString = null, params string[] segmentosUrl) {
            try {
                if (!TemConexaoComAInternet()) {
                    ExibirAlertaDeSemConexaoComAInternet();
                    return Maybe<T>.None;
                }

                var url = GetURL(queryString, segmentosUrl);

                var flurlRequest = url.AllowHttpStatus(HttpStatusCode.NotFound, HttpStatusCode.BadRequest);

                T retorno = await flurlRequest.GetJsonAsync<T>();

                return retorno == null ? Maybe<T>.None : Maybe<T>.From(retorno);
            }
            catch (FlurlHttpException e) {
                TratarErroHttp(e);
                return Maybe<T>.None;
            }
            catch (Exception e) {
                await AlertHelper.DisplayAlert("Erro", e.Message, "Voltar para tentar novamente");
                return Maybe<T>.None;
            }
        }

        protected async Task<Maybe<bool>> RequestDelete(params string[] segmentosUrl) {
            try {
                if (!TemConexaoComAInternet()) {
                    ExibirAlertaDeSemConexaoComAInternet();
                    return Maybe<bool>.From(false);
                }

                var url = GetURL(null, segmentosUrl);

                var flurlRequest = url.AllowHttpStatus(HttpStatusCode.NotFound, HttpStatusCode.BadRequest);

                var retorno = await flurlRequest.DeleteAsync();

                return Maybe<bool>.From(true);
            }
            catch (FlurlHttpException e) {
                TratarErroHttp(e);
                return Maybe<bool>.From(false);
            }
            catch (Exception e) {
                await AlertHelper.DisplayAlert("Erro", e.Message, "Voltar para tentar novamente");
                return Maybe<bool>.From(false);
            }
        }

        protected async Task<Maybe<T>> RequestPost<T>(object parametros, params string[] segmentosUrl) {
            try {
                var url = ResourceUrl;

                foreach (var s in segmentosUrl) {
                    if (!string.IsNullOrWhiteSpace(s))
                        url = url.AppendPathSegment(s);
                }

                if (!TemConexaoComAInternet()) {
                    ExibirAlertaDeSemConexaoComAInternet();
                    return Maybe<T>.None;
                }

                var resultado = await url.PostJsonAsync(parametros);

                if (resultado == null)
                    return Maybe<T>.None;

                var retorno = await resultado.GetStringAsync();

                var objeto = JsonConvert.DeserializeObject<T>(retorno);

                Maybe<T> maybe = Maybe<T>.From(objeto);
                return maybe;
            }
            catch (FlurlHttpException e) {
                TratarErroHttp(e);
                return Maybe<T>.None;
            }
            catch (Exception e) {
                await AlertHelper.DisplayAlert("Erro", e.Message, "Voltar para tentar novamente");
                return Maybe<T>.None;
            }
        }

        private async Task ExibirAlertaDeSemConexaoComAInternet() {
            if (!AlertHelper.ExisteAlertaSendoExibido())
                await AlertHelper.DisplayAlert(null, "Verifique sua conexão com a internet e tente novamente.", "Voltar");
        }

        private Url GetURL(object queryString, string[] segmentosUrl) {
            var url = ResourceUrl;

            foreach (var s in segmentosUrl) {
                if (!string.IsNullOrWhiteSpace(s))
                    url = url.AppendPathSegment(s);
            }

            if (queryString != null)
                url = url.SetQueryParams(queryString);
            return url;
        }

        private bool TemConexaoComAInternet() {
            return Connectivity.NetworkAccess == NetworkAccess.Internet;
        }

        private void TratarErroHttp(FlurlHttpException e) {
            if (e?.Call?.Response?.StatusCode != null) {
                switch ((HttpStatusCode)e.Call.Response.StatusCode) {
                    case HttpStatusCode.Unauthorized:
                        AlertHelper.DisplayAlert("Erro", "Não foi possível se comunicar com o servidor");
                        break;
                    //case HttpStatusCode.BadRequest:
                    case HttpStatusCode.MethodNotAllowed:
                        e.Call.Response.GetStringAsync().ContinueWith(f => {
                            var json = f.Result;

                            var data = JObject.Parse(json);
                            var mensagem = data.Value<string>("message") ?? data.Value<string>("mensagemDeErro");
                            var titulo = data.Value<string>("titulo") ?? "Atenção";
                            var botaoOk = data.Value<string>("botaoOk") ?? "Ok";

                            AlertHelper.DisplayAlert(titulo, mensagem, botaoOk);
                        });
                        break;
                    //case HttpStatusCode.NotFound:
                    default:
                        Console.WriteLine("[APP] - HTTP Error - CODE: " + (HttpStatusCode)e.Call.Response.StatusCode);
                        Console.WriteLine("[APP] - HTTP Error Message: " + e.Message);
                        break;
                }
            }
            else {
                Console.WriteLine("HTTP Error");
            }
        }
    }
}