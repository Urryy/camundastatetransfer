using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CamundaState.Models;

namespace CamundaState.AppContext
{
    public class WorkflowContext
	    : DbContext
    {
	    public DbSet<ObjectWf> ObjectWfs { get; set; } = default!;
	    public DbSet<ProjectWf> ProjectWfs { get; set; } = default!;
	    public DbSet<Models.Action> Actions { get; set; } = default!;
	    public DbSet<Status> Statuses { get; set; } = default!;

	    public WorkflowContext(DbContextOptions options) : base(options)
	    {
		    Database.EnsureCreated();
	    }

	    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	    {
		    optionsBuilder.UseLazyLoadingProxies();
	    }

	    protected override void OnModelCreating(ModelBuilder modelBuilder)
	    {
		    modelBuilder.ApplyConfiguration(new StatusConfiguration());
		    modelBuilder.ApplyConfiguration(new ActionConfiguration());
		    modelBuilder.ApplyConfiguration(new ObjectWfConfiguration());
		    base.OnModelCreating(modelBuilder);
	    }

	    class ObjectWfConfiguration : IEntityTypeConfiguration<ObjectWf>
	    {
		    public void Configure(EntityTypeBuilder<ObjectWf> builder)
		    {
			    builder.HasKey(s => s.Id);
			    builder.Property(e => e.Id).ValueGeneratedNever();

			    //Для наследования TPH
			    builder.HasDiscriminator()
				    .HasValue<ProjectWf>(nameof(ProjectWf));

			    builder.HasOne(b => b.Status)
				    .WithMany()
				    .HasForeignKey(a => a.StatusId);

		    }
	    }

	    class StatusConfiguration : IEntityTypeConfiguration<Status>
	    {
		    public void Configure(EntityTypeBuilder<Status> builder)
		    {
			    builder.HasKey(s => s.Id);
		    }
	    }

	    class ActionConfiguration : IEntityTypeConfiguration<Models.Action>
	    {
		    public void Configure(EntityTypeBuilder<Models.Action> builder)
		    {

			    builder.HasKey(s => s.Id);
		    }
	    }
    }
}
