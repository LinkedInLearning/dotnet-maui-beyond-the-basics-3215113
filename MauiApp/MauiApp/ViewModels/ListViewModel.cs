using MauiBeyond.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBeyond.ViewModels
{
    public class ListViewModel : BaseViewModel
    {
        private NamesService _namesService;
        private IEnumerable<string> _namesData;
        private int _currentPosition = 0;
        private const int PAGE_SIZE = 100;

        public ListViewModel(NamesService namesService)
        {
            _namesService = namesService;
            LoadList();
        }

        private IEnumerable<string> _names;

        public IEnumerable<string> Names
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
            Names = await _namesService.GetNamesEnumerable();
        }
    }
}
