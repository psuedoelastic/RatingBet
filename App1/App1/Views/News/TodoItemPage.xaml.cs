using System;
using System.Collections.Generic;
using Xamarin.Forms;

using System.Threading.Tasks;

using App1.Model;
namespace App1.Views.News
{
    public partial class TodoItemPage : ContentPage
    {
        //private string name = string.empty;
        public TodoItemPage()
        {
            InitializeComponent();

        }
        protected async override void OnAppearing()
        {
            var Items = (NewsItem)BindingContext;
            var htmlSource = new HtmlWebViewSource();
            //var res = await App.NewManager.GetItem(Items);
            htmlSource.Html = Items.html;

            Browser.Source = htmlSource;
        }
    }
}
