using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_System.Models
{
    public class Practitioner
    {
        public int PractitionerID { get; set; }

        [DataType(DataType.Text), StringLength(10, MinimumLength = 3)]
        public string Username { get; set; }

        [Required, DataType(DataType.Password), StringLength(10, MinimumLength = 6)]
        public string Password { get; set; }

        [Required, DataType(DataType.EmailAddress), EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage ="Please select Nurse or Doctor")]
        public string Type { get; set; }

        [Required, DataType(DataType.PhoneNumber), Phone]
        public string ContactNo { get; set; }

        public ICollection<Appointment> Appointment { get; set; }
    }
}
