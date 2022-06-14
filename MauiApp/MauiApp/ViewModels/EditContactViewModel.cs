using MauiBeyond.Interfaces;
using System.Windows.Input;

namespace MauiBeyond.ViewModels
{
    public class EditContactViewModel : BaseViewModel, IQueryAttributable
    {
        private Models.Contact _contact;
        private IContactService _contactService;

        public EditContactViewModel(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Guid contactId;
            if (query.Any(q => q.Key == AppShell.CONTACT_ID_PARAMETER))
            {
                contactId = new Guid(query[AppShell.CONTACT_ID_PARAMETER] as string);

                Contact = await _contactService.GetContact(contactId);

                ImageData = await _contactService.GetContactImage(contactId);
            }
            else
            {
                Contact = new Models.Contact
                {
                    Id = Guid.NewGuid()
                };
            }
        }

        private ICommand _SaveContactCommand;
        public ICommand SaveContactCommand
        {
            get { return _SaveContactCommand ??= new Command(() => SaveContact()); }
        }

        private void SaveContact()
        {
            if (Contact != null)
            {
                var navigationParameters = new Dictionary<string, object>
                {
                    { AppShell.CONTACT_PARAMETER, _contact }
                };

                Shell.Current.GoToAsync("..", true, navigationParameters);
            }
        }

        public Models.Contact Contact
        {
            get => _contact;
            set
            {
                if (_contact != value)
                {
                    _contact = value;
                    OnPropertyChanged(nameof(Contact));
                }
            }
        }

        private byte[] _ImageData;
        public byte[] ImageData
        {
            get => _ImageData;
            set
            {
                _ImageData = value;
                OnPropertyChanged(nameof(ImageData));
            }
        }
    }
}
