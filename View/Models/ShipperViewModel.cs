using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace View.Models
{
    public class ShipperViewModel
    {
        [Required]
        [Display(Name = "Código")]
        public int ShipperID { get; set; }
        [Required]
        [Display(Name = "Companhia")]
        [StringLength(40)]
        public string CompanyName { get; set; }
        [Display(Name ="Telefone")]
        [StringLength(24)]
        public string Phone { get; set; }
    }
}