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
    public class ActionTypeConfiguration : IEntityTypeConfiguration<ActionType>
    {
        public void Configure(EntityTypeBuilder<ActionType> builder)
        {
            builder.ToTable("ActionTypes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.HasData(new ActionType() { Id = (int)ActionTypesEnum.Submit, Code = "Submit", Name = "Submit" });
            builder.HasData(new ActionType() { Id = (int)ActionTypesEnum.Approve, Code = "Approve", Name = "Approve" });
            builder.HasData(new ActionType() { Id = (int)ActionTypesEnum.Return, Code = "Return", Name = "Return" });
            builder.HasData(new ActionType() { Id = (int)ActionTypesEnum.Reject, Code = "Reject", Name = "Reject" });
            builder.HasData(new ActionType() { Id = (int)ActionTypesEnum.UnderReview, Code = "UnderReview", Name = "Under Review" });
            builder.HasData(new ActionType() { Id = (int)ActionTypesEnum.ApproveForSubmission, Code = "ApproveForSubmission", Name = "Approve For Submission" });
            builder.HasData(new ActionType() { Id = (int)ActionTypesEnum.RecommendForApproval, Code = "RecommendForApproval", Name = "Recommend For Approval" });
            builder.HasData(new ActionType() { Id = (int)ActionTypesEnum.RecommendForRejection, Code = "RecommendForRejection", Name = "Recommend for rejection" });
        }
    }
}
