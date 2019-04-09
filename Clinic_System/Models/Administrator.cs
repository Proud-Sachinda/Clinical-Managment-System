using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_System.Models
{
    public class Administrator
    {
        public int AdministratorID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<Appointment> Appointment { get; set; }
    }
}
