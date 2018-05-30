using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarAppointment.Models.Data
{
    public class Booking
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int? LocationId { get; set; }

        public int PackageId { get; set; }
        public DateTime AppointmentTime { get; set; }
    }
}