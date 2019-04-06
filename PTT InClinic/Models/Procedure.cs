using System;
using System.Collections.Generic;

namespace PTT_InClinic.Models
{
    public class Procedure
    {
        public int ProcedureID { get; set; }
        public int PractitionerID { get; set; }
        public int PatientID { get; set; }
        public DateTime ProcedureDate{ get; set; }
        public string Medication { get; set; }
        public DateTime FollowupDate { get; set; }
        public string Complication { get; set; }
        public string ProcedureUsed { get; set; }
        
        Practitioner Practitioner { get; set; }
        Patient Patient { get; set; }
    }
}