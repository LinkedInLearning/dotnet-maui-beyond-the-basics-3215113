using MauiBeyond.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiBeyond.ViewModels
{
    public class MainViewModel : BaseViewModel, IQueryAttributable
    {

        public MainViewModel()
        {
            Addresses.Add(new Address
            {
                Id = Guid.NewGuid(),
                Address1 = "221b Baker Street",
                City = "London",
                PostalCode = "NW1 6XE"
            });
            Addresses.Add(new Address
            {
                Id = Guid.NewGuid(),
                Address1 = "704 Hauser St.",
                City = "New York",
                State = "NY"
            });
            Addresses.Add(new Address
            {
                Id = Guid.NewGuid(),
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
                OnPropertyChanged(nameof(CanDeleteAddresses));
            }
        }

        private ICommand _AddAddressCommand;
        public ICommand AddAddressCommand
        {
            get { return _AddAddressCommand ??= new Command<Address>((address) => AddOrUpdateAddress(address)); }
        }

        private void AddOrUpdateAddress(Address address)
        {
            if (!Addresses.Any(a => a.Id == address.Id))
            {
                Addresses.Add(address);
            }
            else
            {
                var index = Addresses.IndexOf(address);
                Addresses.Remove(address);
                Addresses.Insert(index, address);
            }
            OnPropertyChanged(nameof(CanDeleteAddresses));
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.Any(q => q.Key == AppShell.ADDRESS_PARAMETER))
            {
                var address = query[AppShell.ADDRESS_PARAMETER] as Address;
                if (address != null)
                {
                    AddOrUpdateAddress(address);
                    OnPropertyChanged(nameof(Addresses));
                }
            }
        }
    }
}
