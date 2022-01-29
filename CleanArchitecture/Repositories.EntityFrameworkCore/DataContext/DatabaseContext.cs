using Entities.POCO;
using Microsoft.EntityFrameworkCore;

namespace Repositories.EntityFrameworkCore.DataContext
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options) { }

        public DbSet<Promocion> Promocion { get; set; }
        //YR_28102021
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=CleanArchExampleDB;Trusted_Connection=True;");
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CleanArchExampleDB;User ID=sa;Password=castro");
         
        }
        //End_YR
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Promocion>(entity =>
            {
                entity.ToTable("Promocion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            //configurar relaciones
            //YR_28102021 Descomentar
            //modelBuilder.Entity<Order>().HasOne<Customer>().WithMany().HasForeignKey(o => o.CustomerId);
            //modelBuilder.Entity<OrderDetail>().HasOne<Product>().WithMany().HasForeignKey(o => o.ProductId);

            //datos de prueba
            //modelBuilder.Entity<Product>().HasData(
            //    new Product { Id = 1, Name = "Chai" },
            //    new Product { Id = 2, Name = "Chang" },
            //    new Product { Id = 3, Name = "Aniseed Syrup" }
            //    );
            //modelBuilder.Entity<Customer>().HasData(
            //    new Customer { Id = "ALFKI", Name = "Alfreds. F." },
            //    new Customer { Id = "ANATR", Name = "Ana Trujillo" },
            //    new Customer { Id = "ANTON", Name = "Antonio Moreno" }
            //    );
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
