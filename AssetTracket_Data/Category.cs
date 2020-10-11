using System;
using System.Collections.Generic;

namespace AssetTracket_Data
{
    public partial class Category
    {
        public Category()
        {
            Asset = new HashSet<Asset>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Asset> Asset { get; set; }
    }
}
