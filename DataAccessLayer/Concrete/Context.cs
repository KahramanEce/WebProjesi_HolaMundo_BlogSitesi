using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=ECE\\SQLSV;database=BlogProject;integrated security=true;Encrypt=false");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Like>()
                .HasOne(x => x.Blog)
                .WithMany(y => y.Likes)
                .HasForeignKey(z => z.BlogID)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Like>()
                .HasOne(x => x.AppUser)
                .WithMany(y => y.Likes)
                .HasForeignKey(z => z.AppUserID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            //modelBuilder.Entity<UserFollwedCat>()
            //    .HasOne(x => x.AppUser)
            //    .WithMany(y => y.UserFollwedCats)
            //    .HasForeignKey(z => z.AppUserID)
            //    .OnDelete(DeleteBehavior.ClientSetNull);
            //modelBuilder.Entity<FollwedCat>()
            //    .HasOne(x => x.Category)
            //    .WithMany(y => y.FollwedCats)
            //    .HasForeignKey(z => z.CategoryID)
            //    .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message>()
                .HasOne(x => x.SenderUser)
                .WithMany(y => y.UserSender)
                .HasForeignKey(z => z.SenderID)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Message>()
                .HasOne(x => x.ReceiverUser)
                .WithMany(y => y.UserReceiver)
                .HasForeignKey(z => z.ReceiverID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Comment>()
             .HasOne(x => x.AppUser)
             .WithMany(y => y.Comments)
             .HasForeignKey(z => z.AppUserID)
             .OnDelete(DeleteBehavior.ClientSetNull);
      

            base.OnModelCreating(modelBuilder);
        }


        //context ler:

        public DbSet<BlogAbout> BlogAbouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<NewsLetters> NewsLetterss { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Like> Likes { get; set; }
        //public DbSet<FollwedCat> FollwedCats { get; set; }



    }
}

