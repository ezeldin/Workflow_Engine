
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.API.Entities;
using WorkFlow.API.Enums;

namespace WorkFlow.API.WorkFlowEngine
{
    public interface IWorkFlowEngine
    {
        public Task<ProcessInstance> Initialize(ProcessesEnum processId);
        public Task DoAction(ActionsEnum actionId, int processInstanceId);
    }
}
