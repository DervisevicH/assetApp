using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetTracker_API.ViewModel
{
    public class AssetsVM
    {
        public int AssetId { get; set; }
        public string AssetName { get; set; }
        public string Description { get; set; }
        public int? InStock { get; set; }
        public int? CategoryId { get; set; }
        public bool? IsAvailable { get; set; }
        public string Category{ get; set; }
        public int AssetNmb{ get; set; }

    }
}
