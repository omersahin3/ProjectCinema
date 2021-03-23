using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCinema.Data.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }
        [StringLength(50)]
        public string MovieName { get; set; }
        [StringLength(20)]
        public string Time { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [StringLength(50)]
        public string ImageURL { get; set; }
        [StringLength(50)]
        public string Director { get; set; }
        public double StudentPrice { get; set; }
        public double CivilPrice { get; set; }
        public List<MovieCategory> MovieCategory { get; set; } // Receiver
        public List<Session> Session { get; set; }
    }
}
