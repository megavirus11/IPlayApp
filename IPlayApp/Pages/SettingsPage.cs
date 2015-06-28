using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IPlayApp.Pages
{
    class SettingsPage : ContentPage
    {
        private Entry tbSegment;
        private Entry tbVariables;

        private Label labelSegment;
        private Label labelVariables;
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
            var tbUrl = new Entry
            {
                Text = urlText
            };
            labelSegment = new Label
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
            tbSegment = new Entry
            {
                Text = segmentText,
                IsVisible = false
            };
            labelVariables = new Label
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
            tbVariables = new Entry
            {
                Text = variablesText,
                IsVisible = false
            };
            tbUrl.TextChanged += OnTextChangedUrl;
            tbSegment.TextChanged += OnTextChangedSegment;
            tbVariables.TextChanged += OnTextChangedVariables;
            var stackLayout = new StackLayout
            {
                Children =
                {
                    labelUrl, tbUrl, labelSegment, tbSegment, labelVariables, tbVariables
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
                tbSegment.IsVisible = true;
                tbVariables.IsVisible = true;

                labelSegment.IsVisible = true;
                labelVariables.IsVisible = true;
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
