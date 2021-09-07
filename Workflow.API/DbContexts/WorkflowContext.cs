using Microsoft.EntityFrameworkCore;
using Workflow.API.Entities;
using Workflow.API.EntityConfiguration;
using Workflow.API.Enums;
using WorkFlow.API.Entities;
using WorkFlow.API.Enums;
using Action = WorkFlow.API.Entities.Action;

namespace Workflow.API.DbContexts
{
    public class WorkflowContext : DbContext
    {
        public WorkflowContext(DbContextOptions<WorkflowContext> options) : base(options)
        {
        }

        public DbSet<Process> Processes { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<ProcessInstance> ProcessInstances { get; set; }
        public DbSet<ActionType> ActionTypes { get; set; }
        public DbSet<StepType> StepTypes { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestType> RequestTypes { get; set; }
        public DbSet<ActionHistory> ActionsHistory { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configurations
            modelBuilder.ApplyConfiguration(new ProcessConfiguration());
            modelBuilder.ApplyConfiguration(new StepConfiguration());
            modelBuilder.ApplyConfiguration(new ActionConfiguration());
            modelBuilder.ApplyConfiguration(new ProcessInstanceConfiguration());
            modelBuilder.ApplyConfiguration(new ActionHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new StepTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ActionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RequestConfiguration());
            modelBuilder.ApplyConfiguration(new RequestTypeConfiguration());

            modelBuilder.Entity<RequestType>().HasData(new RequestType() { Id = (int)RequestTypesEnum.Claim, Name = "Claim Request" });
            modelBuilder.Entity<RequestType>().HasData(new RequestType() { Id = (int)RequestTypesEnum.ModifyBill, Name = "Modify Bill Request" });
            modelBuilder.Entity<RequestType>().HasData(new RequestType() { Id = (int)RequestTypesEnum.CancelBill, Name = "Cancel Bill Request" });

            modelBuilder.Entity<StepType>().HasData(new StepType() { Id = (int)StepTypesEnum.Draft, Code = "Draft", Name = "Draft" });
            modelBuilder.Entity<StepType>().HasData(new StepType() { Id = (int)StepTypesEnum.InProgress, Code = "InProgress", Name = "InProgress" });
            modelBuilder.Entity<StepType>().HasData(new StepType() { Id = (int)StepTypesEnum.Approved, Code = "Approved", Name = "Approved" });
            modelBuilder.Entity<StepType>().HasData(new StepType() { Id = (int)StepTypesEnum.Rejected, Code = "Rejected", Name = "Rejected" });
            modelBuilder.Entity<StepType>().HasData(new StepType() { Id = (int)StepTypesEnum.Canceled, Code = "Canceled", Name = "Canceled" });
            modelBuilder.Entity<StepType>().HasData(new StepType() { Id = (int)StepTypesEnum.Assessor, Code = "Assessor", Name = "Assessor" });
            modelBuilder.Entity<StepType>().HasData(new StepType() { Id = (int)StepTypesEnum.Endorser, Code = "Endorser", Name = "Endorser" });
            modelBuilder.Entity<StepType>().HasData(new StepType() { Id = (int)StepTypesEnum.Approver, Code = "Approver", Name = "Approver" });
            modelBuilder.Entity<StepType>().HasData(new StepType() { Id = (int)StepTypesEnum.Initiator, Code = "Initiator", Name = "Initiator" });
            modelBuilder.Entity<StepType>().HasData(new StepType() { Id = (int)StepTypesEnum.CommitteeReview, Code = "CommitteeReview", Name = "Committee Review" });

            modelBuilder.Entity<ActionType>().HasData(new ActionType() { Id = (int)ActionTypesEnum.Submit, Code = "Submit", Name = "Submit" });
            modelBuilder.Entity<ActionType>().HasData(new ActionType() { Id = (int)ActionTypesEnum.Approve, Code = "Approve", Name = "Approve" });
            modelBuilder.Entity<ActionType>().HasData(new ActionType() { Id = (int)ActionTypesEnum.Return, Code = "Return", Name = "Return" });
            modelBuilder.Entity<ActionType>().HasData(new ActionType() { Id = (int)ActionTypesEnum.Reject, Code = "Reject", Name = "Reject" });
            modelBuilder.Entity<ActionType>().HasData(new ActionType() { Id = (int)ActionTypesEnum.UnderReview, Code = "UnderReview", Name = "Under Review" });
            modelBuilder.Entity<ActionType>().HasData(new ActionType() { Id = (int)ActionTypesEnum.ApproveForSubmission, Code = "ApproveForSubmission", Name = "Approve For Submission" });
            modelBuilder.Entity<ActionType>().HasData(new ActionType() { Id = (int)ActionTypesEnum.RecommendForApproval, Code = "RecommendForApproval", Name = "Recommend For Approval" });
            modelBuilder.Entity<ActionType>().HasData(new ActionType() { Id = (int)ActionTypesEnum.RecommendForRejection, Code = "RecommendForRejection", Name = "Recommend for rejection" });


            modelBuilder.Entity<Process>().HasData(new Process()
            {
                Id = (int)WorkflowTemplateEnum.ClaimRequest,
                FirstStepId = (int)WorkflowTemplateEnum.ClaimRequest_Initiator,
                Name = "",
            });
            modelBuilder.Entity<Step>().HasData(new Step()
            {
                Id = (int)WorkflowTemplateEnum.ClaimRequest_Initiator,
                ProcessId = (int)WorkflowTemplateEnum.ClaimRequest,
                StepTypeId = (int)StepTypesEnum.Initiator,
                Name = ""
            });
            modelBuilder.Entity<Action>().HasData(new Action()
            {
                Id = (int)WorkflowTemplateEnum.ClaimRequest_Initiator_Submit,
                Name = "",
                CurrentStepId = (int)WorkflowTemplateEnum.ClaimRequest_Initiator,
                NextStepId = (int)WorkflowTemplateEnum.ClaimRequest_Assessor,
                ActionTypeId = (int)ActionTypesEnum.Submit,
            });

            modelBuilder.Entity<Step>().HasData(new Step()
            {
                Id = (int)WorkflowTemplateEnum.ClaimRequest_Assessor,
                ProcessId = (int)WorkflowTemplateEnum.ClaimRequest,
                StepTypeId = (int)StepTypesEnum.Assessor,
                Name = ""
            });
            modelBuilder.Entity<Action>().HasData(new Action()
            {
                Id = (int)WorkflowTemplateEnum.ClaimRequest_Assessor_Approve,
                Name = "",
                CurrentStepId = (int)WorkflowTemplateEnum.ClaimRequest_Assessor,
                NextStepId = (int)WorkflowTemplateEnum.ClaimRequest_Endorser,
                ActionTypeId = (int)ActionTypesEnum.Approve,
            });
            modelBuilder.Entity<Action>().HasData(new Action()
            {
                Id = (int)WorkflowTemplateEnum.ClaimRequest_Assessor_Reject,
                Name = "",
                CurrentStepId = (int)WorkflowTemplateEnum.ClaimRequest_Assessor,
                NextStepId = (int)WorkflowTemplateEnum.ClaimRequest_Rejected,
                ActionTypeId = (int)ActionTypesEnum.Reject,
            });
            modelBuilder.Entity<Action>().HasData(new Action()
            {
                Id = (int)WorkflowTemplateEnum.ClaimRequest_Assessor_ReturnForEditing,
                Name = "",
                CurrentStepId = (int)WorkflowTemplateEnum.ClaimRequest_Assessor,
                NextStepId = (int)WorkflowTemplateEnum.ClaimRequest_Initiator,
                ActionTypeId = (int)ActionTypesEnum.Return,
            });
            modelBuilder.Entity<Action>().HasData(new Action()
            {
                Id = (int)WorkflowTemplateEnum.ClaimRequest_Assessor_RecommendReject,
                Name = "",
                CurrentStepId = (int)WorkflowTemplateEnum.ClaimRequest_Assessor,
                NextStepId = (int)WorkflowTemplateEnum.ClaimRequest_Endorser,
                ActionTypeId = (int)ActionTypesEnum.RecommendForRejection,
            });

            modelBuilder.Entity<Step>().HasData(new Step()
            {
                Id = (int)WorkflowTemplateEnum.ClaimRequest_Endorser,
                ProcessId = (int)WorkflowTemplateEnum.ClaimRequest,
                StepTypeId = (int)StepTypesEnum.Endorser,
                Name = ""
            });
            modelBuilder.Entity<Action>().HasData(new Action()
            {
                Id = (int)WorkflowTemplateEnum.ClaimRequest_Endorser_Approve,
                Name = "",
                CurrentStepId = (int)WorkflowTemplateEnum.ClaimRequest_Endorser,
                NextStepId = (int)WorkflowTemplateEnum.ClaimRequest_Approver,
                ActionTypeId = (int)ActionTypesEnum.Approve,
            });
            modelBuilder.Entity<Action>().HasData(new Action()
            {
                Id = (int)WorkflowTemplateEnum.ClaimRequest_Endorser_ReturnForEditing,
                Name = "",
                CurrentStepId = (int)WorkflowTemplateEnum.ClaimRequest_Endorser,
                NextStepId = (int)WorkflowTemplateEnum.ClaimRequest_Initiator,
                ActionTypeId = (int)ActionTypesEnum.Return,
            });
            modelBuilder.Entity<Action>().HasData(new Action()
            {
                Id = (int)WorkflowTemplateEnum.ClaimRequest_Endorser_RecommendReject,
                Name = "",
                CurrentStepId = (int)WorkflowTemplateEnum.ClaimRequest_Endorser,
                NextStepId = (int)WorkflowTemplateEnum.ClaimRequest_Approver,
                ActionTypeId = (int)ActionTypesEnum.RecommendForRejection,
            });
            modelBuilder.Entity<Action>().HasData(new Action()
            {
                Id = (int)WorkflowTemplateEnum.ClaimRequest_Endorser_Reject,
                Name = "",
                CurrentStepId = (int)WorkflowTemplateEnum.ClaimRequest_Endorser,
                NextStepId = (int)WorkflowTemplateEnum.ClaimRequest_Rejected,
                ActionTypeId = (int)ActionTypesEnum.Reject,
            });

            modelBuilder.Entity<Step>().HasData(new Step()
            {
                Id = (int)WorkflowTemplateEnum.ClaimRequest_Approver,
                ProcessId = (int)WorkflowTemplateEnum.ClaimRequest,
                StepTypeId = (int)StepTypesEnum.Approver,
                Name = ""
            });
            modelBuilder.Entity<Action>().HasData(new Action()
            {
                Id = (int)WorkflowTemplateEnum.ClaimRequest_Approver_Approve,
                Name = "",
                CurrentStepId = (int)WorkflowTemplateEnum.ClaimRequest_Approver,
                NextStepId = (int)WorkflowTemplateEnum.ClaimRequest_Approved,
                ActionTypeId = (int)ActionTypesEnum.Approve,
            });
            modelBuilder.Entity<Action>().HasData(new Action()
            {
                Id = (int)WorkflowTemplateEnum.ClaimRequest_Approver_Reject,
                Name = "",
                CurrentStepId = (int)WorkflowTemplateEnum.ClaimRequest_Approver,
                NextStepId = (int)WorkflowTemplateEnum.ClaimRequest_Rejected,
                ActionTypeId = (int)ActionTypesEnum.Reject,
            });
            modelBuilder.Entity<Action>().HasData(new Action()
            {
                Id = (int)WorkflowTemplateEnum.ClaimRequest_Approver_ReturnForEditing,
                Name = "",
                CurrentStepId = (int)WorkflowTemplateEnum.ClaimRequest_Approver,
                NextStepId = (int)WorkflowTemplateEnum.ClaimRequest_Initiator,
                ActionTypeId = (int)ActionTypesEnum.Return,
            });

            modelBuilder.Entity<Step>().HasData(new Step()
            {
                Id = (int)WorkflowTemplateEnum.ClaimRequest_Approved,
                ProcessId = (int)WorkflowTemplateEnum.ClaimRequest,
                StepTypeId = (int)StepTypesEnum.Approved,
                Name = ""
            });
            modelBuilder.Entity<Step>().HasData(new Step()
            {
                Id = (int)WorkflowTemplateEnum.ClaimRequest_Rejected,
                ProcessId = (int)WorkflowTemplateEnum.ClaimRequest,
                StepTypeId = (int)StepTypesEnum.Rejected,
                Name = ""
            });
            modelBuilder.Entity<Step>().HasData(new Step()
            {
                Id = (int)WorkflowTemplateEnum.ClaimRequest_Cancelled,
                ProcessId = (int)WorkflowTemplateEnum.ClaimRequest,
                StepTypeId = (int)StepTypesEnum.Canceled,
                Name = ""
            });
        }
    }
}
