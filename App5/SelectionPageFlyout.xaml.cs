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
    public partial class SelectionPageFlyout : ContentPage
    {
        public ListView ListView;

        public SelectionPageFlyout()
        {
            InitializeComponent();

            BindingContext = new SelectionPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class SelectionPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<SelectionPageFlyoutMenuItem> MenuItems { get; set; }

            public SelectionPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<SelectionPageFlyoutMenuItem>(new[]
                {
                    new SelectionPageFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new SelectionPageFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new SelectionPageFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new SelectionPageFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new SelectionPageFlyoutMenuItem { Id = 4, Title = "Page 5" },
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