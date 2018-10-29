using System;
using Xamarin.Forms;

namespace XamarinActivity2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            if(Device.RuntimePlatform == Device.iOS)
            {
                Padding = new Thickness(20, 40, 20, 20);
            }
            else
            {
                Padding = new Thickness(20, 20, 20, 20);
            }

            // Set red, green and blue slider's properties
            SetColorSliderProperties(redSlider);
            SetColorSliderProperties(greenSlider);
            SetColorSliderProperties(blueSlider);

            // Set initial background color of box of type BoxView
            SetBoxBackgroundColor();
        }

        /*
         * Set properties of a color's slider, and add an event handler 
         * that changes the background color of the box view depends on the 
         * combinations of the current values of the given sliders, when the
         * Value property changes. 
         */
        private void SetColorSliderProperties(Slider slider)
        {
            slider.Minimum = 0;
            slider.Maximum = 255;
            slider.ValueChanged += (sender, e) => SetBoxBackgroundColor();
        }

        /*
         * Set background color of object box of type BoxView based on the
         * combinations of the values of the given sliders.
         */
        private void SetBoxBackgroundColor()
        {
            box.BackgroundColor = Color.FromRgb(
                    Convert.ToInt32(redSlider.Value),
                    Convert.ToInt32(greenSlider.Value), 
                    Convert.ToInt32(blueSlider.Value)
                );
        }
    }
}
