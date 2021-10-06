using FaceAuthMobile.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FaceAuthMobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                await SecureStorage.SetAsync("personGroupId", personGroupId.Text);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            await Application.Current.MainPage.Navigation.PushAsync(new StaffsView());
        }
    }
}
