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
            if (context.Patients.Any())
            {
                return;   // DB has been seeded
            }



            var patients = new Patient[]
            {
            new Patient{PatientFirstname="Prince",PatientLastname="Thomas",Email="princethomas@gmail.com", ContactNo = "0825351048", Username = "Prince123",Password = "321"},
            new Patient{PatientFirstname="Mith",PatientLastname="Zeeq",Email="mith@gmail.com", ContactNo = "0825351048", Username = "mith",Password = "321"},
            new Patient{PatientFirstname="Proud",PatientLastname="Zondi",Email="proud@gmail.com", ContactNo = "0601229894", Username = "proud",Password = "433"},
            new Patient{PatientFirstname="Sbu",PatientLastname="Kell",Email="sbu@gmail.com", ContactNo = "0823971454", Username = "sbuda",Password = "pass"},
            new Patient{PatientFirstname="Kholwa",PatientLastname="Zulu",Email="kholwa@gmail.com", ContactNo = "0780921078", Username = "skholwa",Password = "kholwa@121"},
            new Patient{PatientFirstname="Sam",PatientLastname="Mauza",Email="sam@gmail.com", ContactNo = "0733306894", Username = "sam_m",Password = "@mauza"},
            new Patient{PatientFirstname="Sten",PatientLastname="Biko",Email="stenb@gmail.com", ContactNo = "0813354509", Username = "stenma",Password = "@sten_m"},
            new Patient{PatientFirstname="Kelly",PatientLastname="Mbatha",Email="kelly@gmail.com", ContactNo = "0636714521", Username = "kelly_",Password = "kel_mb"},
            new Patient{PatientFirstname="James",PatientLastname="Kennel",Email="james@gmail.com", ContactNo = "0817940923", Username = "myjames",Password = "@jmkennel"},
            new Patient{PatientFirstname="Kim",PatientLastname="Brossn",Email="kbrossn@gmail.com", ContactNo = "0616137896", Username = "bkim",Password = "@kimbrons"},

            };
            foreach (Patient p in patients)
            {
                context.Patients.Add(p);
            }
            context.SaveChanges();

            var practitioners = new Practitioner[]
            {
            new Practitioner{Username="go", Password="1234",Email="go@gmail.com",Type ="Doctor", ContactNo = "0112374898" },
            new Practitioner{Username="pock", Password="78934",Email="gero@gmail.com",Type ="Doctor", ContactNo = "0132374898" },
            new Practitioner{Username="Jacobs", Password="34542",Email="jacobs@gmail.com",Type ="Doctor", ContactNo = "0172374809" },
            new Practitioner{Username="Adams", Password="75848",Email="adams@gmail.com",Type ="Doctor", ContactNo = "0172374834" },
            new Practitioner{Username="Belirna", Password="1923",Email="bell@gmail.com",Type ="Doctor", ContactNo = "0172373205" }
            };
            foreach (Practitioner pc in practitioners)
            {
                context.Practitioners.Add(pc);
            }
            context.SaveChanges();

            var procedures = new Procedure[]
            {
            new Procedure{ PatientID=2, PractitionerID=3,  ProcedureDate=DateTime.Parse("2019-04-22"), Medication = "Panado",
                followupDate =DateTime.Parse("2019-04-23"), Complication="arm strain", ProcedureUsed="injection"},
            new Procedure{ PatientID=4, PractitionerID=1, ProcedureDate=DateTime.Parse("2019-04-21"), Medication = "sertraline",
                followupDate =DateTime.Parse("2019-04-24"), Complication="anxiety", ProcedureUsed="injection"},
            new Procedure{PatientID=6, PractitionerID=2, ProcedureDate=DateTime.Parse("2019-04-16"), Medication = "mania",
                followupDate =DateTime.Parse("2019-04-20"), Complication="arm strain", ProcedureUsed="injection"},
            new Procedure{PatientID=9, PractitionerID=4,  ProcedureDate=DateTime.Parse("2019-04-19"), Medication = "delirium",
                followupDate =DateTime.Parse("2019-04-20"), Complication="arm strain", ProcedureUsed="injection"},
            new Procedure{PatientID=7, PractitionerID=3,  ProcedureDate=DateTime.Parse("2019-04-20"), Medication = "dementia",
                followupDate =DateTime.Parse("2019-04-23"), Complication="arm strain", ProcedureUsed="injection"}
            };
            foreach (Procedure pr in procedures)
            {
                context.Procedures.Add(pr);
            }
            context.SaveChanges();

            var appointments = new Appointment[]
            {
            new Appointment{ PatientID= 9, PractitionerID=4,  AppointmentDate=DateTime.Parse("2019-04-20"), AppointmentDescr="headache"},
            new Appointment{PatientID=2, PractitionerID=3,  AppointmentDate=DateTime.Parse("2019-04-22"), AppointmentDescr="arm strain"},
            new Appointment{PatientID=4, PractitionerID=1,  AppointmentDate=DateTime.Parse("2019-04-21"), AppointmentDescr="stress and headache"}

            };
            foreach (Appointment a in appointments)
            {
                context.Appointments.Add(a);
            }
            context.SaveChanges();
        }
    }
}
