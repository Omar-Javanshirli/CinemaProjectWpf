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
        public static ComboBoxItem MetroPark;
        public static ComboBoxItem ParkCinema;
        public static ComboBoxItem TwoSentyabr;
        public static ComboBoxItem ForthSentyabr;
        public static ComboBoxItem Aftermoon;
        public static ComboBoxItem Evning;

        public static ComboBox Location;
        public static ComboBox DateTime;
        public static ComboBox Time;
    }
}
