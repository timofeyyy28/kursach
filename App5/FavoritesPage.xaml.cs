using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoritesPage : FlyoutPage
    {
        public FavoritesPage()
        {
            InitializeComponent();
            FlyoutPage.ListView.ItemSelected += ListView_ItemSelected;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as FavoritesPageFlyoutMenuItem;
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
            await Navigation.PushAsync(new FavoritesPage());
        }

        private async void OnButton2Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SelectionPage());
        }

        private async void OnButton3Clicked(object sender, EventArgs e)
        {
            var userViewModel = new UserViewModel
            {
                Name = GlobalData.UserName, // Установите реальное имя пользователя
                Email = GlobalData.UserEmail // Установите реальный адрес электронной почты
            };
            await Navigation.PushAsync(new ProfilePage(userViewModel));
        }
    }
}