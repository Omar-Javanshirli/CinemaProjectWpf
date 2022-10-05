using CinemaProjectWpf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CinemaProjectWpf.Repository
{
    public class FakeRepo
    {
        public List<MenuButtonClass> GetAllButton()
        {
            return new List<MenuButtonClass>
            {
                new MenuButtonClass
                {
                    Image="/Image/Home.png",
                    Text="Home"
                },

                new MenuButtonClass
                {
                    Image="/Image/favorite.png",
                    Text="Favorite"
                },

                new MenuButtonClass
                {
                    Image="/Image/purchase.png",
                    Text="Purchase"
                },
                new MenuButtonClass
                {
                    Image="/Image/reminder2.png",
                    Text="Reminder"
                },
                new MenuButtonClass
                {
                    Image="/Image/playlist.png",
                    Text="Palylist"
                },
                new MenuButtonClass
                {
                    Image="/Image/live.png",
                    Text="Live"
                },
                new MenuButtonClass
                {
                    Image="/Image/bookmarks.png",
                    Text="Bookmarks"
                },
                new MenuButtonClass
                {
                    Image="/Image/setting.png",
                    Text="Setting"
                }
            };
        }
        public List<Movie> GetAllMovie()
        {
            return new List<Movie>
            {
                new Movie
                {
                    Name="La Casa De Papel",
                    Description="Action,Violence",
                    Reyting="8.5",
                    ImagePath="/Image/laCaseDePapel.jpg"
                }, 
                new Movie
                {
                    Name="Ozark",
                    Description="Violence,Action,Matter",
                    Reyting="7.4",
                    ImagePath="/Image/ozark2.jpg"
                },
                new Movie
                {
                    Name="Lupin",
                    Description="Action",
                    Reyting="7.7",
                    ImagePath="/Image/lupin.jpg"
                },
                new Movie
                {
                    Name="Elite",
                    Description="Matter,Vieolence",
                    Reyting="8.0",
                    ImagePath="/Image/elite.jpg"
                },
                new Movie
                {
                    Name="MindHunter",
                    Description="Series Killer,Matter",
                    Reyting="6.5",
                    ImagePath="/Image/mindhunter.jpg"
                },
                new Movie
                {
                    Name="Narcos",
                    Description="Action,Matter",
                    Reyting="9.0",
                    ImagePath="/Image/narcos.png"
                },
                new Movie
                {
                    Name="Visa A Vis",
                    Description="Matter,Vieolence",
                    Reyting="7.5",
                    ImagePath="/Image/visaAvis.jpg"
                },
                new Movie
                {
                    Name="Breaking Bad",
                    Description="Matter,action",
                    Reyting="8,4",
                    ImagePath="/Image/breaking.jpg"
                },
                new Movie
                {
                    Name="Adam Project",
                    Description="Dram,Action",
                    Reyting="6.7",
                    ImagePath="/Image/adam.jpg"
                },
                new Movie
                {
                    Name="The Rain",
                    Description="Action,Advantures",
                    Reyting="7.7",
                    ImagePath="/Image/rain2.jpg"
                }
            };
        }
    }
}
