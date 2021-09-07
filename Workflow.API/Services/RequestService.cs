using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.API.Dtos;
using Workflow.API.Entities;
using WorkFlow.API.WorkFlowEngine;

namespace Workflow.API.Services
{
    public class RequestService : IRequestService
    {
        private readonly IWorkFlowEngine _workFlowEngine;
        public RequestService(IWorkFlowEngine workFlowEngine)
        {
            _workFlowEngine = workFlowEngine;
        }

        public Task<Request> CreateRequest(CreateRequestInput request)
        {
            //prepare request obj

            //id = initialize process instance and get id 

            // request.processInstanceId=id

            //insert request into db


            return null;
        }
    }
}
