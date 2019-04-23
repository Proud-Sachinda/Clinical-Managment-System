using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Clinic_System.Models
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public int PractitionerID { get; set; }

        [DataType(DataType.Date), Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AppointmentDate { get; set; }

        [Required(ErrorMessage = "Please type appointment description")]
        [DataType(DataType.Text), StringLength(300)]
        public string AppointmentDescr { get; set; }

        Practitioner Practitioner { get; set; }
        Patient Patient { get; set; }
    }
}
