using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkFlow.API.Entities
{
    public class Step
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ProcessId { get; set; }
        public Process Process { get; set; }

        public int StepTypeId { get; set; }
        public StepType StepType { get; set; }
        public short Order { get; set; }


        //[InverseProperty("CurrentStep")]
        public ICollection<Action> Actions { get; set; }
    }

}
