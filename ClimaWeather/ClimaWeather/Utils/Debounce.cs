using System;
using System.Threading;
using System.Threading.Tasks;

namespace ClimaWeather.Utils {

    public class Debounce {
        private Task _debounceTask;
        private CancellationTokenSource _tokenSource;

        public void Execute(Action func, int milliseconds = 300) {
            if (_debounceTask != null) {
                _tokenSource.Cancel();
                _debounceTask = null;
            }

            _tokenSource = new CancellationTokenSource();

            _debounceTask = Task.Delay(milliseconds).ContinueWith((task) => {
                func();
                _debounceTask = null;
            }, _tokenSource.Token);
        }
    }
}