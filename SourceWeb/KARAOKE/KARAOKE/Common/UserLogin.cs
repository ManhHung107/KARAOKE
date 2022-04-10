using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KARAOKE
{
    [Serializable]
    public class UserLogin
    {
        
        public int UserID { set; get; }
        public string UserName { get; set; }
    }
}