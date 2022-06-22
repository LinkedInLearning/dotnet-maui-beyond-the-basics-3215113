using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiBeyond.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

        public MainViewModel()
        {
        }

        private bool _ImageRequired = false;

        public bool ImageRequired
        {
            get => _ImageRequired;
            set
            {
                if (_ImageRequired != value)
                {
                    _ImageRequired = value;
                    OnPropertyChanged(nameof(ImageRequired));
                }
            }
        }

        private ICommand _ToggleImageRequiredCommand;
        public ICommand ToggleImageRequiredCommand
        {
            get
            {
                return _ToggleImageRequiredCommand ??= new Command(() => { 
                    ImageRequired = !ImageRequired; 
                });
            }
        }
    }
}
