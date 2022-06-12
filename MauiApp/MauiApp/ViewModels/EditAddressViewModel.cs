using MauiBeyond.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiBeyond.ViewModels
{
    public class EditAddressViewModel : BaseViewModel, IQueryAttributable
    {
        private Address _address;

        private string _address1;
        public string Address1 
        {
            get => _address1;
            set
            {
                if (_address1 != value)
                {
                    _address1 = value;
                    OnPropertyChanged(nameof(Address1));
                }
            }
        }

        private string _address2;
        public string Address2
        {
            get => _address2;
            set
            {
                if (_address2 != value)
                {
                    _address2 = value;
                    OnPropertyChanged(nameof(Address2));
                }
            }
        }

        private string _city;
        public string City
        {
            get => _city;
            set
            {
                if (_city != value)
                {
                    _city = value;
                    OnPropertyChanged(nameof(City));
                }
            }
        }

        private string _state;
        public string State
        {
            get => _state;
            set
            {
                if (_state != value)
                {
                    _state = value;
                    OnPropertyChanged(nameof(State));
                }
            }
        }

        private string _postalCode;
        public string PostalCode
        {
            get => _postalCode;
            set
            {
                if (_postalCode != value)
                {
                    _postalCode = value;
                    OnPropertyChanged(nameof(PostalCode));
                }
            }
        }

        public bool IsValid
        {
            get
            {
                return !string.IsNullOrEmpty(State) || !string.IsNullOrEmpty(PostalCode);
            }
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.Any(q => q.Key == AppShell.ADDRESS_PARAMETER))
            {
                _address = query[AppShell.ADDRESS_PARAMETER] as Address;
                OnPropertyChanged(nameof(Address1));
            }
            else
            {
                _address = new Address
                {
                    Id = Guid.NewGuid()
                };
            }

            Address1 = _address.Address1;
            Address2 = _address.Address2;
            City = _address.City;
            State = _address.State;
            PostalCode = _address.PostalCode;
        }

        private ICommand _SaveAddressCommand;
        public ICommand SaveAddressCommand
        {
            get { return _SaveAddressCommand ??= new Command<Address>((address) => SaveAddress(address)); }
        }

        private void SaveAddress(Address address)
        {
            if (IsValid)
            {
                _address.Address1 = Address1;
                _address.Address2 = Address2;
                _address.City = City;
                _address.State = State;
                _address.PostalCode = PostalCode;

                var navigationParameters = new Dictionary<string, object>
                {
                    { AppShell.ADDRESS_PARAMETER, _address }
                };

                Shell.Current.GoToAsync("..", true, navigationParameters);
            }
        }
    }
}
