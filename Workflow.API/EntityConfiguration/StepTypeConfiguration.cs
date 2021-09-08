using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkFlow.API.Entities;
using WorkFlow.API.Enums;

namespace Workflow.API.EntityConfiguration
{
    public class StepTypeConfiguration : IEntityTypeConfiguration<StepType>
    {
        public void Configure(EntityTypeBuilder<StepType> builder)
        {
            builder.ToTable("StepTypes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.HasData(new StepType() { Id = (int)StepTypesEnum.Draft, Code = "Draft", Name = "Draft" });
            builder.HasData(new StepType() { Id = (int)StepTypesEnum.InProgress, Code = "InProgress", Name = "InProgress" });
            builder.HasData(new StepType() { Id = (int)StepTypesEnum.Approved, Code = "Approved", Name = "Approved" });
            builder.HasData(new StepType() { Id = (int)StepTypesEnum.Rejected, Code = "Rejected", Name = "Rejected" });
            builder.HasData(new StepType() { Id = (int)StepTypesEnum.Canceled, Code = "Canceled", Name = "Canceled" });
            builder.HasData(new StepType() { Id = (int)StepTypesEnum.Assessor, Code = "Assessor", Name = "Assessor" });
            builder.HasData(new StepType() { Id = (int)StepTypesEnum.Endorser, Code = "Endorser", Name = "Endorser" });
            builder.HasData(new StepType() { Id = (int)StepTypesEnum.Approver, Code = "Approver", Name = "Approver" });
            builder.HasData(new StepType() { Id = (int)StepTypesEnum.Initiator, Code = "Initiator", Name = "Initiator" });
            builder.HasData(new StepType() { Id = (int)StepTypesEnum.CommitteeReview, Code = "CommitteeReview", Name = "Committee Review" });
        }
    }
}
