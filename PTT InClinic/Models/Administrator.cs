using System;
using System.Collections.Generic;

namespace PTT_InClinic.Models
{
    public class Administrator
    {
       
        public int AdministratorID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

    }
}