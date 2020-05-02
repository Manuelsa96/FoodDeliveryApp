using System;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FoodDeliveryAppByManuel
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

        private void BtnSave_Clicked(object sender, EventArgs e)
        {
            Preferences.Set("username", EntUserName.Text);
        }

        private void BtnRetrieve_Clicked(object sender, EventArgs e)
        {
           var response = Preferences.Get("username", string.Empty);
            LblUserName.Text = response;
        }
    }
}
