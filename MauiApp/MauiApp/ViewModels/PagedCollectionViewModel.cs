using MauiBeyond.Models;
using MauiBeyond.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            LoadList();

            //var result = FilePicker.Default.PickAsync();
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
            Device.BeginInvokeOnMainThread(() =>
            {
                GetMoreData();
            });
        }

        private ICommand _MoreDataCommand;

        public ICommand MoreDataCommand
        {
            get { return _MoreDataCommand??= new Command(GetMoreData); }
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
    }
}
