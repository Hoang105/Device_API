using System;
using System.Collections.Generic;

#nullable disable

namespace DeviceProject.Models
{
    public partial class device_history
    {
        public int device_history_id { get; set; }
        public string device_history_status { get; set; }
        public DateTime device_history_change { get; set; }
        public int user_change_id { get; set; }
        public int device_change_id { get; set; }
    }
    public partial class device_history_filter
    {
        public int device_change_id { get; set; }
    }
}
