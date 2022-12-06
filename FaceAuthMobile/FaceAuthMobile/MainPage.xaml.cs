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

        private async void ToViewLogs(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new LogsView());
        }

        private async void ToStaffList(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new StaffsView());
        }

        private async void ToAddStaff(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddPersonView());
        }

        private async void ToVerifyStaff(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new VerifyStaff());
        }
    }
}
