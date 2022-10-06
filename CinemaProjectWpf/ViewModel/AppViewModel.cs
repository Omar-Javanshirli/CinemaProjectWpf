using CinemaProjectWpf.Command;
using CinemaProjectWpf.Model;
using CinemaProjectWpf.Repository;
using CinemaProjectWpf.Service;
using CinemaProjectWpf.UserContorls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CinemaProjectWpf.ViewModel
{
    public class AppViewModel:BaseViewModel
    {
        public FakeRepo DataBase { get; set; }
        public ObservableCollection<MenuButtonClass> MenuButtons { get; set; }
        public ObservableCollection<Movie> Movies { get; set; }
        public MainWindow _mainWindow;

        public RelayCommand SearchMosueEnterCommand { get; set; }
        public RelayCommand SearchMosueLeaveCommand { get; set; }
        public RelayCommand SearchClickCommand { get; set; }

        public AppViewModel(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            DataBase = new FakeRepo();
            MenuButtons = new ObservableCollection<MenuButtonClass>(DataBase.GetAllButton());
            Movies = new ObservableCollection<Movie>(DataBase.GetAllMovie());

            int count = 0;
            foreach (var item in MenuButtons)
            {
                MenuButtonUcViewModel menuButtonUcViewModel = new MenuButtonUcViewModel();
                menuButtonUcViewModel.MenuButton = item;
                MenuButtonUc menuButtonUc = new MenuButtonUc();
                menuButtonUc.DataContext = menuButtonUcViewModel;

                _mainWindow.menuButtonSp.Children.Add(menuButtonUc);
                count += 1;
                if (count == 4)
                {
                    Label label = new Label();
                    label.Content = "other";
                    label.Foreground = Brushes.LightGray;
                    label.Margin = new System.Windows.Thickness(35,0, 0, 0);
                    label.FontStyle = FontStyles.Italic;
                    label.FontFamily = new FontFamily("Verdana");
                    _mainWindow.menuButtonSp.Children.Add(label);

                }
            }

            count = 0;
            foreach (var item in Movies)
            {
                MovieCellViewModel view = new MovieCellViewModel();
                view.Movie = item;
                MovieCellUc uc = new MovieCellUc();
                uc.DataContext = view;

                if (count < 5)
                {
                    _mainWindow.filmWrap.Children.Add(uc);
                    count++;
                }
                else
                {
                    _mainWindow.filmWrap2.Children.Add(uc);
                }
            }

            CheckSearchCommand();
            SearchClick();
        }

        public void CheckSearchCommand()
        {
            SearchMosueEnterCommand = new RelayCommand((e) =>
            {
                if (_mainWindow.searchTb.Text == "Search...")
                    _mainWindow.searchTb.Text = String.Empty;
            });

            SearchMosueLeaveCommand = new RelayCommand((e) =>
            {
                if (_mainWindow.searchTb.Text == String.Empty)
                    _mainWindow.searchTb.Text = "Search...";
            });
        }

        public void SearchClick()
        {
            SearchClickCommand = new RelayCommand((e) =>
            {
                var movies = MovieService.GetMovies(_mainWindow.searchTb.Text);

                _mainWindow.filmWrap.Children.RemoveRange(0, 5);

                foreach (var m in movies)
                {
                    var ucVm = new MovieCellViewModel
                    {
                        Movie = m,
                    };

                    var uc = new MovieCellUc();
                    uc.DataContext = ucVm;

                    _mainWindow.filmWrap.Children.Add(uc);
                }

            });
        }

    }
}
