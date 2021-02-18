using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCinema.Data.Models
{
    public class MovieCategory
    {
        [Key]
        public int MovieCategoryID { get; set; }
        public int MovieID { get; set; }
        public int CategoryID { get; set; }

        public virtual Movie Movie { get; set; }//Transmitter
        public virtual Category Category { get; set; }
    }
}
