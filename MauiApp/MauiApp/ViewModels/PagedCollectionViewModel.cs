using MauiBeyond.Models;
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
        private const int PAGE_SIZE = 200;

        public PagedCollectionViewModel(NamesService namesService)
        {
            _namesService = namesService;
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            LoadList();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        private ObservableCollection<NameList> _names = new ObservableCollection<NameList>();

        public ObservableCollection<NameList> Names
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
                Task.Run(() =>
                {
                    var dataToLoad = _namesData.Skip(_currentPosition).Take(PAGE_SIZE);

                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        foreach (var name in dataToLoad)
                        {
                            if (name.Length > 0)
                            {
                                if (!Names.Any(n => n.StartingLetter == name.Substring(0, 1)))
                                {
                                    var nameList = new NameList();
                                    nameList.StartingLetter = name.Substring(0, 1).ToUpper();
                                    Names.Add(nameList);
                                }
                                var nameListItem = new NameListItem();
                                nameListItem.Name = name;
                                Names.Single(n => n.StartingLetter == name.Substring(0, 1)).Add(nameListItem);
                            }
                            _currentPosition += 1;
                        }
                    });
                });
            }
        }

        private ICommand _MoreDataCommand;
        public ICommand MoreDataCommand
        {
            get { return _MoreDataCommand ??= new Command(GetMoreData); }
        }

    }
}
