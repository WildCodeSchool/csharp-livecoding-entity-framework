using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveCodingEntityFramework
{
    public static class Program
    { 
        static void Main()
        {
            using (var context = new PostponedContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                var manyAppointments = from i in Enumerable.Range(0, 10)
                                   select new Appointment { StartDate = DateTime.Now, 
                                                             EndDate = DateTime.Now + TimeSpan.FromDays(1) };
                var manyStructures = from i in Enumerable.Range(0, 3)
                                 select new Structure { Name = i.ToString() };

                List<StructureAppointment> manyStructureAppointments = new List<StructureAppointment>();
                foreach (var structure in manyStructures)
                {
                    foreach (var appointment in manyAppointments)
                    {
                        var structureAppointment = new StructureAppointment { 
                            AppointmentId = appointment.AppointmentId, Appointment = appointment, 
                            StructureId = structure.StructureId, Structure = structure 
                        };
                        manyStructureAppointments.Add(structureAppointment);
                    }
                }
                context.AddRange(manyAppointments);
                context.AddRange(manyStructures);
                context.AddRange(manyStructureAppointments);
                context.SaveChanges();
                var appointmentsGroup = context.StructureAppointment.AsEnumerable()
                                                                    .GroupBy(ag => ag.StructureId, ag => ag);
                /* var appointmentsGroups = from sa in context.StructureAppointment.AsEnumerable()
                                            group sa by sa.StructureId into saGroup
                                            select saGroup;*/
                String message = String.Empty;
                foreach (var group in appointmentsGroup)
                {
                    message += group.Key + ": " + group.Count() + "\n";
                }
                MessageBox.Show(message);
            }
        }
    }
}
