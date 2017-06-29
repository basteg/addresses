using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Addresses.Models
{
    public class AddressesContext:DbContext
    {
        public DbSet<Address> Addresses { get; set; }

        public AddressesContext(DbContextOptions<AddressesContext> options): base(options)
        { }
    }
}
