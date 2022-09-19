using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer
{
   public class Restaurant
   {
  
        public int RestaurantID { get; set; }
        public string RestaurantName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }


    }
}
