using MauiBeyond.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiBeyond.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

        public MainViewModel()
        {
            Addresses.Add(new Address
            {
                Address1 = "221b Baker Street",
                City = "London",
                PostalCode = "NW1 6XE"
            });
            Addresses.Add(new Address
            {
                Address1 = "704 Hauser St.",
                City = "New York",
                State = "NY"
            });
            Addresses.Add(new Address
            {
                Address1 = "322 Maple St.",
                City = "Mayberry",
                State = "NC"
            });
        }

        private ObservableCollection<Address> _Addresses = new ObservableCollection<Address>();
        public ObservableCollection<Address> Addresses
        {
            get => _Addresses;
            set
            {
                if (_Addresses != value)
                {
                    _Addresses = value;
                    OnPropertyChanged(nameof(Addresses));
                }
            }
        }

        public bool CanDeleteAddresses
        {
            get => Addresses.Count > 1;
        }

        private ICommand _DeleteAddressCommand;
        public ICommand DeleteAddressCommand
        {
            get { return _DeleteAddressCommand ??= new Command<Address>((address) => DeleteAddress(address)); }
        }

        private void DeleteAddress(Address address)
        {
            if (Addresses.Contains(address) && CanDeleteAddresses)
            {
                Addresses.Remove(address);
            }
        }
    }
}
