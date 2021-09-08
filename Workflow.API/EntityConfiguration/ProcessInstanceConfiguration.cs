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
    public class ProcessInstanceConfiguration : IEntityTypeConfiguration<ProcessInstance>
    {
        public void Configure(EntityTypeBuilder<ProcessInstance> builder)
        {
            builder.ToTable("ProcessInstances");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Process).WithMany().HasForeignKey(x => x.ProcessId);
            builder.HasOne(x => x.Step).WithMany().HasForeignKey(x => x.CurrentStepId);
        }
    }
}
