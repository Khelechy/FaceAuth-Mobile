using System;
using System.Collections.Generic;
using System.Text;

namespace FaceAuthMobile.Models.RequestModels
{
    public class RecognizePersonRequestModel
    {
        public string Image { get; set; }
        public string GroupId { get; set; }
    }
}
