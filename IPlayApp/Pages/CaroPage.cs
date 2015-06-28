using IPlayApp.Class;
using Xamarin.Forms;

namespace IPlayApp.Pages
{
    internal class CaroPage : CarouselPage
    {
        public CaroPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
        }
        protected override bool OnBackButtonPressed()
        {
            CommunicationManager.GetInstance().DeleteData();
            return base.OnBackButtonPressed();
        }
    }
}