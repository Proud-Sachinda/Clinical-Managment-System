using System;
using System.Collections.Generic;

namespace PTT_InClinic.Models
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public int AdministratorID { get; set; }
        public int PractitionerID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AppointmentDescr { get; set; }

        //public ICollection<Enrollment> Enrollments { get; set; }
        Practitioner Practitioner { get; set; }
        Patient Patient { get; set; }
        Administrator Administrator { get; set; }
    }
}