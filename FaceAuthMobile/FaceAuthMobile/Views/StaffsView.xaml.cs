using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FaceAuthMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StaffsView : ContentPage
    {
        public StaffsView()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, true);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new StaffsView());
        }

        private async void ToAddStaff(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddPersonView());
        }
    }
}