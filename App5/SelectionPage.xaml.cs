using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App5
{
    public partial class SelectionPage : FlyoutPage
    {
        private SelectionPageViewModel viewModel;

        public SelectionPage()
        {
            InitializeComponent();
            FlyoutPage.ListView.ItemSelected += ListView_ItemSelected;
            viewModel = new SelectionPageViewModel();
            BindingContext = viewModel;

            // Load the place data
            LoadPlaceData();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void LoadPlaceData()
        {
            try
            {
                Random rnd = new Random();
                await viewModel.LoadPlaceAsync(rnd.Next(1, 59));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to load place data: {ex.Message}", "OK");
            }
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as SelectionPageFlyoutMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            FlyoutPage.ListView.SelectedItem = null;
        }

        private async Task OnButton1Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FavoritesPage());
        }

        private async Task OnButton2Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SelectionPage());
        }

        private async Task OnButton3Clicked(object sender, EventArgs e)
        {
            var userViewModel = new UserViewModel
            {
                Name = GlobalData.UserName,
                Email = GlobalData.UserEmail
            };
            await Navigation.PushAsync(new ProfilePage(userViewModel));
        }

        private async void OnKrestikClicked(object sender, EventArgs e)
        {
            // Ваша логика для кнопки "krestik"
            await Navigation.PushAsync(new SelectionPage());
        }

        private async void OnGalkaClicked(object sender, EventArgs e)
        {
            // Ваша логика для кнопки "galka"
            await Navigation.PushAsync(new SelectionPage());
        }

        private async void OnSwipeLeft(object sender, SwipedEventArgs e)
        {
            // Обработчик свайпа влево (для кнопки "krestik")
            await OnKrestikClicked(sender, e);
        }

        private async void OnSwipeRight(object sender, SwipedEventArgs e)
        {
            // Обработчик свайпа вправо (для кнопки "galka")
            await OnGalkaClicked(sender, e);
        }
    }
}