using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer
{
    public class Cuisine
    {

      
           // [Required]
            public int CuisineID { get; set; }
            //[Required]
            public int RestaurantID { get; set; }
           // [Required]
            public string CuisineName { get; set; }



        
    }
}
