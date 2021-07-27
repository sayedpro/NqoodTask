using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Domain.Common
{
   public abstract class AuditedEntity
    {
        public virtual DateTime? CreationDate { get; set; }
    }
}
