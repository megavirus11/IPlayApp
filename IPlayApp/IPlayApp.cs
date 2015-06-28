using IPlayApp.Pages;
using Xamarin.Forms;

namespace IPlayApp
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = new MainPage
            {
                Title = "Main page"
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            // Load server app string
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}