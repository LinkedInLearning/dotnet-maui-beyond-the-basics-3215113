using MauiBeyond.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace MauiBeyond.ViewModels
{
    public class CollectionViewModel : BaseViewModel
    {
        public CollectionViewModel()
        {
            LoadList();
        }

        private ObservableCollection<ListItemGroup> _listItemGroups = new ObservableCollection<ListItemGroup>();

        public ObservableCollection<ListItemGroup> ListItemGroups
        {
            get { return _listItemGroups; }
            private set
            {
                if (_listItemGroups != value)
                {
                    _listItemGroups = value;
                    OnPropertyChanged(nameof(ListItemGroups));
                }
            }
        }

        private void LoadList()
        {
            ListItemGroups = new ObservableCollection<ListItemGroup>(RetrieveListItems());
        }

        // Simulate call to retrieve data items
        private List<ListItemGroup> RetrieveListItems()
        {
            var returnValue = new List<ListItemGroup>();

            var group = new ListItemGroup
            {
                Category = "Leadership",
                Location = "Remote"
            };
            group.Add(new ListItem
            {
                Name = "Aaron Otis",
                Title = "Dev Lead",
            });
            group.Add(new ListItem
            {
                Name = "Reed Martins",
                Title = "Designer"
            });
            group.Add(new ListItem
            {
                Name = "Mary Montgomery",
                Title = "Architect"
            });
            returnValue.Add(group);
            group = new ListItemGroup
            {
                Category = "Developers",
                Location = "Manila",
            };

            group.Add(new ListItem
            {
                Name = "Brad Billings",
                Title = "Developer"
            });
            group.Add(new ListItem
            {
                Name = "Tosha Terrance",
                Title = "Developer"
            });
            group.Add(new ListItem
            {
                Name = "Regina Price",
                Title = "Developer"
            });
            returnValue.Add(group);
            group = new ListItemGroup
            {
                Category = "QA",
                Location = "Mumbai"
            };
            group.Add(new ListItem
            {
                Name = "Lewis Rodrigez",
                Title = "QA Engineer"
            });
            returnValue.Add(group);

            return returnValue;
        }
    }
}