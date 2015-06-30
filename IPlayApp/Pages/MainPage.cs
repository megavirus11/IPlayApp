using System;
using System.Diagnostics;
using System.Threading.Tasks;
using IPlayApp.Class;
using IPlayApp.Models;
using IPlayApp.Webservices;
using Xamarin.Forms;

namespace IPlayApp.Pages
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            var listView = new ListView();
            //Create buttons

            var btnMenuPage = new Button
            {
                Text = "Go To MenuPage",
                BackgroundColor = Color.Red,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            var btnSettingsMenu = new Button
            {
                Text = "Go To Settings",
                BackgroundColor = Color.Gray,
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            //Events
            var ai = new ActivityIndicator { IsRunning = true, IsEnabled = true, BindingContext = this };
            ai.SetBinding(IsVisibleProperty, "IsBusy");

            btnMenuPage.Clicked += async (sender, e) =>
            {
                try
                {
                    IsBusy = true;
                    var serviceBusInit = await ServiceBusApi.Fetch();

                    await Navigation.PushModalAsync(new NavigationPage(new MenuPage(serviceBusInit.MenuItems)));
                }
                catch (Exception)
                {
                    DisplayAlert("Fout", "Geen reactie van de server ontvangen. Controleer instellingen", "OK");
                }
                finally
                {
                    IsBusy = false;  
                }

            };

            btnSettingsMenu.Clicked += (sender, e) => Navigation.PushModalAsync(new SettingsPage());

            Content = new StackLayout
            {
                Padding = 20,
                Children = { listView, ai, btnMenuPage, btnSettingsMenu }
            };
        }
    }
}