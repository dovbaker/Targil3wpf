using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_03_1384_1072
{
    public class HostingUnit
    {
        public string UnitName;
        public int Rooms ;
        public bool IsSwimmimgPool ;
        public  List<DateTime> AllOrders { get; set; }
        public  List<string> Uris { get; set; }
    }
}
