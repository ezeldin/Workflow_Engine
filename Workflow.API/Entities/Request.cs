using WorkFlow.API.Entities;

namespace Workflow.API.Entities
{
    public class Request
    {
        public int Id { get; set; }
        public int RequestTypeId { get; set; }
        public RequestType RequestType { get; set; }
        public int ProcessInstanceId { get; set; }
        public ProcessInstance ProcessInstance { get; set; }
    }
}
