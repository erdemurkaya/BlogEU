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
    public class AboutManager : IAboutService
    {

        private readonly IRepository<MyProfileEntity> _repository;

        public AboutManager(IRepository<MyProfileEntity> repository)
        {
            _repository = repository;
        }

        public AboutDto About(int id=1)
        {
            
            var entity=_repository.GetById(id);


            var aboutDto = new AboutDto()
            {
                Name = entity.Name,
                LastName = entity.LastName,
                LinkedInUrl = entity.LinkedInUrl,
                InstagramUrl = entity.InstagramUrl,
                GithubUrl = entity.GithubUrl,
                Description = entity.Description
            };


            return aboutDto;


        }
    }
}
