﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarAppointment.Models.ViewModels
{
    public class UserBookingViewModel
    {
        public int Id { get; set; }
        public int? LocationId { get; set; }

        public int PackageId { get; set; }
        public DateTime AppointmentTime { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}