using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App5
{
    public partial class RegistrationPage : ContentPage
    {
       
        public RegistrationPage()
        {
            InitializeComponent();
           
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }
        private RegistrationViewModel viewModel;
        private async void Button_Clicked1(object sender, EventArgs e)
        {
            var viewModel = (RegistrationViewModel)BindingContext;

            YandexCloudAuth yc = new YandexCloudAuth();
            bool registrationSuccess = await yc.RegisterAsync(viewModel.Email, viewModel.Password, viewModel.Name, viewModel.Email, viewModel.BirthDate, "0");

            if (registrationSuccess)
            {
                var userViewModel = new UserViewModel
                {
                    Name = viewModel.Name,
                    Email = viewModel.Email
                };
                GlobalData.UserName = viewModel.Name;
                GlobalData.UserEmail = viewModel.Email;
                await Navigation.PushAsync(new LoginPage());
            }
            else
            {
                await DisplayAlert("Ошибка", "Ошибка при вводе данных. Пожалуйста, проверьте введенные данные и попробуйте снова.", "OK");
            }
        }

    }
}