using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiBeyond.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

        public MainViewModel()
        {
            ValidateName();
        }

        private bool _IsNameValid = false;

        public bool IsNameValid
        {
            get => _IsNameValid;
            private set
            {
                if (_IsNameValid != value)
                {
                    _IsNameValid = value;
                    OnPropertyChanged(nameof(IsNameValid));
                }
            }
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
                    ValidateName();
                }
            }
        }

        private void ValidateName()
        {
            IsNameValid = !(string.IsNullOrEmpty(_Name) || _Name.Length < 3 || _Name.Length > 30);
        }
    }
}
