using MauiBeyond.Interfaces;
using MauiBeyond.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiBeyond.ViewModels
{
    public class MainViewModel : BaseViewModel, IQueryAttributable
    {
        private IContactService _contactService;

        public MainViewModel(IContactService contactService)
        {
            _contactService = contactService;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            LoadContactItems();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        private ObservableCollection<ContactItem> _ContactItems = new ObservableCollection<ContactItem>();
        public ObservableCollection<ContactItem> ContactItems
        {
            get => _ContactItems;
            set
            {
                if (_ContactItems != value)
                {
                    _ContactItems = value;
                    OnPropertyChanged(nameof(ContactItems));
                }
            }
        }

        public async Task LoadContactItems()
        {
            var contacts = await _contactService.GetContactList();

            foreach (var contactItem in contacts)
            {
                ContactItems.Add(contactItem);
            }
        }

        public bool CanDeleteContacts
        {
            get => ContactItems.Count > 1;
        }

        private ICommand _DeleteContactCommand;
        public ICommand DeleteContactCommand
        {
            get { return _DeleteContactCommand ??= new Command<ContactItem>((contactItem) => DeleteContactItem(contactItem)); }
        }

        private void DeleteContactItem(ContactItem contactItem)
        {
            if (ContactItems.Contains(contactItem) && CanDeleteContacts)
            {
                ContactItems.Remove(contactItem);
                OnPropertyChanged(nameof(CanDeleteContacts));
            }
        }

        private ICommand _AddOrUpdateContactCommand;
        public ICommand AddAddressCommand
        {
            get { return _AddOrUpdateContactCommand ??= new Command<ContactItem>((contactItem) => AddOrUpdateContact(contactItem)); }
        }

        private void AddOrUpdateContact(ContactItem contactItem)
        {
            if (!ContactItems.Any(a => a.Id == contactItem.Id))
            {
                ContactItems.Add(contactItem);
            }
            else
            {
                var index = ContactItems.IndexOf(ContactItems.Single(c => c.Id == contactItem.Id));
                ContactItems.Remove(contactItem);
                ContactItems.Insert(index, contactItem);
            }
            OnPropertyChanged(nameof(CanDeleteContacts));
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.Any(q => q.Key == AppShell.CONTACT_PARAMETER))
            {
                var contact = query[AppShell.CONTACT_PARAMETER] as Models.Contact;
                if (contact != null)
                {
                    var contactItem = new ContactItem
                    {
                        Id = contact.Id,
                        Name = contact.Name,
                    };
                    AddOrUpdateContact(contactItem);
                    OnPropertyChanged(nameof(ContactItems));
                }
            }
        }
    }
}
