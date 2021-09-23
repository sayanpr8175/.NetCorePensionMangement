using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PensionerMVC.Models
{
    public class PensionerInput
    {
        [Required]
        [Display(Name ="Aadhar Number")]
        [RegularExpression("^[0-9]{12}$",ErrorMessage ="Please Enter 12 digits Aadhar Number")]
        public long AadharNo { get; set; }

        [Required]
        [Display(Name ="Name")]
        [RegularExpression(@"^[A-Z]{1}[a-z]+(\s[A-Z]{1})?(\s{1}[A-Z]{1}[a-z]+)+$",ErrorMessage ="Please Enter Valid Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name ="Date of Birth")]
        public string DateOfBirth { get; set; }
        [Required]
        [Display(Name ="PAN Number")]
        [RegularExpression("^[A-Z]{5}[0-9]{4}[A-Z]{1}$",ErrorMessage ="Please Enter Valid PAN details")]
        public string Pan { get; set; }
        [Required]
        [Display(Name ="Select Type of Pension")]
        public string PensionType { get; set; }
    }
}
