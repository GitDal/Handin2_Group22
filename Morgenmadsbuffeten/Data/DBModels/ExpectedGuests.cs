using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Morgenmadsbuffeten.Data.DBModels
{
    public class ExpectedGuests
    {
        [Display(Name = "Total Amount")]
        public int TotalAmount { get; set; }
        [Display(Name = "Number of Adults")]
        public int NumberOfAdults { get; set; }
        [Display(Name = "Number of Children")]
        public int NumberOfChildren { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
    }
}
