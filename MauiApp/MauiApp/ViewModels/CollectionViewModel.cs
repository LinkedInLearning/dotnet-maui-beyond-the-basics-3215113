using MauiBeyond.Models;
using System.Collections.ObjectModel;

namespace MauiBeyond.ViewModels
{
    public class CollectionViewModel : BaseViewModel
    {
        public CollectionViewModel()
        {
            LoadList();
        }

        private ObservableCollection<FlexListItem> _listItems = new ObservableCollection<FlexListItem>();

        public ObservableCollection<FlexListItem> ListItems
        {
            get { return _listItems; }
            private set 
            {
                if (_listItems != value)
                {
                    _listItems = value;
                    OnPropertyChanged(nameof(ListItems));
                }
            }
        }

        public string TeamName
        {
            get { return "My Project Team"; }
        }

        public string CompanyName
        {
            get { return "LinkedIn Learning"; }
        }

        private void LoadList()
        {
            ListItems.Add(new FlexListItem
            {
                Name = "Aaron Otis",
                Title = "Dev Lead"
            });
            ListItems.Add(new FlexListItem
            {
                Name = "Reed Martins",
                Title = "Designer"
            });
            ListItems.Add(new FlexListItem
            {
                Name = "Mary Montgomery",
                Title = "Architect"
            });
            ListItems.Add(new FlexListItem
            {
                Name = "Brad Billings",
                Title = "Developer"
            });
            ListItems.Add(new FlexListItem
            {
                Name = "Tosha Terrance",
                Title = "Developer"
            });
            ListItems.Add(new FlexListItem
            {
                Name = "Regina Price",
                Title = "Developer"
            });
            ListItems.Add(new FlexListItem
            {
                Name = "Lewis Rodrigez",
                Title = "QA"
            });
        }
    }
}
