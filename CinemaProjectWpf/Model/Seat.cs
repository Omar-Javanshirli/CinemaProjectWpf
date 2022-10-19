using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProjectWpf.Model
{
    public enum SeatCase { Empty=1,CurrentSelected=2,Full=3}
    public class Seat
    {
        public string No { get; set; }
        public SeatCase Case { get; set; }
    }
}
