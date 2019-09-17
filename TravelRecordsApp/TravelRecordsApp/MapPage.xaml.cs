using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            
        }

        private void Hybrid_Clicked(object sender, EventArgs e)
        {

        }

        private void Street_Clicked(object sender, EventArgs e)
        {

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            locator.PositionChanged += Locator_PositionChanged;
        

            await locator.StartListeningAsync(ts, 10);
            var position = await locator.GetPositionAsync();

            locationMap.MoveToRegion(new Xamarin.Forms.Maps.MapSpan(new Xamarin.Forms.Maps.Position(position.Latitude,position.Longitude),2,2));

        }

        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            locationMap.MoveToRegion(new Xamarin.Forms.Maps.MapSpan(new Xamarin.Forms.Maps.Position(e.Position.Latitude, e.Position.Longitude), 2, 2));

        }
    }
}