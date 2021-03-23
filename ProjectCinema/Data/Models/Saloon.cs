using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCinema.Data.Models
{
    public class Saloon
    {
        [Key]
        public int SaloonID { get; set; }
        [StringLength(20)]
        public string SaloonName { get; set; }
        public int LineArmChairNumber { get; set; }
        public int ColumnArmChairNumber { get; set; }
        public List<Session> Session { get; set; }
        public List<Chair> Chair { get; set; }
    }
}
