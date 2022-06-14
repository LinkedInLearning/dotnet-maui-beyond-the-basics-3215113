using MauiBeyond.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBeyond.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<ContactItem>> GetContactList();

        Task<Models.Contact> GetContact(Guid contactId);

        Task<byte[]> GetContactImage(Guid contactId);
    }
}
