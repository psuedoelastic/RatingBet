using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

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
            // ListView NewsItemList = new ListView();


            for (int i =1;i < 12; i++)
            {
                newitem.Add(new NewsItem { ID=i ,content = "Text number"+i });
            }
            NewsItemList.ItemsSource = newitem;
            

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
    }

}
