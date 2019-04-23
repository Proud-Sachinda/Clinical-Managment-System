using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_System.Models
{
    public class Patient
    {
        public int PatientID { get; set; }

        [Required (ErrorMessage ="Patient {0} is Required")]
        [StringLength(20,MinimumLength =2)]
        [DataType(DataType.Text)]
        public string PatientFirstname { get; set; }

        [Required(ErrorMessage = "Patient {0} is Required")]
        [StringLength(20, MinimumLength = 2)]
        [DataType(DataType.Text)]
        public string PatientLastname { get; set; }


        [Required, DataType(DataType.EmailAddress), EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.PhoneNumber), Phone]
        public string ContactNo { get; set; }

        [DataType(DataType.Text), StringLength(10,MinimumLength =3)]
        public string Username { get; set; }

        [Required, DataType(DataType.Password), StringLength(10,MinimumLength =6)]
        public string Password { get; set; }

        public ICollection<Appointment> Appointment { get; set; }
    }
}
