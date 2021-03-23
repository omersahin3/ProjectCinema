using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCinema.Data.Models
{
    public class Chair
    {
        [Key]
        public int ChairID { get; set; }
        public Boolean Status { get; set; }
        public int SaloonID { get; set; }
        public virtual Saloon Saloon { get; set; }
        public List<Ticket> Ticket { get; set; }

    }
}
