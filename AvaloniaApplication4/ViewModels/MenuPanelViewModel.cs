using CommunityToolkit.Mvvm.Input;
using System;

namespace AvaloniaApplication4.ViewModels
{
    public class MenuPanelViewModel
    {
        public IRelayCommand FileCommand => new RelayCommand(() => Console.WriteLine("This is File button!"));
        public IRelayCommand EditCommand => new RelayCommand(() => Console.WriteLine("This is Edit button!"));
        public IRelayCommand ProjectCommand => new RelayCommand(() => Console.WriteLine("This is Project button!"));
        public IRelayCommand IsoftCommand => new RelayCommand(() => Console.WriteLine("This is Isoft button!"));
        public IRelayCommand WindowCommand => new RelayCommand(() => Console.WriteLine("This is Window button!"));
        public IRelayCommand HelpCommand => new RelayCommand(() => Console.WriteLine("This is Help button!"));
    }
}