using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwachBharat.CMS.Bll.ViewModels.MainModel
{
    public class MenuItem
    {
        public int M_ID { get; set; }
        public int? M_P_ID { get; set; }
        public string LinkText { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string returnUrl { get; set; }
        public string Type { get; set; }

    }
}
