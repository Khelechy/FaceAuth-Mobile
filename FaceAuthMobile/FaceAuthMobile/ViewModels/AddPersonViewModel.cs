using Acr.UserDialogs;
using FaceAuthMobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FaceAuthMobile.ViewModels
{
    public class AddPersonViewModel : BaseViewModel
    {
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged();
            }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged();
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        private string role;
        public string Role
        {
            get { return role; }
            set
            {
                role = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddDetailsCommand => new Command(AddDetailsEvent);

        async void AddDetailsEvent()
        {
            await AddDetails();
        }

        private async Task AddDetails()
        {
            if(string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Role))
            {
                await App.Current.MainPage.DisplayAlert("Error", "One or more field(s) are empty", "OK");
            }
            else
            {
                UserDialogs.Instance.ShowLoading("Loading");
                var vm = new AddPersonPhotoViewModel { FirstName = FirstName, LastName = LastName, Email = Email, Role = Role };
                var addPersonPhotoView = new AddPersonPhotoView { BindingContext = vm };
                var navigation = Application.Current.MainPage as NavigationPage;
                await navigation.PushAsync(addPersonPhotoView, true);
                UserDialogs.Instance.HideLoading();
            }
        }
    }
}
