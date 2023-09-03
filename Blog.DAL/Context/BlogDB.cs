using Blog.Entities.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Context
{
    public class BlogDB : DbContext
    {
        public BlogDB(DbContextOptions<BlogDB> options) : base(options)
        {

        }


        public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();

        public DbSet<PostEntity> Posts => Set<PostEntity>();

        public DbSet<CommentEntity> Comments => Set<CommentEntity>();

        public DbSet<NewsEntity> News => Set<NewsEntity>();

        public DbSet<MyProfileEntity> MyProfiles => Set<MyProfileEntity>();

        public DbSet<ContactEntity> Contacts => Set<ContactEntity>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.ApplyConfiguration(new PostConfiguration());

            modelBuilder.ApplyConfiguration(new CommentConfiguration());

            modelBuilder.ApplyConfiguration(new NewsConfiguration());

            


            modelBuilder.Entity<PostEntity>().HasOne(x => x.Category).WithMany(x => x.Posts);

            modelBuilder.Entity<CommentEntity>().HasOne(x => x.Post).WithMany(x => x.Comments);


            modelBuilder.Entity<MyProfileEntity>().HasData(new MyProfileEntity()
            {
                Id = 1,
                CreatedDate = DateTime.Now,
                Name="Erdem",
                LastName="Urkaya",
                GithubUrl="Boş",
                LinkedInUrl="Boş",
                InstagramUrl="Boş",
                Description="Boş",
                IsActive=true
                

            });


        }

    }
}
