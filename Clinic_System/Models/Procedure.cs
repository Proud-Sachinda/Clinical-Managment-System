using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_System.Models
{
    public class Procedure
    {
        public int ProcedureID { get; set; }
        public int PractitionerID { get; set; }
        public int PatientID { get; set; }
        public string Medication { get; set; }
        public string Complication { get; set; }
        public string ProcedureUsed { get; set; }

        Patient Patient { get; set; }
        Practitioner Practitioner { get; set; }
    }
}
