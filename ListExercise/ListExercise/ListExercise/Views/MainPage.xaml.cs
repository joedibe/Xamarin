using ListExercise.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace ListExercise
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Hotel> hotelList;
        public MainPage()
        {
            InitializeComponent();

            hotelList = new ObservableCollection<Hotel>
            {
               new Hotel { Name = "Four Seasons Resort", Address = "Chiang Mai, Thailand", CheckInDate = DateTime.Now, CheckOutDate = DateTime.Now },
               new Hotel { Name = "Brewery Gulch Inn", Address = "Mendocino, California", CheckInDate = DateTime.Now, CheckOutDate = DateTime.Now },
               new Hotel { Name = "Alila Manggis", Address = "Bali, Indonesia", CheckInDate = DateTime.Now, CheckOutDate = DateTime.Now },
            };

            hotelListView.ItemsSource = hotelList;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            hotelListView.ItemsSource = GetHotels(e.NewTextValue);
        }

        IEnumerable<Hotel> GetHotels(string searchText = null)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return hotelList;
            }

            return hotelList.Where(c => c.Name.ToLower().Contains(searchText.ToLower()) ||
                                        c.Address.ToLower().Contains(searchText.ToLower()));
        }

        async private void hotelListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedHotel = e.Item as Hotel;

            await DisplayAlert("Hotel", selectedHotel.NameWithAddress, "Ok");

            hotelList.Remove(selectedHotel);
            hotelList.Insert(0, selectedHotel);
            hotelListView.ItemsSource = hotelList;
            searchBar.Text = "";
        }

        private void hotelListView_Refreshing(object sender, EventArgs e)
        {
            hotelListView.ItemsSource = searchBar.Text != "" ? GetHotels(searchBar.Text) : hotelList;
            hotelListView.IsRefreshing = false;
            hotelListView.EndRefresh();
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            var selectedHotel = (sender as MenuItem).CommandParameter as Hotel;

            hotelList.Remove(selectedHotel);
            hotelListView.ItemsSource = hotelList;
        }
    }
}
