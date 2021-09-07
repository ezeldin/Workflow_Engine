using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkFlow.API.Entities;

namespace Workflow.API.EntityConfiguration
{
    public class StepTypeConfiguration : IEntityTypeConfiguration<StepType>
    {
        public void Configure(EntityTypeBuilder<StepType> builder)
        {
            builder.ToTable("StepTypes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
        }
    }
}
