using Blog.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities.Concrate
{
    public class CommentEntity:BaseEntity
    {
        public string Email { get; set; }

        public string NameAndLastName { get; set; }

        public string Content { get; set; }

        public int PostId { get; set; }

        public PostEntity Post { get; set; }

    }

    public class CommentConfiguration:BaseConfiguration<CommentEntity>
    {

        public override void Configure(EntityTypeBuilder<CommentEntity> builder)
        {

            builder.Property(x => x.Email).IsRequired();

            builder.Property(x=>x.NameAndLastName).IsRequired().HasMaxLength(100);

            builder.Property(x=>x.Content).IsRequired().HasMaxLength(1000);


        }

    }


}
