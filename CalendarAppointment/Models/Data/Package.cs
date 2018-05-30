using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarAppointment.Models.Data
{
    public class Package
    {
        public int Id { get; set; }
        public string PackageName { get; set; }
        public string PackageDescription{ get; set; }
        public decimal Price { get; set; }
    }
}