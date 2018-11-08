using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinGrid1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void NumericButton_Clicked(object sender, EventArgs e)
        {
            phoneNumberLabel.Text = phoneNumberLabel.Text + (sender as Button).Text;
        }
    }
}
