using MauiBeyond.Interfaces;
using MauiBeyond.Models;

namespace MauiBeyond.Services
{
    public class AddressService : IAddressService
    {
        public Task<Address> GetAddress(Guid addressId)
        {
            var random = new Random();
            var tcs = new TaskCompletionSource<Address>();

            var randomNumber = random.Next(100);

            if (randomNumber > 20)
            {
                tcs.SetResult(new Address
                {
                    Id = addressId,
                    Address1 = "221B Baker St.",
                    Address2 = "Attn: S. Holmes",
                    City = "London",
                    PostalCode = "NW1 6XE"
                });
            }
            else
            {
                tcs.SetResult(null);
            }

            return tcs.Task;
        }
    }
}
