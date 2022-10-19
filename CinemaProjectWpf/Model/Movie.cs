﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProjectWpf.Model
{
    public class Movie
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string Reyting { get; set; }
        public string Genre { get; set; }
        public string Duration { get; set; }
        public List<Location> Locations { get; set; }
    }

}
