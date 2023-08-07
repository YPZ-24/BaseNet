using IntranetCorrespondencia.Entities.POCOs;
using IntranetCorrespondencia.Repository.EFCore.Configurations;
using Microsoft.EntityFrameworkCore;

namespace IntranetCorrespondencia.Repository.EFCore.DBContext
{
    public class IntranetCorrespondenciaContext : DbContext
    {
        public IntranetCorrespondenciaContext(DbContextOptions<IntranetCorrespondenciaContext> options) : base(options) { }

        public DbSet<Entities.POCOs.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new TaskConfiguration());

        }
    }
}
