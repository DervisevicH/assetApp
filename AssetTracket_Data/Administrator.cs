using System;
using System.Collections.Generic;

namespace AssetTracket_Data
{
    public partial class Administrator
    {
        public Administrator()
        {
            AssignAsset = new HashSet<AssignAsset>();
        }

        public int AdministratorId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public virtual ICollection<AssignAsset> AssignAsset { get; set; }
    }
}
