using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Npgsql;
namespace App5
{
    public partial class Favorite : FlyoutPage
    {
        private SelectionPageViewModel viewModel;
        private double _translationX;
        private double _translationY;
        public Favorite(int id)
        {
            InitializeComponent();
            FlyoutPage.ListView.ItemSelected += ListView_ItemSelected;
            viewModel = new SelectionPageViewModel();
            BindingContext = viewModel;

            // Load the place data
            LoadPlaceData(id);
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void LoadPlaceData(int id)
        {

            try
            {               
                await viewModel.LoadPlaceAsync(id);
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

        private async void OnButton1Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new FavoritesPage());
        }

        private async void OnButton2Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SelectionPage());
        }

        private async void OnButton3Clicked(object sender, EventArgs e)
        {
            var userViewModel = new UserViewModel
            {
                Name = GlobalData.UserName,
                Email = GlobalData.UserEmail
            };
            await Navigation.PushAsync(new ProfilePage(userViewModel));
        }
        private async void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    MainFrame.TranslationX = _translationX + e.TotalX;
                    MainFrame.TranslationY = _translationY + e.TotalY;
                    MainFrame.Rotation = 0.3 * (MainFrame.TranslationX / this.Width) * 180; // For rotation effect
                    break;

                case GestureStatus.Completed:
                    _translationX = MainFrame.TranslationX;
                    _translationY = MainFrame.TranslationY;

                    // Check if swipe threshold is met to trigger actions (like/dislike)
                    if (Math.Abs(MainFrame.TranslationX) > 150)
                    {
                        if (MainFrame.TranslationX > 0)
                        {
                            Lovely.Current++;
                            await Navigation.PushAsync(new Favorite(Lovely.Love[Lovely.Current]));
                        }
                        else
                        {
                            Lovely.Current++;
                            await Navigation.PushAsync(new Favorite(Lovely.Love[Lovely.Current]));
                        }
                    }
                    else
                    {
                        // Reset position if swipe threshold is not met
                        MainFrame.TranslateTo(0, 0, 250, Easing.SpringOut);
                        MainFrame.RotateTo(0, 250, Easing.SpringOut);
                    }
                    break;
            }
        }



    }
}