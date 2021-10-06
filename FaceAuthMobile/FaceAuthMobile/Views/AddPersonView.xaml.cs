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
    public partial class AddPersonView : ContentPage
    {
        public AddPersonView()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, true);
        }
    }
}