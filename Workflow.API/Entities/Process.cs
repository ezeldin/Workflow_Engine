using System;
using System.Collections.Generic;
using System.Text;

namespace WorkFlow.API.Entities
{
    public class Process
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FirstStepId { get; set; }
        public short Order { get; set; }
        public ICollection<Step> Steps { get; set; }
    }

}
