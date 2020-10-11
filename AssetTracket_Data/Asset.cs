using System;
using System.Collections.Generic;

namespace AssetTracket_Data
{
    public partial class Asset
    {
        public Asset()
        {
            AssignAsset = new HashSet<AssignAsset>();
        }

        public int AssetId { get; set; }
        public string AssetName { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public bool? IsAvailable { get; set; }
        public int? AssetNmb { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<AssignAsset> AssignAsset { get; set; }
    }
}
