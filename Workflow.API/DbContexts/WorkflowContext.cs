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
            modelBuilder.ApplyConfiguration(new RequestTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StepTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ActionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProcessConfiguration());
            modelBuilder.ApplyConfiguration(new StepConfiguration());
            modelBuilder.ApplyConfiguration(new ActionConfiguration());
            modelBuilder.ApplyConfiguration(new ProcessInstanceConfiguration());
            modelBuilder.ApplyConfiguration(new ActionHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new RequestConfiguration());

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
