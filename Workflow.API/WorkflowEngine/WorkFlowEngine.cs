using System.Threading.Tasks;
using Workflow.API.Dtos;
using Workflow.API.Entities;
using WorkFlow.API.Entities;
using WorkFlow.API.Enums;
using Action = WorkFlow.API.Entities.Action;

namespace WorkFlow.API.WorkFlowEngine
{
    public class WorkFlowEngine : IWorkFlowEngine
    {
        
        public Task<ProcessInstance> Initialize(ProcessesEnum processId)
        {
            //get process from DB by processId
            var process = new Process();

            //create processInstance
            ProcessInstance processInstance = new ProcessInstance(process);

            //insert to db

            return null;
        }
        public Task DoAction(ActionsEnum actionId, int processInstanceId)
        {
            //get Action from DB by actionId
            var action = new Action();

            //get processInstance by id 

            //update processInstance
            //ProcessInstance.Update(action);
            //insrt action History

            //save to db

            return null;
        }
    }


}
