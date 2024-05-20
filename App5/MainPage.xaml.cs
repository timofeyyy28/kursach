using Xamarin.Forms;
using Xamarin.Essentials;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

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

        private async void HelpButton_Clicked(object sender, EventArgs e)
        {
            string fileName = "App5.Resources.rukovodstvo.pdf";
            await OpenDocumentation(fileName);
        }

        private async Task OpenDocumentation(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream(fileName))
            {
                if (stream != null)
                {
                    byte[] byteArray = new byte[stream.Length];
                    await stream.ReadAsync(byteArray, 0, (int)stream.Length);

                    string filePath = Path.Combine(FileSystem.CacheDirectory, "temp.pdf");
                    File.WriteAllBytes(filePath, byteArray);

                    var fileUri = new Uri(filePath, UriKind.Absolute);
                    await Launcher.OpenAsync(new OpenFileRequest { File = new ReadOnlyFile(filePath) });
                }
                else
                {
                    await DisplayAlert("Ошибка", "Файл справки не найден", "OK");
                }
            }
        }

        private async void Button_Clicked1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SelectionPage());
        }

        private async void LoginButton_Clicked1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SelectionPage());
        }
    }
}