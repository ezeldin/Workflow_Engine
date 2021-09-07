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
    public class RequestTypeConfiguration : IEntityTypeConfiguration<RequestType>
    {
        public void Configure(EntityTypeBuilder<RequestType> builder)
        {
            builder.ToTable("RequestTypes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
        }
    }
}
