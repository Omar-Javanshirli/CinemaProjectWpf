using CinemaProjectWpf.Command;
using CinemaProjectWpf.Helper;
using CinemaProjectWpf.Model;
using CinemaProjectWpf.Repository;
using CinemaProjectWpf.UserContorls;
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

        public RelayCommand RowButoonCommand { get; set; }
        public RelayCommand CheckOutCommand { get; set; }
        public RelayCommand CinemaSelectedCommand { get; set; }
        public RelayCommand DateSelectedCommand { get; set; }
        public RelayCommand TimeSelectedCommand { get; set; }
        public RelayCommand BackCommand { get; set; }
        public List<string> SerialNumber { get; set; } = new List<string>();

        private Location selectedLocation;

        public Location SelectedLocation
        {
            get { return selectedLocation; }
            set { selectedLocation = value; OnPropertyChanged(); }
        }


        private Date selectedDate;

        public Date SelectedDate
        {
            get { return selectedDate; }
            set { selectedDate = value; OnPropertyChanged(); }
        }


        private Time selectedTime;

        public Time SelectedTime
        {
            get { return selectedTime; }
            set { selectedTime = value; OnPropertyChanged(); }
        }



        public int Count { get; set; } = 0;

        private string ticketNumber;

        public string TicketNumber
        {
            get { return ticketNumber; }
            set { ticketNumber = value; OnPropertyChanged(); }
        }

        public List<Movie> Movies { get; set; }

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
               // Movie.ReservePlace.Add(button.Content.ToString());
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

              //  Movies.Add(Movie);
                FileHelper.WriteMovie(Movies.ToList());
            });
        }


        public void SelectedParkCinema()
        {
            CinemaSelectedCommand = new RelayCommand((e) =>
            {
                SelectedLocation=e as Location;
            });

            DateSelectedCommand = new RelayCommand((e) =>
              {
                  SelectedDate=e as Date;   
              });


            TimeSelectedCommand = new RelayCommand((e) =>
            {
                selectedTime=e as Time;
                var seats = selectedTime.Seats;
                if (seats == null)
                {
                    seats=new List<Seat>();
                
                for (int i = 0; i < selectedTime.SeatCount; i++)
                {
                    seats.Add(new Seat() { No=(i+1).ToString() , Case= SeatCase.Empty});
                    var viewModel = new SeatViewModel
                    {
                        Seat = seats[i]
                    };
                    var uc = new SeatUC();
                    uc.DataContext= viewModel;
                    App.MyUniformGrid.Children.Add(uc);
                }
                FileHelper.WriteMovie(Movies.ToList());
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
