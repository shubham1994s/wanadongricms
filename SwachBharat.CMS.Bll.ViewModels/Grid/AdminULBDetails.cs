using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwachBharat.CMS.Bll.ViewModels.Grid
{
    public class AdminULBDetails
    {
        public Nullable<int> ULBId { get; set; }
        public string ULBName { get; set; }
        public Nullable<int> TotalHouse { get; set; }
        public Nullable<int> TotalHouseScan { get; set; }
        public Nullable<int> TotalSeg { get; set; }
        public Nullable<int> TotalMix { get; set; }
        public Nullable<int> TotalNotReceived { get; set; }


    }
}
