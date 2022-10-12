using System;
using System.Collections.Generic;
using System.Text;

namespace FaceAuthMobile.Models.ResponseModels
{
    public class GetLogsResponseModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public Guid UserId { get; set; }
        public DateTime LastLogTime { get; set; }
    }
}
