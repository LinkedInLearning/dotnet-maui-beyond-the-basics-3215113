using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiBeyond.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

        public MainViewModel()
        {
        }
        
        private string _someXML = "<MyNode>value I want</MyNode>";

        public string SomeXML
        {
            get => _someXML;
            set
            {
                if (_someXML != value)
                {
                    _someXML = value;
                    OnPropertyChanged(nameof(SomeXML));
                }
            }
        }
    }
}
