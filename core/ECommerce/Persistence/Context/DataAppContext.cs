using ECommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Context
{
    public class DataAppContext: DbContext
    {

        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Item> Items { get; set; }
        
        public DataAppContext(DbContextOptions<DataAppContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(@"Server=127.0.0.1; port=5432; user id=postgres; password=postgres; database=ecommerce;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            

            //model of  users
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasKey(p => p.Id);
            modelBuilder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(p => p.Cpf).IsRequired().HasMaxLength(11);
            modelBuilder.Entity<User>().HasAlternateKey(p => p.Cpf);
            modelBuilder.Entity<User>().Property(p => p.Name).IsRequired().HasMaxLength(45);
            modelBuilder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(45);
            modelBuilder.Entity<User>().HasAlternateKey(p => p.Email);
            modelBuilder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(16);
            modelBuilder.Entity<User>().HasMany(p => p.Purchases).WithOne(p => p.User).HasForeignKey(p => p.UserId);

            //model of companies
            modelBuilder.Entity<Company>().ToTable("Companies");
            modelBuilder.Entity<Company>().HasKey(p => p.Id);
            modelBuilder.Entity<Company>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Company>().HasAlternateKey(p => p.Cnpj);
            modelBuilder.Entity<Company>().HasAlternateKey(p => p.CorporateName);
            modelBuilder.Entity<Company>().Property(p => p.Cnpj).IsRequired().HasMaxLength(14);
            modelBuilder.Entity<Company>().Property(p => p.CorporateName).IsRequired().HasMaxLength(45);
            modelBuilder.Entity<Company>().Property(p => p.FantasyName).IsRequired().HasMaxLength(45);
            modelBuilder.Entity<Company>().HasMany(p => p.Products).WithOne(p => p.Company)
                .HasForeignKey(p => p.CompanyId);

            //model of Products
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Product>().Property(p => p.Description).IsRequired().HasMaxLength(2048);
            modelBuilder.Entity<Product>().Property(p => p.Observation).IsRequired().HasMaxLength(1024);
            modelBuilder.Entity<Product>().Property(p => p.Price).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.ImageUri).IsRequired();
            modelBuilder.Entity<Product>().HasOne(p => p.Company).WithMany(p => p.Products)
                .HasForeignKey(p => p.CompanyId).IsRequired().OnDelete(DeleteBehavior.Cascade);
   
            
            //model of purchases
            modelBuilder.Entity<Purchase>().ToTable("Purchases");
            modelBuilder.Entity<Purchase>().HasKey(p => p.Id);
            modelBuilder.Entity<Purchase>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Purchase>().Property(p => p.Date).IsRequired().HasDefaultValueSql("now()");
            modelBuilder.Entity<Purchase>().Property(p => p.Price).IsRequired();
            modelBuilder.Entity<Purchase>().Property(p => p.Address).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Purchase>().Property(p => p.PostalCode).IsRequired().HasMaxLength(8);
            modelBuilder.Entity<Purchase>().Property(p => p.Observation).HasMaxLength(255);
            modelBuilder.Entity<Purchase>().Property(p => p.StatusPurchase).IsRequired();
            modelBuilder.Entity<Purchase>().Property(p => p.FormatOfPayment).IsRequired();
            modelBuilder.Entity<Purchase>().HasMany<Item>(p => p.Items).WithOne(p => p.Purchase)
                .HasForeignKey(p => p.PurchaseId).OnDelete(DeleteBehavior.Cascade);
          
            
            //model relashionship between product and purchase
            modelBuilder.Entity<Item>().ToTable("Items");
            modelBuilder.Entity<Item>().HasKey(p => new {p.PurchaseId, p.ProductId});
            modelBuilder.Entity<Item>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Item>().Property(p => p.Quantity).IsRequired().HasDefaultValue(0);
            
        }
       }
    }
