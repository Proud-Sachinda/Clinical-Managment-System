using System;
using System.Collections.Generic;

namespace PTT_InClinic.Models
{
    public class Patient
    {
        public int PatientID { get; set; }
        //public int AppointmentID { get; set; }
       // public int ProcedureID { get; set; }
        public string PatientFirstname { get; set; }
        public string PatientLastname { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Username{ get; set; }
        public string Password { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Procedure> Procedures { get; set; }
    }
}