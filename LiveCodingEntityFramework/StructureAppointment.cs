using System;
using System.Collections.Generic;
using System.Text;

namespace LiveCodingEntityFramework
{
    class StructureAppointment
    {
        public Guid AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        public Guid StructureId { get; set; }
        public Structure Structure { get; set; }
    }
}
