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
    public class MyProfileManager : IMyProfileService
    {

        private readonly IRepository<MyProfileEntity> _profileRepository;

        public MyProfileManager(IRepository<MyProfileEntity> profileRepository)
        {
            _profileRepository = profileRepository;
        }


        public MyProfileDto GetProfileById(int id=1)
        {
            var profile =_profileRepository.GetById(id);

            var profileDto = new MyProfileDto()
            {
                Id = profile.Id,
                Name = profile.Name,
                LastName = profile.LastName,
                Description = profile.Description,
                GithubUrl = profile.GithubUrl,
                InstagramUrl = profile.InstagramUrl,
                LinkedInUrl = profile.LinkedInUrl
            };

            return profileDto;


        }

        public void UpdateProfile(MyProfileEditDto myProfile)
        {
            var profile=_profileRepository.GetById(myProfile.Id);

            profile.Name = myProfile.Name;
            profile.LastName = myProfile.LastName;
            profile.Description = myProfile.Description;
            profile.GithubUrl = myProfile.GithubUrl;
            profile.LinkedInUrl = myProfile.LinkedInUrl;
            myProfile.InstagramUrl = myProfile.InstagramUrl;


            _profileRepository.Update(profile);


        }
    }
}
