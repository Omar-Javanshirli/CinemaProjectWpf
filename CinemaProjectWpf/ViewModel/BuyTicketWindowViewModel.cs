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
        public Movie Movie { get; set; }
        public RelayCommand RowButoonCommand { get; set; }
        public RelayCommand CheckOutCommand { get; set; }
        public UniformGrid UniformGrid { get; set; }

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
                MessageBox.Show("...");
            });

            RowButoonCommand = new RelayCommand((e) =>
            {
                var btn = e as Button;
                var button = GetButton(btn);

                button.Background = Brushes.Black;
            });
        }
    }
}
