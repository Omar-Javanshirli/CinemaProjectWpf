﻿using CinemaProjectWpf.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CinemaProjectWpf.UserContorls
{
    /// <summary>
    /// Interaction logic for MovieCellUc.xaml
    /// </summary>
    public partial class MovieCellUc : UserControl
    {
        public MovieCellUc()
        {
            InitializeComponent();
            this.DataContext = new MovieCellViewModel();
        }
    }
}
