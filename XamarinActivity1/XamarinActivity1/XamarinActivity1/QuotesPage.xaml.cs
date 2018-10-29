using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinActivity1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class QuotesPage : ContentPage
	{
        private int counter = 0;        // current index of quote in the list of quotes
        private int numOfQuotes;        // total number of quotes in the list
        private List<String> quoteList; // list of quotes

        public QuotesPage ()
		{
			InitializeComponent ();

            if (Device.RuntimePlatform == Device.iOS)
            {
                Padding = new Thickness(20, 40, 20, 20);
            }
            else
            {
                Padding = new Thickness(20, 20, 20, 20);
            }

            // set fontSizeSlider's properties, 8 - min value and 32 - max value
            this.SetFontSizeSliderProperties(fontSizeSlider, 8, 90);

            if (this.quoteList == null)
            {
                this.quoteList = this.LoadAllQuotes();
                this.numOfQuotes = this.quoteList.Count;
            }

            if(this.numOfQuotes <= 1)
            {
                nextButton.IsVisible = false;
                backButton.IsVisible = false;
            }
            else
            {
                backButton.IsVisible = false;
                this.AddNextButtonClickedEventHandler();
                this.AddBackButtonClickedEventHandler();
            }

            if(quoteList != null)
            {
                quoteLabel.Text = this.quoteList[this.counter];
            }
		}

        // Return list of quotes. 
        private List<String> LoadAllQuotes()
        {
            return new List<String>()
            {
                "If you stop striving for PERFECTION, \nYou might as well be DEAD.",
                "If you want to be seen, STAND UP!\nIf you want to be heard, SPEAK UP!\n And if you want to be appreciated, SHUT UP!",
                "The world is not a wish granting factory.",
                "Change your life today. Don't gamble on the future, act now, without delay.",
                "The greatest failure is the failure to try."
            };
        }

        // Add event handler for next button when clicked. This button moves the display quotes based on the array of quotes.
        private void AddNextButtonClickedEventHandler()
        {
            nextButton.Clicked += (sender, e) =>
            {
                this.counter = this.counter + 1;
                quoteLabel.Text = this.quoteList[this.counter];
                backButton.IsEnabled = true;
                backButton.IsVisible = true;

                if (this.counter == (this.numOfQuotes - 1))
                {
                    nextButton.IsEnabled = false;
                    nextButton.IsVisible = false;
                }

                scrollView.ScrollToAsync(0, 0, false);
            };
        }

        // Add event handler for next button when clicked. This button moves backward the display quotes based  on the array of quotes.
        private void AddBackButtonClickedEventHandler()
        {
            backButton.Clicked += (sender, e) =>
            {
                this.counter = this.counter - 1;
                quoteLabel.Text = this.quoteList[this.counter];
                nextButton.IsEnabled = true;
                nextButton.IsVisible = true;

                if(this.counter == 0)
                {
                    backButton.IsEnabled = false;
                    backButton.IsVisible = false;
                }
                scrollView.ScrollToAsync(0, 0, false);
            };
        }

         // Set properties of slider.   
        private void SetFontSizeSliderProperties(Slider slider, double min, double max)
        {
            slider.Minimum = 0;
            slider.Maximum = max;
            slider.Value = min;

            slider.ValueChanged += (sender, e) =>
            {
                if (slider.Value < min)
                {
                    slider.Value = min;
                }
            };
        }
	}
}