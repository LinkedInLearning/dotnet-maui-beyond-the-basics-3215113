using MauiBeyond.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiBeyond.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

        public MainViewModel()
        {
            LoadAddress();
        }

        private Address _Address;
        public Address Address
        {
            get => _Address;
            private set
            {
                if (_Address != value)
                {
                    _Address = value;
                    OnPropertyChanged(nameof(Address));
                }
            }
        }

        private ICommand _LoadAddressCommand;
        public ICommand LoadAddressCommand
        {
            get { return _LoadAddressCommand ??= new Command(() => LoadAddress()); }
        }

        public void LoadAddress()
        {
            Address = new Address();
        }
    }
}
