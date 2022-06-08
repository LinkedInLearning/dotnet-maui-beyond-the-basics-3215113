using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiBeyond.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

        public MainViewModel()
        {
        }

        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        private string _namePrompt = "Employee Name:";

        public string NamePrompt
        {
            get => _namePrompt;
            set
            {
                if (_namePrompt != value)
                {
                    _namePrompt = value;
                    OnPropertyChanged(nameof(NamePrompt));
                }
            }
        }

    }
}
