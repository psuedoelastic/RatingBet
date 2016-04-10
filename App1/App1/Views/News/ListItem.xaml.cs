using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
//using System.Threading.Tasks;
using Xamarin.Forms;
using App1.Model;

namespace App1.Views.News
{
	public partial class ListItem : ContentPage
	{
        ObservableCollection<NewsItem> newitem = new ObservableCollection<NewsItem>();
       

        public ListItem ()
		{
            InitializeComponent();
          

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            NewsItemList.ItemsSource = await App.NewManager.GetTaskAsync();
            NewsItemList.HasUnevenRows = true;
        }
        public void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }

            var item = ((NewsItem)((ListView)sender).SelectedItem);
            var newPage = new TodoItemPage();
            newPage.BindingContext = item;
            Navigation.PushAsync(newPage);
            //((ListView)sender).SelectedItem = null; //uncomment line if you want to disable the visual selection state.
        }
        public async void AsyncRefreshing(object sender, EventArgs e)
        {
            NewsItemList.ItemsSource = await App.NewManager.GetTaskAsync();
        }   
    }

}
