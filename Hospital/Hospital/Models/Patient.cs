using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital.Models
{
    public class Patient
    {
        public int id { get; set; }
        public string name { get; set; }
        public int number { get; set; }
        public int date { get; set; }

        public ICollection<Sections> Sections { get; set; }
    }
}