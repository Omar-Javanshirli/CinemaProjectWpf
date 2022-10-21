using CinemaProjectWpf.Command;
using CinemaProjectWpf.Helper;
using CinemaProjectWpf.Model;
using CinemaProjectWpf.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace CinemaProjectWpf.ViewModel
{
    public class MovieCellViewModel:BaseViewModel
    {
        public Movie Movie { get; set; }
        public RelayCommand BuyCommand { get; set; }
        public List<Movie> Movies { get; set; }

        public MovieCellViewModel()
        {
            BuyCommand = new RelayCommand((e) =>
            {
                var view = new BuyTicketWindowViewModel();
                var window = new BuyTicketWindow();
                window.DataContext = view;
                view.Movie = Movie;
                view.Movies = Movies;
                window.Show();

            });
        }
    }
}
