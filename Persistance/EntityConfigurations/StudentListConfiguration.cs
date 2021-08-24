using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.EntityConfigurations
{
    public class StudentListConfiguration : IEntityTypeConfiguration<StudentList>
    {
        public void Configure(EntityTypeBuilder<StudentList> builder)
        {

        }
    }
}
