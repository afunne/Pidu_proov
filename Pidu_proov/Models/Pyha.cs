using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pidu_proov.Models
{
    public class Pyha
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nimetus on kohustuslik")]
        public string Nimetus { get; set; }
        [DataType(DataType.Date)]
        public DateTime Kuupaev { get; set; }
        [Display(Name = "Minimaalne hind (€)")]
        [Range(0, 999999, ErrorMessage = "Hind peab olema positiivne arv.")]
        public decimal HindMin { get; set; }
        [Display(Name = "Maksimaalne hind (€)")]
        [Range(0, 999999, ErrorMessage = "Hind peab olema positiivne arv.")]
        public decimal HindMax { get; set; }
    }
}