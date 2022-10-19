using CinemaProjectWpf.Command;
using CinemaProjectWpf.Helper;
using CinemaProjectWpf.Model;
using CinemaProjectWpf.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace CinemaProjectWpf.ViewModel
{
    public class BuyTicketWindowViewModel : BaseViewModel
    {

        public Movie Movie { get; set; }
        public List<Movie> Movies { get; set; } = new List<Movie>();
        public RelayCommand RowButoonCommand { get; set; }
        public RelayCommand CheckOutCommand { get; set; }
        public RelayCommand ParkCinemaSelectedCommand { get; set; }
        public RelayCommand BackCommand { get; set; }
        public List<string> SerialNumber { get; set; } = new List<string>();
        public int Count { get; set; } = 0;

        private string ticketNumber;

        public string TicketNumber
        {
            get { return ticketNumber; }
            set { ticketNumber = value; OnPropertyChanged(); }
        }


        public Button GetButton(Button button)
        {
            var uniform = button.Parent as UniformGrid;

            foreach (var item in uniform.Children)
            {
                if (item is Button bt)
                {
                    if (bt.Content == button.Content)
                        return bt;
                }
            }
            return null;
        }

        public BuyTicketWindowViewModel()
        {

            RowButoonCommand = new RelayCommand((e) =>
            {
                Count++;
                var btn = e as Button;
                var button = GetButton(btn);

                if (button.Background != Brushes.LightSeaGreen)
                    button.Background = Brushes.LightSeaGreen;

                else
                    button.Background = Brushes.Transparent;

                SerialNumber.Add(button.Content.ToString());
                Movie.ReservePlace.Add(button.Content.ToString());
            });
            CheckOut();
            SelectedParkCinema();
        }

        public void CheckOut()
        {

            CheckOutCommand = new RelayCommand((e) =>
            {
                TicketNumber = Count.ToString() + " Ticket" + " Row:";

                foreach (var item in SerialNumber)
                {
                    TicketNumber += item + "/";
                }

                Movies.Add(Movie);
                FileHelper.WriteMovie(Movies);
            });
        }


        public void SelectedParkCinema()
        {
            ParkCinemaSelectedCommand = new RelayCommand((e) =>
            {
                var moviesData = FileHelper.ReadMovies();
                if (App.ParkCinema.IsEnabled == true && App.TwoSentyabr.IsEnabled == true && App.Aftermoon.IsEnabled == true)
                {
                    Movie.Location = App.ParkCinema.Content.ToString();
                    Movie.DateTIme = App.TwoSentyabr.Content.ToString();
                    Movie.TIme = App.Aftermoon.Content.ToString();
                }
                foreach (var item in moviesData)
                {
                    if (item.Name==Movie.Name && item.Location!=Movie.Location && item.DateTIme!=Movie.DateTIme && item.TIme != Movie.TIme)
                    {
                        foreach (var grid in App.MyUniformGrid.Children)
                        {
                            var btn = grid as Button;
                            if (btn.Background == Brushes.Black)
                            {
                                btn.IsEnabled = true;
                                btn.Background = Brushes.Transparent;
                            }
                        }
                    }
                }
            });
        }

        public void BackButton()
        {
            BackCommand = new RelayCommand((e) =>
            {

            });
        }
    }
}
