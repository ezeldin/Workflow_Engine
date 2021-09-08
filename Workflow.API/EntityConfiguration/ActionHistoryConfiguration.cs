using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.API.Entities;
using WorkFlow.API.Entities;

namespace Workflow.API.EntityConfiguration
{
    public class ActionHistoryConfiguration : IEntityTypeConfiguration<ActionHistory>
    {
        public void Configure(EntityTypeBuilder<ActionHistory> builder)
        {
            builder.ToTable("ActionsHistory");
            builder.HasKey(x => x.Id);
            //builder.Property(x => x.ProcessInstanceId).IsRequired();

            builder.HasOne(x => x.ProcessInstance)
                .WithMany(e => e.ActionsHistory)
                .HasForeignKey(x => x.ProcessInstanceId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Action).WithMany().HasForeignKey(x => x.ActionId);
        }
    }
}
