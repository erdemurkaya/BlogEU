using Blog.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities.Concrate
{
    public class PostEntity:BaseEntity
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Image { get; set; }

        public int? LikeCount { get; set; }

        public int? ReadCount { get; set; }

        public int CategoryId { get; set; }

        public CategoryEntity Category { get; set; }

        public virtual ICollection<CommentEntity> Comments { get; set; }

    }



    public class PostConfiguration:BaseConfiguration<PostEntity>
    {

        public override void Configure(EntityTypeBuilder<PostEntity> builder)
        {
            
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);

            builder.Property(x => x.Content).IsRequired();

            builder.Property(x=>x.Image).IsRequired(false);

            builder.Property(x=>x.LikeCount).IsRequired(false);

            builder.Property(x=>x.ReadCount).IsRequired(false);

            







        }

    }


}
