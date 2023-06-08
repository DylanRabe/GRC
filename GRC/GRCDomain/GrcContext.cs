using GRC.Domain.Entities;
using GRC.SharedKernel.Configuration;
using Microsoft.EntityFrameworkCore;

namespace GRC.Domain;
 public class GrcContext : DbContext
    {
    private readonly IModelConfiguration modelConfiguration;

    public GrcContext()
    {
    }
    //A chaque entité creer on ajoute un class configuration avec
    //Singular table name => Singular properties name
    public DbSet<Organisation> Organisations { get; set; }
    public DbSet<Personne> Personnes { get; set; }

    public DbSet<Job> Jobs { get; set; }

    public GrcContext(DbContextOptions<GrcContext> options , IModelConfiguration modelConfiguration) :
            base(options)

    {
        this.modelConfiguration = modelConfiguration;
    }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GrcContext).Assembly);
        //pour pouvoir appeller EF on fais une dependency inversion en creent SharedKernel
        modelConfiguration.ConfigureModel(modelBuilder);
    }
}
