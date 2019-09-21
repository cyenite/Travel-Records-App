using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordsApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;
using TravelRecordsApp.Logic;

namespace TravelRecordsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTravelPage : ContentPage
    {
        public NewTravelPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();

            var venues = await VenueLogic.GetVenues(position.Latitude, position.Longitude);

        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            Post post = new Post
            {
                Experience = experienceEntry.Text
            };

            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
            conn.CreateTable<Post>();
            int rows = conn.Insert(post);
            conn.Close();

            if (rows > 0)
            {
                DisplayAlert("Success","Succesfully added Experience!","Ok");
            }
            else
            {
                DisplayAlert("Failed!","Error adding Experience","Ok");
            }
        }
    }
}