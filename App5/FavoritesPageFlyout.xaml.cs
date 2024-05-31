using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoritesPageFlyout : ContentPage
    {
        public ListView ListView;

        public FavoritesPageFlyout()
        {
            InitializeComponent();

            BindingContext = new FavoritesPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class FavoritesPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FavoritesPageFlyoutMenuItem> MenuItems { get; set; }

            public FavoritesPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<FavoritesPageFlyoutMenuItem>(new[]
                {
                    new FavoritesPageFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new FavoritesPageFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new FavoritesPageFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new FavoritesPageFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new FavoritesPageFlyoutMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}