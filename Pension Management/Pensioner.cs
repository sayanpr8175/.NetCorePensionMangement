using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pension_Management
{
    public class Pensioner
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long AadharNo { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public string Pan { get; set; }
        [Required]
        public string PensionType { get; set; }
        [Required]
        public double SalaryEarned { get; set; }
        [Required]
        public double Allowances { get; set; }
        [Required]
        public string BankName { get; set; }
        [Required]
        public long BankAccountNumber { get; set; }
        [Required]
        public string BankType { get; set; }
        public double PensionAmount { get; set; }
    }
}
