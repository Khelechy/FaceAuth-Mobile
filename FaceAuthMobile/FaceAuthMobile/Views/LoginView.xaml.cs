using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FaceAuthMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private async Task SetPersonGroupId()
        {
            try
            {
                var group = await SecureStorage.GetAsync("personGroupId");
                if (!string.IsNullOrEmpty(personGroupId.Text))
                {
                    await SecureStorage.SetAsync("personGroupId", personGroupId.Text);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private async void ToMainPage(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
        }
    }
}