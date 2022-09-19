using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer
{
    public class Customer
    {
        [ScaffoldColumn(false)]

        
        public int CustomerID { get; set; }
        [Required(ErrorMessage = "Please Enter RestaurantID")]
        public int RestaurantID { get; set; }
        [Required(ErrorMessage = "Please Enter CustomerName")]
        public string CustomerName { get; set; }
       
        [Required(ErrorMessage = "Please Enter Mobile No")]
        [Display(Name = "Contact Number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10, ErrorMessage = "Contact number should be exactly 10 digits")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "")]
        public string Mobileno { get; set; }
    }
}
