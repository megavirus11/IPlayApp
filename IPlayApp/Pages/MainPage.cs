using System.Threading.Tasks;
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
                IsBusy = true;
                var serviceBusInit = await ServiceBusApi.Fetch();
                await Navigation.PushModalAsync(new NavigationPage(new MenuPage(serviceBusInit.MenuItems)));
                IsBusy = false;
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