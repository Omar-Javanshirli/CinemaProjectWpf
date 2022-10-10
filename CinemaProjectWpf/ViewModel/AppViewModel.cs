﻿using CinemaProjectWpf.Command;
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
using System.Windows.Input;
using System.Windows.Media;

namespace CinemaProjectWpf.ViewModel
{
    public class AppViewModel : BaseViewModel
    {
        public FakeRepo DataBase { get; set; }
        public ObservableCollection<MenuButtonClass> MenuButtons { get; set; }
        public ObservableCollection<Movie> Movies { get; set; }
        public MainWindow _mainWindow;

        public RelayCommand SearchMosueEnterCommand { get; set; }
        public RelayCommand SearchMosueLeaveCommand { get; set; }
        public RelayCommand SearchClickCommand { get; set; }
        public RelayCommand HollywoodCommand { get; set; }
        public RelayCommand NetflixCommand { get; set; }
        public RelayCommand BollywoodCommand { get; set; }
        public RelayCommand UniversalStudioCommand { get; set; }
        public RelayCommand PixarCommand { get; set; }
        public RelayCommand ViuCommand { get; set; }
        public RelayCommand DisneyCommand { get; set; }

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
                    label.Margin = new System.Windows.Thickness(35, 0, 0, 0);
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
            AddMovieAbout(Movies);
            MovieCommand();

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

        public void AddMovieAbout(ObservableCollection<Movie> m)
        {
            //0,4,6
            int count = 0;
            foreach (var item in m)
            {
                MovieAboutUcViewModel view = new MovieAboutUcViewModel();
                view.Movie = item;
                MovieAboutUC uc = new MovieAboutUC();
                uc.DataContext = view;

                if (count == 0)
                    _mainWindow.row1.Children.Add(uc);
                else if (count == 4)
                    _mainWindow.row2.Children.Add(uc);
                else if (count == 6)
                    _mainWindow.row3.Children.Add(uc);
                count++;
            }
        }
        
        public void MovieCommand()
        {

            HollywoodCommand = new RelayCommand((e) =>
              {
                  DataBase = new FakeRepo();
                  Movies = new ObservableCollection<Movie>(DataBase.GetAllHollywoodMovie());
                  _mainWindow.filmWrap.Children.RemoveRange(0, 5);
                  _mainWindow.filmWrap2.Children.RemoveRange(0, 5);
                  int count = 0;

                  foreach (var item in Movies)
                  {
                      var view = new MovieCellViewModel
                      {
                          Movie = item
                      };
                      var uc = new MovieCellUc();
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
              });


            DisneyCommand = new RelayCommand((e) =>
            {
                DataBase = new FakeRepo();
                Movies = new ObservableCollection<Movie>(DataBase.GetAllDisneyMovie());

                _mainWindow.filmWrap.Children.RemoveRange(0, 5);
                _mainWindow.filmWrap2.Children.RemoveRange(0, 5);
                int count = 0;

                foreach (var item in Movies)
                {
                    var view = new MovieCellViewModel
                    {
                        Movie = item
                    };
                    var uc = new MovieCellUc();
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
            });
        }

        private RelayCommand command;

        public ICommand Command
        {
            get
            {
                if (command == null)
                {
                    command = new RelayCommand(PerformCommand);
                }

                return command;
            }
        }

        private void PerformCommand(object commandParameter)
        {
        }


    }
}
