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

                if (App.MetroPark.IsSelected == true && App.TwoSentyabr.IsSelected == true && App.Aftermoon.IsSelected == true)
                {
                    Movie.Location = App.MetroPark.Content.ToString();
                    Movie.DateTIme = App.TwoSentyabr.Content.ToString();
                    Movie.TIme = App.Aftermoon.Content.ToString();
                }
                var movieData = FileHelper.ReadMovies();
                foreach (var item in movieData)
                {
                    if (item.Name == Movie.Name && item.Location==Movie.Location && item.DateTIme==Movie.DateTIme && item.TIme==Movie.TIme)
                    {
                        foreach (var b in item.ReservePlace)
                        {
                            foreach (var grid in App.MyUniformGrid.Children)
                            {
                                var btn = grid as Button;
                                if (btn.Content.ToString() == b)
                                {
                                    btn.IsEnabled = false;
                                    btn.Background = Brushes.Black;
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
