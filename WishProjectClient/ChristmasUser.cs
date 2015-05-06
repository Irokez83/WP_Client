using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishProjectClient
{
    public class ChristmasUser
    {
        public String UserName { get; set; }
        public String Pref { get; set; }
        public String Occ { get; set; }

        public override string ToString()
        {
            return UserName + " " + Pref + " " + Occ;
        }
    }
}
