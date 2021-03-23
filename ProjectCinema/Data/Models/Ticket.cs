using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCinema.Data.Models
{
    public class Ticket
    {
        [Key]
        public int TicketID { get; set; }
        public int SessionID { get; set; }
        public int? ChairID { get; set; }
        public virtual Session Session { get; set; }
        public virtual Chair Chair { get; set; }

    }
}
