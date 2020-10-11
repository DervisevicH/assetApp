using System;
using System.Collections.Generic;

namespace AssetTracket_Data
{
    public partial class Employee
    {
        public Employee()
        {
            AssignAsset = new HashSet<AssignAsset>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }

        public virtual ICollection<AssignAsset> AssignAsset { get; set; }
    }
}
