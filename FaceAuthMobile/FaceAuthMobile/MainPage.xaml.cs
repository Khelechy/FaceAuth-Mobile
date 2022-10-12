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

        private async Task SetPersonGroupId()
        {
            try
            {
                var group = await SecureStorage.GetAsync("personGroupId");
                if(!string.IsNullOrEmpty(personGroupId.Text))
                {
                    await SecureStorage.SetAsync("personGroupId", personGroupId.Text);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private async void ToViewLogs(object sender, EventArgs e)
        {
            await SetPersonGroupId();
            await Application.Current.MainPage.Navigation.PushAsync(new LogsView());
        }

        private async void ToStaffList(object sender, EventArgs e)
        {
            await SetPersonGroupId();
            await Application.Current.MainPage.Navigation.PushAsync(new StaffsView());
        }

        private async void ToAddStaff(object sender, EventArgs e)
        {
            await SetPersonGroupId();
            await Application.Current.MainPage.Navigation.PushAsync(new AddPersonView());
        }

        private async void ToVerifyStaff(object sender, EventArgs e)
        {
            await SetPersonGroupId();
            await Application.Current.MainPage.Navigation.PushAsync(new VerifyStaff());
        }
    }
}
