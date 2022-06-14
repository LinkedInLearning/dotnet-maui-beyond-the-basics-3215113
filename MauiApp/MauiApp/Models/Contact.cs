using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBeyond.Models
{
    public class Contact
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Employer { get; set; }

        public List<Address> Addresses { get; private set; } = new List<Address>();
    }
}
