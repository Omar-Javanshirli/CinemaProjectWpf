using CinemaProjectWpf.Command;
using CinemaProjectWpf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProjectWpf.ViewModel
{
    public class SeatViewModel:BaseViewModel
    {
        private Seat seat;

        public Seat Seat
        {
            get { return seat; }
            set { seat = value; OnPropertyChanged(); }
        }


        public RelayCommand SeatSelectCommand { get; set; }

        public SeatViewModel()
        {
            SeatSelectCommand = new RelayCommand((e) => {
                string no = Seat.No;
                if (Seat.Case == SeatCase.Empty)
                {

                Seat = new Seat
                {
                    Case=SeatCase.CurrentSelected,
                    No = no
                };
                }
                else if(Seat.Case == SeatCase.CurrentSelected)
                {
                    Seat = new Seat
                    {
                        Case = SeatCase.Empty,
                        No = no
                    };
                }
            });
        }

    }
}
