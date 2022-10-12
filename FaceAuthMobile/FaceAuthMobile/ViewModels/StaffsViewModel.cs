using Acr.UserDialogs;
using FaceAuthMobile.Managers;
using FaceAuthMobile.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace FaceAuthMobile.ViewModels
{
    public class StaffsViewModel : BaseViewModel
    {
        public StaffsViewModel()
        {
            Task.Run(async () =>
            {
                await GetStaffs();
            });
        }
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

        private bool showHeader;
        public bool ShowHeader
        {
            get { return showHeader; }
            set
            {
                showHeader = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<AddPersonResponseModel> staffs;
        public ObservableCollection<AddPersonResponseModel> Staffs
        {
            get { return staffs; }
            set
            {
                staffs = value;
                OnPropertyChanged();
            }
        }

        private bool isNonFound = false;
        public bool IsNonFound
        {
            get { return isNonFound; }
            set
            {
                isNonFound = value;
                OnPropertyChanged();
            }
        }


        public async Task GetStaffs()
        {
            var staffs = new ObservableCollection<AddPersonResponseModel>();
            var manager = new ApiManager();
            UserDialogs.Instance.ShowLoading("Loading");
            var (error, response, statusCode) = await manager.GetStaffs();
            UserDialogs.Instance.HideLoading();
            if (statusCode == 200)
            {
                if (response != null && response.Count > 0)
                {
                    staffs = new ObservableCollection<AddPersonResponseModel>(response);
                    ShowHeader = true;
                }
                else
                {
                    IsNonFound = true;
                }


            }
            else
            {
                IsNonFound = true;
            }
            Staffs = staffs;
        }


    }
}
