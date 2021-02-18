using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCinema.Data.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [StringLength(20)]
        public string CategoryName { get; set; }
        public List<MovieCategory> MovieCategory { get; set; }
    }
}
