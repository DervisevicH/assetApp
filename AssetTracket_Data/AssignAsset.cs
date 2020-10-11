using System;
using System.Collections.Generic;

namespace AssetTracket_Data
{
    public partial class AssignAsset
    {
        public int AssignAssetId { get; set; }
        public int? AssetId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string Comment { get; set; }
        public int? AdministratorId { get; set; }

        public virtual Administrator Administrator { get; set; }
        public virtual Asset Asset { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
