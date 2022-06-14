using MauiBeyond.Interfaces;
using MauiBeyond.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBeyond.Services
{
    public class ContactService : IContactService
    {
        public Task<Models.Contact> GetContact(Guid contactId)
        {
            // Simulate this call failing due to a network error, return a null.
            var tcs = new TaskCompletionSource<Models.Contact>();

            tcs.SetResult(null);
            return tcs.Task;
        }

        public Task<IEnumerable<ContactItem>> GetContactList()
        {
            // simulate this being the result of a successful network call

            var tcs = new TaskCompletionSource<IEnumerable<ContactItem>>();

            var returnValue = new List<ContactItem>();

            var contactItem = new ContactItem
            {
                Id = Guid.NewGuid(),
                Name = "Sherlock Holmes"
            };
            returnValue.Add(contactItem);

            contactItem = new ContactItem
            {
                Id = Guid.NewGuid(),
                Name = "Archie Bunker"
            };
            returnValue.Add(contactItem);
            contactItem = new ContactItem
            {
                Id = Guid.NewGuid(),
                Name = "Andy Griffith"
            };
            returnValue.Add(contactItem);

            tcs.SetResult(returnValue); 

            return tcs.Task;
        }

        public Task<byte[]> GetContactImage(Guid contactId)
        {
            var tcs = new TaskCompletionSource<byte[]>();

            tcs.SetResult(null);

            return tcs.Task;
        }
    }
}
