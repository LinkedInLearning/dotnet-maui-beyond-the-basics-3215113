using MauiBeyond.Services;
using System.Collections.ObjectModel;

namespace MauiBeyond.ViewModels
{
    public class PagedCollectionViewModel : BaseViewModel
    {
        private NamesService _namesService;
        private IEnumerable<string> _namesData;

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
                foreach (var name in _namesData)
                {
                    Names.Add(name);
                }
            }
        }
    }
}
