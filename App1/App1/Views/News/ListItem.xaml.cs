using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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

            NewsItemList.ItemsSource = newitem;
            NewsItemList.ItemAppearing += (sender, e) =>
            {
                if (newitem.Count == 0)
                {
                    return;
                }
                var It = (NewsItem)e.Item;
                if (It.id == newitem[newitem.Count - 1].id)
                {
                    LoadItem();
                }
            };
            NewsItemList.HasUnevenRows = true;
             LoadItem();
        }
        void OnClick(object sender, EventArgs e)
        {
            ToolbarItem tbi = (ToolbarItem)sender;
            this.DisplayAlert("Selected!", tbi.Name, "OK");
        }
        /*
        protected async override void OnAppearing()
        {
            base.OnAppearing();
           
            NewsItemList.ItemsSource = newitem;
            NewsItemList.ItemAppearing += (sender, e) =>
            {
                if ( newitem.Count == 0)
                {
                    return;
                }
                var It = (NewsItem)e.Item;
                if (It.id == newitem[newitem.Count - 1].id)
                {
                    newitem = await App.NewManager.GetTaskAsync();
                }
            };
            NewsItemList.HasUnevenRows = true;
            await LoadItem();
        }
        */
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
       
        private async Task LoadItem()
        {
            var item = await App.NewManager.GetTaskAsync();
            foreach (NewsItem i in item)
            {
                newitem.Add(i);
            }
        }
    }

}
