using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital.Models
{
    public enum Department
    {
        bones, eyes, heart, throat
    }
    public class Sections
    {
        public int id { get; set; }
        public int PatientID { get; set; }
        public Department? Department { get; set; }

        public virtual Patient Patient { get; set; }


    }
}