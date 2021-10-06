using Acr.UserDialogs;
using FaceAuthMobile.Managers;
using FaceAuthMobile.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FaceAuthMobile.ViewModels
{
    public class AddPersonPhotoViewModel : BaseViewModel
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

        private string imageString;
        public string ImageString
        {
            get { return imageString; }
            set
            {
                imageString = value;
                OnPropertyChanged();
            }
        }


        public ICommand AddStaffCommand => new Command(AddStaffEvent);

        async void AddStaffEvent()
        {
            await AddStaff();
        }

        public async Task AddStaff()
        {
            if (string.IsNullOrEmpty(ImageString))
            {

            }
            else
            {
                try
                {
                    var personGroup = await SecureStorage.GetAsync("personGroupId");
                    if (string.IsNullOrEmpty(personGroup))
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "Please set person group id", "OK");
                    }
                    else
                    {
                        var manager = new ApiManager();
                        var addModel = new AddPersonRequestModel
                        {
                            FirstName = FirstName,
                            LastName = LastName,
                            Email = Email,
                            Role = Role,
                            GroupId = personGroup,
                            Image = ImageString
                        };
                        UserDialogs.Instance.ShowLoading("Loading");
                        var (error, response) = await manager.AddPerson(addModel);
                        if (response == null)
                        {
                            await App.Current.MainPage.DisplayAlert("Error", error, "OK");
                        }
                        else
                        {
                            await App.Current.MainPage.DisplayAlert("Success", "Staff Added Successfully", "OK");
                        }
                        UserDialogs.Instance.HideLoading();
                    }
                   
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
           
        }

    }
}
