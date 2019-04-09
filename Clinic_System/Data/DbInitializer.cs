using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinic_System.Models;

namespace Clinic_System.Data
{
    public class DbInitializer
    {
        public static void Initialize(ClinicContext context)
        {
            context.Database.EnsureCreated();

            // Look for any patients
            if (context.Administrators.Any())
            {
                return;   // DB has been seeded
            }

            var appointments = new Administrator[]
            {
                new Administrator{}
            };

            var patients = new Patient[]
            {
            new Patient{PatientFirstname="Prince",PatientLastname="Thomas",Email="princethomas@gmail.com", ContactNo = "0825351048", Username = "Prince123",Password = "321"},
            new Patient{PatientFirstname="Mith",PatientLastname="Zeeq",Email="mith@gmail.com", ContactNo = "0825351048", Username = "mith",Password = "321"},
            new Patient{PatientFirstname="Proud",PatientLastname="Zondi",Email="proud@gmail.com", ContactNo = "0601229894", Username = "proud",Password = "433"},

            };
            foreach (Patient p in patients)
            {
                context.Patients.Add(p);
            }
            context.SaveChanges();

            var practitioners = new Practitioner[]
            {
            new Practitioner{Username="go", Password="1234",Email="go@gmail.com",Type ="Doctor", ContactNo = "0112374898" },
            new Practitioner{Username="pock", Password="78934",Email="gero@gmail.com",Type ="Niurse", ContactNo = "0132374898" },
            new Practitioner{Username="Jacobs", Password="34542",Email="jacobs@gmail.com",Type ="Doctor", ContactNo = "0172374898" },
            };
            foreach (Practitioner pc in practitioners)
            {
                context.Practitioners.Add(pc);
            }
            context.SaveChanges();

            var administrations = new Administrator[]
            {
                new Administrator{Username = "goerge",Password="1050"},
                new Administrator{Username = "ben",Password="2345"},

            };
            foreach (Administrator e in administrations)
            {
                context.Administrators.Add(e);
            }
            context.SaveChanges();
        }

    }
}
