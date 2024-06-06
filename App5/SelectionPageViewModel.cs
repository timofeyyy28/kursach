using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace App5
{
    public class SelectionPageViewModel : INotifyPropertyChanged
    {
        private Place place;

        public Place Place
        {
            get => place;
            set
            {
                place = value;
                OnPropertyChanged();
            }
        }

        public async Task LoadPlaceAsync(int id)
        {
            var newPlace = new Place();
            await newPlace.InitializeAsync(id);
            Place = newPlace;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}