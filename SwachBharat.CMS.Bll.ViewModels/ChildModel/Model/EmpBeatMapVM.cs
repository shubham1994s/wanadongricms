using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwachBharat.CMS.Bll.ViewModels.ChildModel.Model
{
    public class EmpBeatMapVM
    {
        public int ebmId { get; set; }
        public int? userId { get; set; }

        public string userName { get; set; }
        public List<coordinates> ebmLatLong { get; set; }
        public string Type { get; set; }
    }
    public class coordinates
    {
        public double? lat { get; set; }
        public double? lng { get; set; }
    }
}
