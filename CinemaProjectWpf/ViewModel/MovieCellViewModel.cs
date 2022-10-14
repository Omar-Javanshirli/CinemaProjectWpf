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

        public MovieCellViewModel()
        {
            BuyCommand = new RelayCommand((e) =>
            {
                var view = new BuyTicketWindowViewModel();
                var window = new BuyTicketWindow();
                window.DataContext = view;
                view.Movie = Movie;

                var movies = FileHelper.ReadMovies();
                foreach (var item in App.MyUniformGrid.Children)
                {
                    var btn = item as Button;
                    foreach (var movie in movies)
                    {
                        if (App.Aftermoon.IsEnabled == true && App.TwoSentyabr.IsSelected == true && App.MetroPark.IsSelected && view.Movie.Name==movie.Name)
                        {
                            foreach (var empty in movie.EmptyPlaces)
                            {
                                if (btn.Content.ToString() == empty)
                                {
                                    btn.Background = Brushes.Black;
                                    btn.IsEnabled = false;
                                }
                            }
                        }
                    }
                }

                window.Show();

            });
        }
    }
}
