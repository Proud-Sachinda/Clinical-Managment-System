using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_System.Models
{
    public class Procedure
    {
        public int ProcedureID { get; set; }
        public int PatientID { get; set; }
        public int PractitionerID { get; set; }

        [DataType(DataType.Date), Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ProcedureDate { get; set; }
        public string Medication { get; set; }

        [DataType(DataType.Date), Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime followupDate { get; set; }

        [Required(ErrorMessage = "Procedure {0} is Required")]
        [DataType(DataType.Text)]
        public string Complication { get; set; }

        [Required(ErrorMessage = "Patient {0} is Required")]
        [DataType(DataType.Text)]
        public string ProcedureUsed { get; set; }

        Practitioner Practitioner { get; set; }
        Patient Patient { get; set; }
    }
}
