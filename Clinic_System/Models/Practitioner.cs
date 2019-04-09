using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_System.Models
{
    public class Practitioner
    {
        public int PractitionerID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string ContactNo { get; set; }

        public ICollection<Appointment> Appointment { get; set; }
    }
}
