using System;
using System.Collections.Generic;
using System.Text;

namespace FaceAuthMobile.Models.RequestModels
{
    public class AddPersonRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string Role { get; set; }
        public string GroupId { get; set; }
    }
}
