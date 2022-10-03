using CinemaProjectWpf.Model;
using CinemaProjectWpf.Repository;
using CinemaProjectWpf.UserContorls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CinemaProjectWpf.ViewModel
{
    public class AppViewModel:BaseViewModel
    {
        public FakeRepo MenuButtonRepository { get; set; }
        public ObservableCollection<MenuButtonClass> MenuButtons { get; set; }
        public StackPanel MenuStackPanel { get; set; }
        

        public AppViewModel()
        {
            MenuButtonRepository = new FakeRepo();
            MenuButtons = new ObservableCollection<MenuButtonClass>(MenuButtonRepository.GetAllButton());

            foreach (var item in MenuButtons)
            {
                MenuButtonUcViewModel menuButtonUcViewModel = new MenuButtonUcViewModel();
                menuButtonUcViewModel.Menubutton = item;
                MenuButtonUc menuButtonUc = new MenuButtonUc();
                menuButtonUc.DataContext = menuButtonUcViewModel;

                MenuStackPanel.Children.Add(menuButtonUc);
            }
        }
    }
}
