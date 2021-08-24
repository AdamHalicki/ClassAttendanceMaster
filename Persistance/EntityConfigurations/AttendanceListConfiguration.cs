using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.EntityConfigurations
{
    public class AttendanceListConfiguration : IEntityTypeConfiguration<AttendanceList>
    {
        public void Configure(EntityTypeBuilder<AttendanceList> builder)
        {

        }
    }
}
