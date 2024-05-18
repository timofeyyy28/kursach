using System;
using Xamarin.Forms;

namespace App5
{
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }
        private async void Button_Clicked1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SelectionPage());
        }

    }
}