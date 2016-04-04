using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using App1.Data;

namespace App1
{
	public class App : Application
	{
        public static NewsManager NewManager { get; set; }
		public App ()
		{
            // The root page of your application
            /*
			MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							XAlign = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms!"
						}
					}
				}
			};
            */
            NewManager = new NewsManager(new NewsService());
            MainPage = new NavigationPage( new App1.Views.News.ListItem());

        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
