using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkFlow.API.Entities;

namespace Workflow.API.EntityConfiguration
{
    public class StepConfiguration : IEntityTypeConfiguration<Step>
    {
        public void Configure(EntityTypeBuilder<Step> builder)
        {
            builder.ToTable("Steps");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.HasOne(x => x.Process).WithMany(e => e.Steps).HasForeignKey(x => x.ProcessId);
            builder.HasOne(x => x.StepType).WithMany().HasForeignKey(x => x.StepTypeId);
        }
    }
}
