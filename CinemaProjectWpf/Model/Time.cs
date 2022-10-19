using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProjectWpf.Model
{
    public class Time
    {
        public string TimeName { get; set; }
        public List<Seat> Seats { get; set; }
        public int SeatCount { get; set; }
    }
}
