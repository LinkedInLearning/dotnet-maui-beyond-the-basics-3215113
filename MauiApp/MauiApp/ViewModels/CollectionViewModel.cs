using MauiBeyond.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace MauiBeyond.ViewModels
{
    public class CollectionViewModel : BaseViewModel
    {
        private List<ListItemGroup> _retrievedItems;

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
            _retrievedItems = RetrieveListItems();
            ListItemGroups.Clear();
            foreach (var group in _retrievedItems)
            {
                ListItemGroups.Add(group.Clone());
            }
        }

        private ICommand _toggleGroupDisplayCommand;
        public ICommand ToggleGroupDisplay
        {
            get
            {
                return _toggleGroupDisplayCommand ??= new Command<string>((string groupName) => { ToggleGroupVisibility(groupName); });
            }
        }

        private void ToggleGroupVisibility(string categoryName)
        {
            if (!string.IsNullOrEmpty(categoryName) && ListItemGroups != null &&
                _retrievedItems != null)
            {
                var displayGroup = ListItemGroups.SingleOrDefault(g => g.Category == categoryName);
                var sourceGroup = _retrievedItems.SingleOrDefault(g => g.Category == categoryName);
                if (displayGroup != null && sourceGroup != null)
                {
                    if (displayGroup.Any())
                    {
                        displayGroup.Clear();
                    }
                    else if (sourceGroup.Any())
                    {
                        foreach (var item in sourceGroup)
                        {
                            displayGroup.Add(item);
                        }
                    }
                }
            }
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