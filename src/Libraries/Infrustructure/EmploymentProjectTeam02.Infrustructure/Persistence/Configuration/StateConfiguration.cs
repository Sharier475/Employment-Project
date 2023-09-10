using EmploymentProjectTeam02.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmploymentProjectTeam02.Infrustructure.Persistence.Configuration;

public class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.ToTable("States");
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Country).WithMany(x => x.states).HasForeignKey(x => x.CountryId).IsRequired(true);

    }
}
