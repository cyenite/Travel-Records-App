using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TravelRecordsApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void ButtonLogIn_Clicked(object sender, EventArgs e)
        {
            bool emailEmpty = string.IsNullOrEmpty(emailEntry.Text);
            bool passwordEmpty = string.IsNullOrEmpty(passwordEntry.Text);

            if (emailEmpty || passwordEmpty)
            {
                
            }
            else
            {
                Navigation.PushAsync(new Homepage());
            }

        }

       
    }
}
