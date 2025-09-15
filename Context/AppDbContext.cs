using Microsoft.EntityFrameworkCore;
using WebApplication_NET_CORE.Entities;

namespace WebApplication_NET_CORE.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users => Set<User>();
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<SaleDetail> SaleDetails => Set<SaleDetail>();
        public DbSet<Role> Roles => Set<Role>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureRoleModel(modelBuilder);
            ConfigureSellerModel(modelBuilder);

            ConfigureUserModel(modelBuilder);
            ConfigureAuthorModel(modelBuilder);
            ConfigureCategoryModel(modelBuilder);
            ConfigureBookModel(modelBuilder);
            ConfigureSaleModel(modelBuilder);
            ConfigureSaleDetailModel(modelBuilder);
        }
        private static void ConfigureRoleModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(r => r.RoleId);

                entity.Property(r => r.RoleName)
                .HasMaxLength(20);

                entity.Property(r => r.RoleDescription)
                .HasMaxLength(200);

                entity.HasData(
                    new Role()
                    {
                        RoleId = 1,
                        RoleName = "Customer",
                        RoleDescription = "Cliente, comprador, o usuario"
                    },
                    new Role()
                    {
                        RoleId = 2,
                        RoleName = "Seller",
                        RoleDescription = "Empleado, cajero"
                    });
            });
        }
        private static void ConfigureSellerModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seller>(entity =>
            {
                entity.HasKey(s => s.SellerId);

                entity.Property(s => s.SellerName)
                .HasMaxLength(200);

                entity.Property(s => s.CreatedDate)
                .HasColumnType("timestamp")
                .HasDefaultValueSql("NOW()");

                entity.Property(s => s.UpdatedDate)
                .HasColumnType("timestamp")
                .HasDefaultValueSql("NOW()");

                entity.HasOne(s => s.Role)
                .WithMany(r => r.Sellers)
                .HasForeignKey(s => s.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasData(new Seller()
                {
                    SellerId = 1,
                    SellerName = "Nicolas Bravo",
                    RoleId = 2
                });
            });
        }
        private static void ConfigureUserModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId);

                entity.Property(u => u.FullName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(u => u.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(u => u.CreatedDate)
                .HasColumnType("timestamp")
                .HasDefaultValueSql("NOW()");

                entity.HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasData(new User
                {
                    UserId = 1,
                    FullName = "Jhon Smith",
                    Email = "jhon@gmail.com",
                    Password = "123123",
                    RoleId = 1
                });
            });
        }
        private static void ConfigureAuthorModel(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(a => a.AuthorId);

                entity.Property(a => a.AuthorName)
                .IsRequired()
                .HasMaxLength(100);

                entity.HasData(new Author
                {
                    AuthorId = 1,
                    AuthorName = "Author de a mentis",
                });
            });
        }
        private static void ConfigureCategoryModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.CategoryId);

                entity.Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(100);

            });
        }
        private static void ConfigureBookModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(b => b.BookId);

                entity.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(b => b.Subtitle)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(b => b.Description)
                .HasColumnType("text")
                .IsRequired();

                entity.Property(b => b.Price)
                .HasColumnType("decimal(6,2)")
                .IsRequired();

                entity.Property(b => b.PublishDate)
                .HasColumnType("timestamp");

                entity.HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(b => b.Title);
                entity.HasIndex(b => b.AuthorId);
                entity.HasIndex(b => b.CategoryId);
            });
        }
        private static void ConfigureSaleModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(s => s.SaleId);

                entity.Property(s => s.DateSale)
                .HasColumnType("timestamp")
                .HasDefaultValueSql("NOW()");

                entity.HasOne(s => s.User)
                .WithMany(u => u.Sales)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(s => s.UserId);
            });
        }
        private static void ConfigureSaleDetailModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SaleDetail>(entity =>
            {
                entity.HasKey(sd => new {sd.SaleId, sd.BookId});

                entity.Property(sd => sd.Quantity)
                .IsRequired();

                entity.Property(sd => sd.Price)
                .HasColumnType("decimal(6,2)");

                entity.HasOne(sd => sd.Sale)
                .WithMany(s => s.Details)
                .HasForeignKey(sd => sd.SaleId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(sd => sd.Book)
                .WithMany(b => b.Details)
                .HasForeignKey(sd => sd.BookId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(sd => sd.SaleId);
                entity.HasIndex(sd => sd.BookId);
            });
        }
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(e =>
            {
                e.HasKey("UserId");
                e.Property("UserId").ValueGeneratedOnAdd();
                e.HasData(
                    new User() { UserId = 1,FullName="Jhon Smith",Email="Jhon@gmail.com",Password="123"}
                    );
            });

            modelBuilder.Entity<Service>(e =>
            {
                e.HasKey("ServiceId");
                e.Property("ServiceId").ValueGeneratedOnAdd();
                e.HasOne(e => e.User).WithMany(u => u.Services).HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Transaction>(e =>
            {
                e.HasKey("TransactionId");
                e.Property("TransactionId").ValueGeneratedOnAdd();
                e.Property("Date").HasColumnType("date");
                e.Property("TotalAmount").HasColumnType("decimal(10,2)");
                e.HasOne(e => e.Service).WithMany().HasForeignKey(e => e.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(e => e.User).WithMany(u => u.Transactions).HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            });
        }
        */
    }
}
