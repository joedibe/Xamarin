using System;
using Xamarin.Forms;

namespace XamarinGrid2
{
    public partial class MainPage : ContentPage
    {
        private bool isDotClicked = false;

        public MainPage()
        {
            InitializeComponent();
        }

        private void NumericButton_Clicked(object sender, EventArgs e)
        {
            int numberOfDigitsPerSeparation = 3;
            string digit = (sender as Button).Text.ToString();
            string newDigits = GetDigits(outputLabel) + digit;
            
            if (newDigits.Length <= numberOfDigitsPerSeparation)
            {
                outputLabel.Text = newDigits;
            }
            else
            {
                string commaSeparatedDigits = "";
               
                for (int counter = 0; counter < newDigits.Length; counter++)
                {
                    if ((counter+1) % numberOfDigitsPerSeparation == 0 && counter != (newDigits.Length -1))
                    {
                        commaSeparatedDigits = "," + newDigits[newDigits.Length - counter - 1] + commaSeparatedDigits; 
                    }
                    else
                    {
                        commaSeparatedDigits = newDigits[newDigits.Length - counter - 1] + commaSeparatedDigits; 
                    }
                }

                outputLabel.Text = commaSeparatedDigits;
            }
        }

        private string GetDigits(Label label)
        {
            string digits = "";
            string outputText = label.Text.ToString().Trim();

            for (int counter = 0; counter < outputText.Length; counter++)
            {
                if (Char.IsDigit(outputText[counter]))
                {
                    digits = digits + outputText[counter];
                }
            }

            return digits[0] == '0' ? digits.Substring(1): digits;
        }

        private void ClearButton_Clicked(object sender, EventArgs e)
        {
            outputLabel.Text = "0";
        }
    }
}
