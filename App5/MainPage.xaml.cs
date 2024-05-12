using Xamarin.Forms;
using Xamarin.Essentials;
using System;
using System.IO;

namespace App5
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private void HelpButton_Clicked(object sender, EventArgs e)
        {
            string filePath = "путь_к_вашему_файлу_с_документацией";
            OpenDocumentation(filePath);
        }

        private async void OpenDocumentation(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    await Launcher.OpenAsync(new OpenFileRequest
                    {
                        File = new ReadOnlyFile(filePath)
                    });
                }
                else
                {
                    // Файл не найден
                    await DisplayAlert("Ошибка", "Файл с документацией не найден", "OK");
                }
            }
            catch (Exception ex)
            {
                // Обработка ошибок открытия файла
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}