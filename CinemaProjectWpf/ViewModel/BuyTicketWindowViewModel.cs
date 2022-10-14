using CinemaProjectWpf.Command;
using CinemaProjectWpf.Helper;
using CinemaProjectWpf.Model;
using CinemaProjectWpf.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        public List<Movie> Movies { get; set; }=new List<Movie>();
        public RelayCommand RowButoonCommand { get; set; }
        public RelayCommand CheckOutCommand { get; set; }
        public RelayCommand MetroParkSelectedCommand { get; set; }
        public RelayCommand SecondSelectedCommand { get; set; }
        public RelayCommand AftermoonCommand { get; set; }
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
                Movie.EmptyPlaces.Add(button.Content.ToString());
            });
            CheckOut();
            SelectedMetroPark();
            SelectedTwoSentyabr();
            SelectedAftermoon();
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

        public void SelectedAftermoon()
        {
            AftermoonCommand = new RelayCommand((e) =>
            {
                Movie.TIme = App.Aftermoon.Content.ToString();

            });
        }

        public void SelectedMetroPark()
        {
            MetroParkSelectedCommand = new RelayCommand((e) =>
            {
                Movie.Location = App.MetroPark.Content.ToString();
            });
        }

        public void SelectedTwoSentyabr()
        {
            SecondSelectedCommand = new RelayCommand((e) =>
            {
                Movie.DateTIme = App.TwoSentyabr.Content.ToString();
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
