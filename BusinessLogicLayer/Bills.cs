using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public  class Bills
    {
        public int BillsID { get; set; }
        public int OrderID { get; set; }
        public int RestaurantID { get; set; }
        public double BillAmount { get; set; }
        public int CustomerID { get; set; }
        public string Status { get; set; }
    }
}
