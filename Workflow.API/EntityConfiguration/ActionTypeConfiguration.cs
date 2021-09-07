using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkFlow.API.Entities;

namespace Workflow.API.EntityConfiguration
{
    public class ActionTypeConfiguration : IEntityTypeConfiguration<ActionType>
    {
        public void Configure(EntityTypeBuilder<ActionType> builder)
        {
            builder.ToTable("ActionTypes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
        }
    }
}
