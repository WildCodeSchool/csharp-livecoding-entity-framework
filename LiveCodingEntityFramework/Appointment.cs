using System;
using System.Collections.Generic;
using System.Text;

namespace LiveCodingEntityFramework
{
    class Appointment
    {
        public Guid AppointmentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<StructureAppointment> StructureAppointments { get; set; }
    }
}
