using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCinema.Data.Models
{
    public class Session
    {
        [Key]
        public int SessionID { get; set; }
        [StringLength(20)]
        public string Time { get; set; }
        public int SaloonID { get; set; }
        public int MovieID { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Saloon Saloon { get; set; }

    }
}
