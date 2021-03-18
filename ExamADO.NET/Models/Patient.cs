using System;
using System.Collections.Generic;
using System.Text;

namespace ExamADO.NET.Models
{
    public class Patient : Entity
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
