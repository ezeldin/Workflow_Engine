using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkFlow.API.Entities;
using Action = WorkFlow.API.Entities.Action;

namespace Workflow.API.EntityConfiguration
{
    public class ActionConfiguration : IEntityTypeConfiguration<Action>
    {
        public void Configure(EntityTypeBuilder<Action> builder)
        {
            builder.ToTable("Actions");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.HasOne(x => x.CurrentStep).WithMany(e => e.Actions).HasForeignKey(x => x.CurrentStepId);
            builder.HasOne(x => x.NextStep).WithMany().HasForeignKey(x => x.NextStepId);
            builder.HasOne(x => x.ActionType).WithMany().HasForeignKey(x => x.ActionTypeId);
        }
    }
}
