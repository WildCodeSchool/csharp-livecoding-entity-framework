using System;
using System.Collections.Generic;
using System.Text;

namespace LiveCodingEntityFramework
{
    class Structure
    {
        public Guid StructureId { get; set; }
        public String Name { get; set; }
        public virtual ICollection<StructureAppointment> StructureAppointments { get; set; }
    }
}
