using System;
using System.Collections.Generic;

#nullable disable

namespace DeviceProject.Models
{
    public partial class device
    {
        public int device_id { get; set; }
        public string device_name { get; set; }
        public string device_model_sn { get; set; }
        public string device_content { get; set; }
        public string device_location { get; set; }
        public int? device_project_id { get; set; }
        public int? user_manager_id { get; set; }
        public string device_status { get; set; }
        public DateTime? device_report { get; set; }
        public DateTime? device_warranty_period { get; set; }
        public string device_other { get; set; }
        public string device_user_report { get; set; }
        public int? status { get; set; }
    }
    public partial class devicefilter
    {

        public string FilterAll { get; set; }
        public int device_id { get; set; }
        public string device_name { get; set; }
        public string device_model_sn { get; set; }
        public string device_content { get; set; }
        public string device_location { get; set; }
        public int? device_project_id { get; set; }
        public int? user_manager_id { get; set; }
        public string device_status { get; set; }
        public string device_other { get; set; }
        public string device_user_report { get; set; }
        public int? status { get; set; }
    }
}
