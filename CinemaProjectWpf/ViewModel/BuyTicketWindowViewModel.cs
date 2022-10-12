using CinemaProjectWpf.Command;
using CinemaProjectWpf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace CinemaProjectWpf.ViewModel
{
    public class BuyTicketWindowViewModel:BaseViewModel
    {

        private bool metroParkIsSelected;

        public bool MetroParkIsSelected
        {
            get { return metroParkIsSelected; }
            set { metroParkIsSelected = value; OnPropertyChanged(); }
        }



        public Movie Movie { get; set; }
        public RelayCommand RowButoonCommand { get; set; }
        public RelayCommand CheckOutCommand { get; set; }
        public RelayCommand MetroParkSelectedCommand { get; set; }
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
             
            CheckOutCommand = new RelayCommand((e) =>
            {
                TicketNumber = Count.ToString() + " Ticket" + " Row:";

                foreach (var item in SerialNumber)
                {
                    TicketNumber += item + "/";
                }
            });

            RowButoonCommand = new RelayCommand((e) =>
            {
                Count++;
                var btn = e as Button;
                var button = GetButton(btn);
                button.Background = Brushes.LightSeaGreen;
                SerialNumber.Add(button.Content.ToString());
            });
            SelectedMetroPark();
        }

        public void SelectedMetroPark()
        {
            MetroParkSelectedCommand = new RelayCommand((e) =>
              {
                  if (App.MetroPark.IsSelected==true && App.TwoSentyabr.IsSelected == true && App.Aftermoon.IsSelected == true)
                  {

                  }
              });
        }
    }
}
