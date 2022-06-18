using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ClimaWeather.Controls {
    public class InfiniteScrollListViewControl : ListView {
        public InfiniteScrollListViewControl() {
            this.ItemAppearing += InfiniteScrollListView_ItemAppearing;
        }

        private void InfiniteScrollListView_ItemAppearing(object sender, ItemVisibilityEventArgs e) {
            var items = this.ItemsSource as IList;
            if (items != null && items.Count > 0 && e.Item == items[items.Count - 1]) {
                if(this.CarregarMaisCommand != null && this.CarregarMaisCommand.CanExecute(null))
                    CarregarMaisCommand.Execute(null);
            }
        }

        public static readonly BindableProperty CarregarMaisCommandProperty = BindableProperty.Create(
            propertyName: "CarregarMaisCommand",
            returnType: typeof(ICommand),
            declaringType: typeof(InfiniteScrollListViewControl),
            defaultBindingMode: BindingMode.OneWay
        );



        public ICommand CarregarMaisCommand {
            get { return (ICommand)GetValue(CarregarMaisCommandProperty); }
            set { SetValue(CarregarMaisCommandProperty, value); }
        }
    }
}
