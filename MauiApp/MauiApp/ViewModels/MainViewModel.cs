using MauiBeyond.Interfaces;
using MauiBeyond.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiBeyond.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private IAddressService _addressService;

        public MainViewModel(IAddressService addressService)
        {
            _addressService = addressService;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            LoadAddress();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
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
            get { return _LoadAddressCommand ??= new Command(async () => await LoadAddress()); }
        }

        public async Task LoadAddress()
        {
            Address = await _addressService.GetAddress(Guid.NewGuid());  // For our test service, the Guid doesn't matter 
        }
    }
}
