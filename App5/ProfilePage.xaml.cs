using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : FlyoutPage
    {
        public ProfilePage(UserViewModel userViewModel)
        {
            InitializeComponent();
            BindingContext = userViewModel; 
            FlyoutPage.ListView.ItemSelected += ListView_ItemSelected;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as ProfilePageFlyoutMenuItem;
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
            List<int> likes = await User.GetFavouriteAsync(GlobalData.UserId);
            if (likes.Count == 0)
            {
                await Navigation.PushAsync(new FavoritesPage());
            }
            else
            {
                await Navigation.PushAsync(new Favorite(likes[0]));
            }
        }

        private async void OnButton2Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SelectionPage());
        }

        private async void OnButton3Clicked(object sender, EventArgs e)
        {
            //var userViewModel = new UserViewModel
            //{
             //   Name = GlobalData.UserName, 
             //  Email = GlobalData.UserEmail 
           // };
           // await Navigation.PushAsync(new ProfilePage(userViewModel));
        }
    }
}