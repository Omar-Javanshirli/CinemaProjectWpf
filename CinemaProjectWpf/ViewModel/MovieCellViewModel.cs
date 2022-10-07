using CinemaProjectWpf.Command;
using CinemaProjectWpf.Model;
using CinemaProjectWpf.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProjectWpf.ViewModel
{
    public class MovieCellViewModel:BaseViewModel
    {
        public Movie Movie { get; set; }
        public RelayCommand BuyCommand { get; set; }

        public MovieCellViewModel()
        {
            BuyCommand = new RelayCommand((e) =>
            {
                var view = new BuyTicketWindowViewModel();
                var window =new  BuyTicketWindow();

                window.Show();
                
            });
        }
    }
}
