using System;
using System.Collections.Generic;

#nullable disable

namespace DeviceProject.Models
{
    public partial class user_manager
    {
        public int user_manager_id { get; set; }
        public string user_manager_name { get; set; }
        public string user_manager_birthday { get; set; }
        public string user_manager_email { get; set; }
        public string user_manager_phone { get; set; }
        public string user_manager_username { get; set; }
        public string user_manager_password { get; set; }
        public int user_manager_role { get; set; }
    }
}
