using System.ComponentModel.DataAnnotations;

namespace WorkFlow.API.Entities
{
    public class Action
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ActionTypeId { get; set; }
        public ActionType ActionType { get; set; }

        [Required]
        public int CurrentStepId { get; set; }
        public Step CurrentStep { get; set; }

        public int? NextStepId { get; set; }
        public Step NextStep { get; set; }

        public short Order { get; set; }

    }

}
