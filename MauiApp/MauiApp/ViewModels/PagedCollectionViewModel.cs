using MauiBeyond.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiBeyond.ViewModels
{
    public class PagedCollectionViewModel : BaseViewModel
    {
        private NamesService _namesService;
        private IEnumerable<string> _namesData;
        private int _currentPosition = 0;
        private const int PAGE_SIZE = 100;

        public PagedCollectionViewModel(NamesService namesService)
        {
            _namesService = namesService;
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            LoadList();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        private ObservableCollection<string> _names = new ObservableCollection<string>();

        public ObservableCollection<string> Names
        {
            get { return _names; }
            private set 
            {
                if (_names != value)
                {
                    _names = value;
                    OnPropertyChanged(nameof(Names));
                }
            }
        }

        private async Task LoadList()
        {
            _namesData = await _namesService.GetNamesEnumerable();
            MainThread.BeginInvokeOnMainThread(() =>
            {
                GetMoreData();
            });
        }

        private void GetMoreData()
        {
            if (_namesData != null)
            {
                var dataToLoad = _namesData.Skip(_currentPosition).Take(PAGE_SIZE);

                foreach (var name in dataToLoad)
                {
                    Names.Add(name);
                    _currentPosition += 1;
                }
            }
        }

        private ICommand _MoreDataCommand;
        public ICommand MoreDataCommand
        {
            get { return _MoreDataCommand ??= new Command(GetMoreData); }
        }

    }
}
