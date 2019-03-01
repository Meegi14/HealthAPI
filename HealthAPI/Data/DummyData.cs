using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthAPI.Data;
using HealthAPI.Models;

namespace HealthAPI.Data
{
    public class DummyData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<HealthContext>();
                context.Database.EnsureCreated();

                if (context.Aliments != null && context.Aliments.Any())
                    return; //DB has already been seeded


                var aliments = GetAilments().ToArray();
                context.Aliments.AddRange(aliments);
                context.SaveChanges();

                var medications = GetMedications().ToArray();
                context.Medications.AddRange(medications);
                context.SaveChanges();

                var patients = GetPatients(context).ToArray();
                context.Patients.AddRange(patients);
                context.SaveChanges();

            }
        }

        public static List<Ailment> GetAilments()
        {
            List<Ailment> ailments = new List<Ailment>()
            {
                new Ailment {Name = "Head Ache"},
                new Ailment {Name = "Tummy Pain"},
                new Ailment {Name = "Flu"},
                new Ailment {Name = "Cold"}

            };

            return ailments;
        }

        public static List<Medication> GetMedications()
        {
            List<Medication> medications = new List<Medication>()
            {
                new Medication {Name="Tylenol", Doses = "2"},
                new Medication {Name="Asprin", Doses = "4"},
                new Medication {Name="Advil", Doses = "3"},
                new Medication {Name="Robaxin", Doses = "2"},
                new Medication {Name="Voltaren", Doses = "1"},
            };

            return medications;

        }

        public static List<Patient> GetPatients(HealthContext db)
        {
            List<Patient> patients = new List<Patient>() {
                new Patient
                {
                    Name = "Jim Jones",
                    Aliments = new List<Ailment>(db.Aliments.Take(2)),
                    Medications = new List<Medication>(db.Medications.Take(2))
                },

            new Patient
            {
                Name = "Ann Smith",
                Aliments = new List<Ailment>(db.Aliments.Take(1)),
                Medications = new List<Medication>(db.Medications.OrderBy(m => m.Name).Skip(1).Take(1))
            },

            new Patient
            {
                Name = "Tom Myers",
                Aliments = new List<Ailment>(db.Aliments.OrderBy(m => m.Name).Skip(1).Take(1)),
                Medications = new List<Medication>(db.Medications.OrderBy(m => m.Name).Skip(2).Take(2)) }


            };

            return patients;
        }
            
                

    }       
          
         
    
    
}
