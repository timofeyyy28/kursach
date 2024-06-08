using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App5
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private async void LoginButton_Clicked1(object sender, EventArgs e)
        {
            var viewModel = (LoginViewModel)BindingContext;

            YandexCloudAuth yc = new YandexCloudAuth();
            bool loginSuccess = await yc.SignInAsync(viewModel.Email, viewModel.Password);

            if (loginSuccess)
            {
                var userViewModel = new UserViewModel
                {
                    Name = "UserName", // Замените на реальное значение
                    Email = viewModel.Email
                };
                
                GlobalData.UserEmail = viewModel.Email;
                await Navigation.PushAsync(new SelectionPage());
            }
            else
            {
                await DisplayAlert("Ошибка", "Ошибка при вводе данных. Пожалуйста, проверьте введенные данные и попробуйте снова.", "OK");
            }
        }
    }
}