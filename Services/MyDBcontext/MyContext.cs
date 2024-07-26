using Entities;
using Microsoft.EntityFrameworkCore;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options)
    {
    }

    public DbSet<Bus_Routes> Routes { get; set; }
    public DbSet<Ticket> Tickets { get; set; }

    public DbSet<Menu> Menus { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bus_Routes>()
             .HasKey(r => r.Id_Bus_Routes);

        modelBuilder.Entity<Ticket>()
         .HasKey(r => r.Id_Ticket);

        modelBuilder.Entity<Menu>()
        .HasKey(r => r.Id_Menu);

        modelBuilder.Entity<Bus_Routes>()
            .HasMany(r => r.Tickets)
            .WithOne(t => t.Bus_Routes)
            .HasForeignKey(t => t.Id_Bus_Routes);


     modelBuilder.Entity<Bus_Routes>().HasData(
      new Bus_Routes { Id_Bus_Routes = 1, From = "Nicoya", To = "Santa Cruz", Price = 500 },
      new Bus_Routes { Id_Bus_Routes = 2, From = "Liberia", To = "Santa Cruz", Price = 1000 },
      new Bus_Routes { Id_Bus_Routes = 3, From = "Nicoya", To = "Liberia", Price = 1500 }
  );
    }
}
