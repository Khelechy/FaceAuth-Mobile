using System;
using System.Collections.Generic;
using System.Text;

namespace FaceAuthMobile.Models.ResponseModels
{
    public class AddPersonResponseModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string UserData { get; set; }
        public string UserGroupId { get; set; }
    }
}
