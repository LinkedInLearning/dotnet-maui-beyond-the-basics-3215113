using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiBeyond.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

        public MainViewModel()
        {
        }

        private string _Name = String.Empty;
        public string Name
        {
            get => _Name;
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        private string _Address1 = String.Empty;
        public string Address1
        {
            get => _Address1;
            set
            {
                if (_Address1 != value)
                {
                    _Address1 = value;
                    OnPropertyChanged(nameof(Address1));
                }
            }
        }


        private string _Address2 = String.Empty;
        public string Address2
        {
            get => _Address2;
            set
            {
                if (_Address2 != value)
                {
                    _Address2 = value;
                    OnPropertyChanged(nameof(Address2));
                }
            }
        }

        private string _City = String.Empty;
        public string City
        {
            get => _City;
            set
            {
                if (_City != value)
                {
                    _City = value;
                    OnPropertyChanged(nameof(City));
                }
            }
        }

        private string _State = String.Empty;
        public string State
        {
            get => _State;
            set
            {
                if (_State != value)
                {
                    _State = value;
                    OnPropertyChanged(nameof(State));
                }
            }
        }

        private string _PostalCode = String.Empty;
        public string PostalCode
        {
            get => _PostalCode;
            set
            {
                if (_PostalCode != value)
                {
                    _PostalCode = value;
                    OnPropertyChanged(nameof(PostalCode));
                }
            }
        }

    }
}
