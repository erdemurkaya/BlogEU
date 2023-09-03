using Blog.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities.Concrate
{
    public class CategoryEntity:BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<PostEntity> Posts { get; set; }

    }


    public class CategoryConfiguration : BaseConfiguration<CategoryEntity>
    {
        public override void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {


            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            builder.Property(x=>x.Description).IsRequired(false).HasMaxLength(1000);


        }
    }

}
