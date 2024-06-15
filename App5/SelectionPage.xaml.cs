using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App5
{
    public partial class SelectionPage : FlyoutPage
    {
        private SelectionPageViewModel viewModel;
        private double _translationX;
        private double _translationY;

        public SelectionPage()
        {
            InitializeComponent();
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
                int currentPlace = rnd.Next(1, 59);
                await viewModel.LoadPlaceAsync(currentPlace);
                GlobalData.CurrentPlace = currentPlace;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to load place data: {ex.Message}", "OK");
            }
        }

        private async void OnButton1Clicked(object sender, EventArgs e)
        {
            List<int> likes = await User.GetFavouriteAsync(GlobalData.UserId);
            if (likes.Count == 0)
            {
                await Navigation.PushAsync(new FavoritesPage());
            }
            else
            {
                await Lovely.UpdateLoveAsync(GlobalData.UserId);
                await Navigation.PushAsync(new Favorite(Lovely.Love[Lovely.Current]));
            }
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

        private async void OnKrestikClicked(object sender, EventArgs e)
        {
            await DislikeCurrentPlace();
        }

        private async void OnGalkaClicked(object sender, EventArgs e)
        {
            await LikeCurrentPlace();
        }

        private async Task DislikeCurrentPlace()
        {
            Reaction dislike = new Reaction(GlobalData.UserId, GlobalData.CurrentPlace);
            await dislike.Dislike();
            await Navigation.PushAsync(new SelectionPage());
        }

        private async Task LikeCurrentPlace()
        {
            Reaction like = new Reaction(GlobalData.UserId, GlobalData.CurrentPlace);
            await like.Like();
            await Navigation.PushAsync(new SelectionPage());
        }

        private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
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
                            LikeCurrentPlace();
                        }
                        else
                        {
                            DislikeCurrentPlace();
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
