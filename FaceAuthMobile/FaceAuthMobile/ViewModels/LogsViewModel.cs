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
    public class LogsViewModel : BaseViewModel
    {
        public LogsViewModel()
        {
            Task.Run(async () =>
            {
                await GetLogs();
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

        private ObservableCollection<GetLogsResponseModel> logs;
        public ObservableCollection<GetLogsResponseModel> Logs
        {
            get { return logs; }
            set
            {
                logs = value;
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


        public async Task GetLogs()
        {
            var logs = new ObservableCollection<GetLogsResponseModel>();
            var manager = new ApiManager();
            UserDialogs.Instance.ShowLoading("Loading");
            var (error, response, statusCode) = await manager.GetLogs();
            UserDialogs.Instance.HideLoading();
            if (statusCode == 200)
            {
                if (response != null && response.Count > 0)
                {
                    logs = new ObservableCollection<GetLogsResponseModel>(response);
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
            Logs = logs;
        }

    }
}
