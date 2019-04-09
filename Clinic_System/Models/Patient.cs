﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_System.Models
{
    public class Patient
    {
        public int PatientID { get; set; }
        public string PatientFirstname { get; set; }
        public string PatientLastname { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<Appointment> Appointment { get; set; }
    }
}
