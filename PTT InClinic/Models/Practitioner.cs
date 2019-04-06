using System;
using System.Collections.Generic;

namespace PTT_InClinic.Models
{
    public class Practitioner
    {
        public int PractitionerID{ get; set; }
        public string Username{ get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string ContactNo { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Procedure> Procedures { get; set; }
    }
}