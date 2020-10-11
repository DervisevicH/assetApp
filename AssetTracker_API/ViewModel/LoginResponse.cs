using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetTracker_API.ViewModel
{
    public class LoginResponse
    {
        public string token{ get; set; }
        public string username{ get; set; }
        public int userId{ get; set; }
    }
}
