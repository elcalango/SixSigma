using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace View.Models
{
    public class RegionViewModel
    {
        [Required]
        [Display(Name ="Código")]
        public int RegionID { get; set; }
        [Required]
        [Display(Name = "Nome" )]
        [StringLength(50)]
        public string RegionDescription { get; set; }
    }
}