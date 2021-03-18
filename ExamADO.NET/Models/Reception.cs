using System;
using System.Collections.Generic;
using System.Text;

namespace ExamADO.NET.Models
{
    public class Reception : Entity
    {        
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public bool IsUse { get; set; }
    }
}
