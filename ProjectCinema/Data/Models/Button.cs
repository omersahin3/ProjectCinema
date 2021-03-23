using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCinema.Data.Models
{
    public class Button
    {
        public bool State { get; set; }

        public Button(bool state)
        {
            State = state;
        }
    }
}
