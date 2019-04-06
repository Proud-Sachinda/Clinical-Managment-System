using PTT_InClinic.Data;
using PTT_InClinic.Models;
using System;
using System.Linq;

namespace PTT_InClinic.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ClinicContext context)
        {
            context.Database.EnsureCreated();

            // Look for any patients
            if (context.Patients.Any())
            {
                return;   // DB has been seeded
            }

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


            var appointments = new Appointment[]
            {
                new Appointment{ PatientID = 65, PractitionerID = 23, AppointmentDate = DateTime.Parse("2019-04-23")},
                new Appointment{ PatientID = 67, PractitionerID = 28, AppointmentDate = DateTime.Parse("2019-04-20")},
                new Appointment{ PatientID = 55, PractitionerID = 12, AppointmentDate = DateTime.Parse("2019-04-19")},
            };

            foreach(Appointment a in appointments)
            {
                context.Appointments.Add(a);
            }
            context.SaveChanges();

            var procedures = new Procedure[]
            {
                new Procedure{ PatientID = 65, PractitionerID = 23, Complication = "Broken knee", Medication = "Patellar", ProcedureUsed = "Non surgical",
                    FollowupDate =DateTime.Parse("2019-04-20"), ProcedureDate =DateTime.Parse("2019-04-18")},

                new Procedure{ PatientID = 34, PractitionerID = 16, Complication = "asthma", Medication = "biomphilic", ProcedureUsed = "None",
                    FollowupDate =DateTime.Parse("2019-04-30"), ProcedureDate =DateTime.Parse("2019-04-28")},

                new Procedure{ PatientID = 44, PractitionerID = 13, Complication = "", Medication = "castrophilip", ProcedureUsed = "Non",
                    FollowupDate =DateTime.Parse("2019-04-14"), ProcedureDate =DateTime.Parse("2019-04-08")},
            };

            foreach(Procedure pd in procedures)
            {
                context.Procedures.Add(pd);
            }
            context.SaveChanges();
        }
    }
}