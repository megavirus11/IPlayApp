using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using IPlayApp.Class;
using IPlayApp.Models;
using Xamarin.Forms;

namespace IPlayApp.Pages
{
    public class MenuPage : ContentPage
    {
        private const int Num = 2;
        private AbsoluteLayout _absoluteLayout;
        private StackLayout _stackLayout;
        private Stopwatch stopwatch = new Stopwatch();
        public MenuPage(IEnumerable<Menu> menuItems)
        {   

            NavigationPage.SetHasNavigationBar(this, false);
            _absoluteLayout = new AbsoluteLayout();
            foreach (var menuItem in menuItems)
            {
                var item = menuItem;
                var menuItemButton = new Button
                {
                    Text = item.Name,
                    BackgroundColor = Color.FromHex(item.Color)
                };
                if (item.ChildItems.Count != 0)
                {
                    menuItemButton.Clicked +=
                        (sender, args) =>
                        {
                            CommunicationManager.GetInstance().AddData(item.Event);
                            Navigation.PushAsync(new MenuPage(item.ChildItems));
                        };
                }
                else if (item.PlayerList.Count != 0)
                {
                    menuItemButton.Clicked +=
                        (sender, args) =>
                        {
                            CommunicationManager.GetInstance().AddData(item.Event);
                            Navigation.PushAsync(CarouselMenu(item.PlayerList));
                        };
                }
                else
                {
                    menuItemButton.Clicked +=
                        (sender, args) =>
                        {
                            CommunicationManager.GetInstance().AddData(item.Event);
                            CommunicationManager.GetInstance().SendData();
                            Navigation.PopModalAsync();
                        };
                }

                _absoluteLayout.Children.Add(menuItemButton);
            }
            
            _stackLayout = new StackLayout
            {
                Children =
                {
                    new StackLayout(),
                    _absoluteLayout
                }
            };
            _stackLayout.SizeChanged += OnStackSizeChanged;
            // And set that to the content of the page.
            Padding =
                new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
            Content = _stackLayout;
        }

        private Page CarouselMenu(IReadOnlyCollection<Player> items)
        {
            var caroPage = new CaroPage();

            var count = 1;
            foreach (var item in items)
            {
                var button = new Button
                {
                    Text = "Selecteer",
                    HorizontalOptions = new LayoutOptions(LayoutAlignment.Center, true)
                };
                button.Clicked += (sender, args) =>
                {
                    CommunicationManager.GetInstance().AddData(item.Name);
                    CommunicationManager.GetInstance().SendData();
                    Navigation.PopModalAsync();
                };
                caroPage.Children.Add(new ContentPage
                {
                    Content = new StackLayout
                    {
                        Children =
                        {
                            new Label
                            {
                                Text = item.Name,
                                VerticalOptions = new LayoutOptions(LayoutAlignment.Center, true),
                                HorizontalOptions = new LayoutOptions(LayoutAlignment.Center, true)
                            },
                            new Label
                            {
                                Text = string.Format("{0}/{1}", count++, items.Count),
                                HorizontalOptions = new LayoutOptions(LayoutAlignment.Center, true)
                            },
                            button
                        }
                    }
                });
            }
            return caroPage;
        }

        private void OnStackSizeChanged(object sender, EventArgs args)
        {
            var width = _stackLayout.Width;
            var height = _stackLayout.Height;

            if (width <= 0 || height <= 0)
                return;

            // Orient StackLayout based on portrait/landscape mode.
            _stackLayout.Orientation = (width < height)
                ? StackOrientation.Vertical
                : StackOrientation.Horizontal;

            // Calculate square size and position based on stack size.
            double childrenCount = _absoluteLayout.Children.Count;
            var buttonWidth = _stackLayout.Orientation == StackOrientation.Horizontal
                ? width/Math.Ceiling(childrenCount/Num)
                : width/Num;
            var buttonHeight = _stackLayout.Orientation == StackOrientation.Horizontal
                ? height/Num
                : height/Math.Ceiling(childrenCount/Num);
            _absoluteLayout.WidthRequest = width;
            _absoluteLayout.HeightRequest = height;

            var col = 0;
            var row = 0;
            foreach (var button in _absoluteLayout.Children.Cast<Button>())
            {
                AbsoluteLayout.SetLayoutBounds(button,
                    new Rectangle(col*buttonWidth + 5,
                        row*buttonHeight + 5,
                        buttonWidth - 5,
                        buttonHeight - 5));
                if (_stackLayout.Orientation == StackOrientation.Horizontal)
                {
                    row++;
                    if (row != Num) continue;
                    row = 0;
                    col++;
                }
                else
                {
                    col++;
                    if (col != Num) continue;
                    col = 0;
                    row++;
                }
            }
        }

        private void CheckTimer()
        {
            if (stopwatch.IsRunning)
                stopwatch.Reset();
            else
                stopwatch.Start();
        }

        private bool TimerDone()
        {
            if (stopwatch.ElapsedMilliseconds > 1000)
            {
                Debug.WriteLine("1000 miliseconds");
                return true;
            }
            return false;
        }

        protected override bool OnBackButtonPressed()
        {
            CommunicationManager.GetInstance().DeleteData();
            return base.OnBackButtonPressed();
        }
    }
}