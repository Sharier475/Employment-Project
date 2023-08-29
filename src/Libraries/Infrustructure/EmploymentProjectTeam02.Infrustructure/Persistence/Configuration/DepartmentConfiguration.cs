using EmploymentProjectTeam02.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmploymentProjectTeam02.Infrustructure.Persistence.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");
            builder.HasIndex(x=>x.DepartmentName).IsUnique(true);
            builder.HasKey(x => x.Id);
            
        }
    }
}
