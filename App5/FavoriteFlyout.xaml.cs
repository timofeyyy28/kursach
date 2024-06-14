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
    public partial class FavoriteFlyout : ContentPage
    {
        public ListView ListView;

        public FavoriteFlyout()
        {
            InitializeComponent();

            BindingContext = new FavoriteFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class FavoriteFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FavoriteFlyoutMenuItem> MenuItems { get; set; }

            public FavoriteFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<FavoriteFlyoutMenuItem>(new[]
                {
                    new FavoriteFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new FavoriteFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new FavoriteFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new FavoriteFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new FavoriteFlyoutMenuItem { Id = 4, Title = "Page 5" },
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