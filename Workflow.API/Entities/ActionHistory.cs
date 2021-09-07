using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkFlow.API.Entities;
using Action = WorkFlow.API.Entities.Action;

namespace Workflow.API.Entities
{
    public class ActionHistory
    {
        public int Id { get; set; }
        public int ProcessInstanceId { get; set; }
        public ProcessInstance ProcessInstance { get; set; }
        public int ActionId { get; set; }
        public Action Action { get; set; }
    }
}
