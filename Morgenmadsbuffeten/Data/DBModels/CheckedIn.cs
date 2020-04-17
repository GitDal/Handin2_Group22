using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Morgenmadsbuffeten.Data.DBModels
{
    public class CheckedIn
    {
        public int RoomNumber { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
    }
}
