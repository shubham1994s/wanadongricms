using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwachBharat.CMS.Bll.ViewModels.ChildModel.Model
{
   public class HSUR_Daily_AttendanceVM : BaseVM
    {
        public string LOGIN_ID { get; set; }
        public int EmpId { get; set; }
        public string StartTime { get; set; }

        public string daDate { get; set; }

        public string ipaddress { get; set; }

        public string logindevice { get; set; }
    }
}
