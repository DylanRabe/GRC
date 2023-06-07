using GRC.Domain.Entities;
using GRC.SharedKernel.Configuration;
using Microsoft.EntityFrameworkCore;

namespace GRC.Domain;
 public class GrcContext : DbContext
    {
    private readonly IModelConfiguration modelConfiguration;
        public GrcContext(DbContextOptions<GrcContext> options) :
            base(options)
    
            {
                this.modelConfiguration = modelConfiguration;
            }
    //A chaque entité creer on ajoute un class configuration avec
    //Singular table name => Singular properties name
    public DbSet<Organisation> Organisation { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GrcContext).Assembly);
        //pour pouvoir appeller EF on fais une dependency inversion en creent SharedKernel
        modelConfiguration.ConfigureModel(modelBuilder);
    }
}
