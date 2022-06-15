using MauiBeyond.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBeyond.Interfaces
{
    public interface IAddressService
    {
        Task<Address> GetAddress(Guid addressId);

    }
}
