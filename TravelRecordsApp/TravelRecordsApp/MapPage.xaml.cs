using Plugin.Geolocator;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordsApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public static string ttime = "0:0:0";
        TimeSpan ts = new TimeSpan(int.Parse(ttime.Split(':')[0]),
            int.Parse(ttime.Split(':')[1]),
            int.Parse(ttime.Split(':')[2])
            );
        public MapPage()
        {
            InitializeComponent();
        }

        private void Satellite_Clicked(object sender, EventArgs e)
        {
            locationMap.MapType = Xamarin.Forms.Maps.MapType.Hybrid;
        }


        private void Street_Clicked(object sender, EventArgs e)
        {
            locationMap.MapType = Xamarin.Forms.Maps.MapType.Street;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            locator.PositionChanged += Locator_PositionChanged;

            await locator.StartListeningAsync(ts, 10);
            var position = await locator.GetPositionAsync();
            locationMap.MoveToRegion(new Xamarin.Forms.Maps.MapSpan(new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude), 2, 2));

            using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
            {
                con.CreateTable<Post>();
                var posts = con.Table<Post>().ToList();

                DisplayInMap(posts);
            }


        }

        private void DisplayInMap(List<Post> posts)
        {

            foreach (var post in posts)
            {
                try
                {
                    var position = new Xamarin.Forms.Maps.Position(post.Latitude, post.Longitude);
                    var pin = new Xamarin.Forms.Maps.Pin()
                    {
                        Type = Xamarin.Forms.Maps.PinType.SavedPin,
                        Position = position,
                        Label = post.VenueName,
                        Address = post.Address
                    };

                    locationMap.Pins.Add(pin);
                }
                catch (NullReferenceException nre) { }
                catch (Exception ex) { }
            }
           
        }

        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            locationMap.MoveToRegion(new Xamarin.Forms.Maps.MapSpan(new Xamarin.Forms.Maps.Position(e.Position.Latitude, e.Position.Longitude), 2, 2));

        }
        protected override async void OnDisappearing()
        {
            base.OnDisappearing();

            var locator = CrossGeolocator.Current;
            locator.PositionChanged -= Locator_PositionChanged;
            await locator.StopListeningAsync();
        }
    }
}