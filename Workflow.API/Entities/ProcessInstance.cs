using System.Collections;
using System.Collections.Generic;
using Workflow.API.Entities;

namespace WorkFlow.API.Entities
{
    public class ProcessInstance
    {
        private ProcessInstance()
        {
        }
        public int Id { get; private set; }
        public int ProcessId { get; private set; }
        public Process Process { get; private set; }
        public int CurrentStepId { get; private set; } //initialize:process.firstStepId  //doAction:action.NextStepId
        public Step Step { get; private set; }

        public ICollection<ActionHistory> ActionsHistory { get; set; }

        public ProcessInstance(Process process)
        {
            ProcessId = process.Id;
            CurrentStepId = process.FirstStepId;
        }
        public void Update(Action action)
        {
            CurrentStepId = action.NextStepId.Value;
        }
    }

}
