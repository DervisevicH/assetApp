using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetTracker_API.ViewModel
{
    public class AssignedAssetsVM
    {
        public int AssignAssetId { get; set; }
        public int? AssetId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string Asset{ get; set; }
        public int AssetNmb { get; set; }
        public string Employee{ get; set; }
    }
}
