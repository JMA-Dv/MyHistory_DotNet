using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHistory.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // This means if this has no value set before will be set to new guid
        public string FirstName { get; set; } = null;
        public string LastName { get; set; } = null;
        public DateTime DateOfBirth { get; set; }


        public string Email { get; set; } = null;
        public string Password { get; set; } = null;
    }
}
