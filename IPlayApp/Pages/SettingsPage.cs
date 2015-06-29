using System;
using Xamarin.Forms;

namespace IPlayApp.Pages
{
    class SettingsPage : ContentPage
    {
        private readonly Entry _tbSegment;
        private readonly Entry _tbVariables;

        private readonly Label _labelSegment;
        private readonly Label _labelVariables;
        public SettingsPage()
        {
            var labelUrl = new Label
            {
                Text = "Url",
            };
            var urlText = "";
            if (Application.Current.Properties.ContainsKey("Url"))
            {
                urlText = Application.Current.Properties["Url"] as string;
            }
            else
            {
                Application.Current.Properties["Segment"] = "http://92.222.119.2:8188/";
                urlText = "http://92.222.119.2:8188/";
            }
            var tbUrl = new Entry
            {
                Text = urlText
            };
            _labelSegment = new Label
            {
                Text = "Segment",
                IsVisible = false
            };
            var segmentText = "";
            if (Application.Current.Properties.ContainsKey("Segment"))
            {
                segmentText = Application.Current.Properties["Segment"] as string;
            }
            else
            {
                Application.Current.Properties["Segment"] = "api/Menu?deviceid={0}&userid={1}";
                segmentText = "api/Menu?deviceid={0}&userid={1}";
            }
            _tbSegment = new Entry
            {
                Text = segmentText,
                IsVisible = false
            };
            _labelVariables = new Label
            {
                Text = "Variables",
                IsVisible = false
            };
            var variablesText = "";
            if (Application.Current.Properties.ContainsKey("Variables"))
            {
                variablesText = Application.Current.Properties["Variables"] as string;
            }
            else
            {
                Application.Current.Properties["Variables"] = "1,123";
                variablesText = "1,123";
            }
            _tbVariables = new Entry
            {
                Text = variablesText,
                IsVisible = false
            };
            tbUrl.TextChanged += OnTextChangedUrl;
            _tbSegment.TextChanged += OnTextChangedSegment;
            _tbVariables.TextChanged += OnTextChangedVariables;
            var stackLayout = new StackLayout
            {
                Children =
                {
                    labelUrl, tbUrl, _labelSegment, _tbSegment, _labelVariables, _tbVariables
                }
            };
            // And set that to the content of the page.
            Padding =
                new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
            Content = stackLayout;
        }

        private void OnTextChangedUrl(object sender, EventArgs args)
        {
            Application.Current.Properties["Url"] = ((Entry) sender).Text;
            Application.Current.SavePropertiesAsync();
            if (((Entry) sender).Text == "Admin Options Enable")
            {
                _tbSegment.IsVisible = true;
                _tbVariables.IsVisible = true;

                _labelSegment.IsVisible = true;
                _labelVariables.IsVisible = true;
            }
        }
        private void OnTextChangedSegment(object sender, EventArgs args)
        {
            Application.Current.Properties["Segment"] = ((Entry)sender).Text;
            Application.Current.SavePropertiesAsync();
        }
        private void OnTextChangedVariables(object sender, EventArgs args)
        {
            Application.Current.Properties["Variables"] = ((Entry)sender).Text;
            Application.Current.SavePropertiesAsync();
        }
    }
}
