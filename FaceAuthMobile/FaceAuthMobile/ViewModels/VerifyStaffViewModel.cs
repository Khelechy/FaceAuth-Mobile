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
    public class VerifyStaffViewModel : BaseViewModel
    {
        private bool isLoaded;
        public bool IsLoaded
        {
            get { return isLoaded; }
            set
            {
                isLoaded = value;
                OnPropertyChanged();
            }
        }

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

        public ICommand VerifyStaffCommand => new Command(VerifyStaffEvent);

        async void VerifyStaffEvent()
        {
            await VerifyStaff();
        }

        public async Task VerifyStaff()
        {
            if (string.IsNullOrEmpty(ImageString))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Please capture a face picture", "OK");
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
                        var addModel = new RecognizePersonRequestModel
                        {
                            GroupId = personGroup,
                            Image = ImageString
                        };
                        UserDialogs.Instance.ShowLoading("Loading");
                        var (error, response, statusCode) = await manager.IdentifyPerson(addModel);
                        if (statusCode == 200)
                        {
                            await App.Current.MainPage.DisplayAlert("Success", "Staff Identified", "OK");
                            IsLoaded = true;
                            FirstName = response.FirstName;
                            LastName = response.LastName;
                            Email = response.Email;
                            Role = response.Role;
                        }
                        else
                        {
                            await App.Current.MainPage.DisplayAlert("Error", error, "OK");
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
