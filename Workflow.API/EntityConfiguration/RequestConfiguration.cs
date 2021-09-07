using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.API.Entities;
using WorkFlow.API.Entities;
using Action = WorkFlow.API.Entities.Action;

namespace Workflow.API.EntityConfiguration
{
    public class RequestConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.ToTable("Requests");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.ProcessInstance).WithMany().HasForeignKey(x => x.ProcessInstanceId);
            builder.HasOne(x => x.RequestType).WithMany().HasForeignKey(x => x.RequestTypeId);
        }
    }
}
