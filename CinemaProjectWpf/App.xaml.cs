using CinemaProjectWpf.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace CinemaProjectWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static UniformGrid MyUniformGrid;
        public static List<Movie> Movies { get; set; }
        public App()
        {

        }
    }
}
