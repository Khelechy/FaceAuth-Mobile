using FaceAuthMobile.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
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
    public partial class AddPersonPhotoView : ContentPage
    {

        public static MediaFile capturedImage;
        public AddPersonPhotoView()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, true);
            Init();
            uploadButton.IsVisible = false;
        }


        private async void Init()
        {
            await CrossMedia.Current.Initialize();
        }

        public async Task<MediaFile> TakePicture()
        {
            MediaFile mediaFile = null;
            if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
            {
                mediaFile = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = PhotoSize.Medium,
                    RotateImage = true,
                    DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Rear,
                    Directory = "FaceAuthImages",
                    Name = "face.jpg"
                });

                if (mediaFile != null)
                    staffPhoto.Source = ImageSource.FromStream(() => { return mediaFile.GetStream(); });
                    uploadButton.IsVisible = true;
            }
            else
            {

                await DisplayAlert("Camera not Found", ":(No Camera Available.", "OK");
            }
            return mediaFile;
        }

        public async void TakePicture_Event()
        {
            capturedImage = await TakePicture();
            var stream = capturedImage.GetStream();
            var bytes = new byte[stream.Length];
            await stream.ReadAsync(bytes, 0, (int)stream.Length);
            string base64 = System.Convert.ToBase64String(bytes);
            var vm = (AddPersonPhotoViewModel)BindingContext;
            vm.ImageString = base64;
        }

        public void TakePicture_Clicked(object sender, EventArgs e)
        {
            TakePicture_Event();
        }
    }
}