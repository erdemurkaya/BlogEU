using Blog.Business.Dtos;
using Blog.Business.Services;
using Blog.DAL.Abstract;
using Blog.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Managers
{
    public class PostManager : IPostService
    {
        private readonly IRepository<PostEntity> _postRepository;

        public PostManager(IRepository<PostEntity> postRepository)
        {
            _postRepository = postRepository;
        }


        public void AddPost(PostAddOrEditDto post)
        {
            
            var posts=_postRepository.GetAll();

            var postEntity = new PostEntity()
            {
                Title = post.Title,
                Content = post.Content,
                CategoryId = post.CategoryId,
                Image=post.ImagePath
                
            };

            _postRepository.Add(postEntity);

        }

        public void DeletePost(int id)
        {
            
            var post= _postRepository.GetById(id);

            _postRepository.Delete(post);

        }

        public List<PostListDto> GetAllPosts()
        {
            
            var posts=_postRepository.GetAll(x=>x.IsActive==true&&x.IsDeleted==false);


            var postDtos = posts.Select(x => new PostListDto()
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                CategoryId = x.CategoryId,
                CreatedDate = x.CreatedDate,
                ImagePath = x.Image,
                LikeCount = x.LikeCount,
                ReadCount = x.ReadCount
            }).ToList();

            return postDtos;

        }

        public List<PostDto> GetCategoryListById(int? categoryId = null)
        {
            throw new NotImplementedException();
        }

        public PostDto GetDetailPost(int id)
        {
            var entity=_postRepository.GetById(id);

            var postDto = new PostDto()
            {
                Title = entity.Title,
                Content = entity.Content,
                ImagePath = entity.Image,
                CreatedDate = entity.CreatedDate
            };

            return postDto;

        }

        public PostDto GetPostById(int id)
        {
            var post=_postRepository.GetById(id);

            var postDto = new PostDto()
            {
                Id=post.Id,
                Title = post.Title,
                Content = post.Content,
                CategoryId = post.CategoryId,
                ImagePath = post.Image,
            };

            return postDto;
        }

        public List<PostListDto> GetPostOrderBy()
        {
            var listEntity = _postRepository.GetAll(x => x.IsDeleted == false && x.IsActive == true).OrderByDescending(x=>x.CreatedDate).Take(5).ToList();

            var postListDto = listEntity.Select(x => new PostListDto()
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                CategoryId = x.CategoryId,
                ImagePath = x.Image,
                CreatedDate = x.CreatedDate
            }).ToList();

            return postListDto;

        }

        public PostDto LastPost()
        {

            var lastEntity = _postRepository.GetAll(x=>x.IsDeleted==false&&x.IsActive==true).OrderBy(x => x.CreatedDate).FirstOrDefault();

            if(lastEntity == null)
            {
                return null;
            }
            else
            {
                var postDto = new PostDto()
                {
                    Id = lastEntity.Id,
                    Title = lastEntity.Title,
                    Content = lastEntity.Content,
                    CategoryId = lastEntity.CategoryId,
                    ImagePath = lastEntity.Image,
                    CreatedDate = lastEntity.CreatedDate
                };

                return postDto;
            }

            

        }

        public void UpdatePost(PostAddOrEditDto post)
        {

            var postEntity = _postRepository.GetById(post.Id);

            postEntity.Title = post.Title;
            postEntity.Content = post.Content;
            postEntity.Image = post.ImagePath;
            postEntity.CategoryId = post.CategoryId;
            
            _postRepository.Update(postEntity);



        }
    }
}
