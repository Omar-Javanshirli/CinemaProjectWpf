using CinemaProjectWpf.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CinemaProjectWpf.View
{
    /// <summary>
    /// Interaction logic for BuyTicketWindow.xaml
    /// </summary>
    public partial class BuyTicketWindow : Window
    {
        public BuyTicketWindow()
        {
            InitializeComponent();

            var vm = new BuyTicketWindowViewModel();
            this.DataContext = vm;
            App.MyUniformGrid = myUniform;
            App.MetroPark = metropark;
            App.TwoSentyabr = twoSentyabr;
            App.Aftermoon = aftermoon;
        }

    }
}
