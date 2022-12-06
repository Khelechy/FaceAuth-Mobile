using FaceAuthMobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: ExportFont("muli.regular.ttf", Alias = "DefaultFont")]
[assembly: ExportFont("Muli-Bold.ttf", Alias = "DefaultFontBold")]
namespace FaceAuthMobile
{
    public partial class App : Application
    {
        public static NavigationPage Navigation = null;
        public App()
        {
            InitializeComponent();
            Navigation = new NavigationPage(new LoginView());
            Application.Current.MainPage = Navigation;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
