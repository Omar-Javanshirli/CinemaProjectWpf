﻿using CinemaProjectWpf.ViewModel;
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
            App.MyUniformGrid = myUniform;
            App.MetroPark = metropark;
            App.ParkCinema = parkCinema;
            App.TwoSentyabr = twoSentyabr;
            App.ForthSentyabr = forthSentyabr;
            App.Aftermoon = aftermoon;
            App.Evning = evning;

            App.Location = locationCombobox;
            App.DateTime = dateCombobox;
            App.Time = timeCombobx;
            this.DataContext = vm;
        }

    }
}
