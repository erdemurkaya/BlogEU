using Blog.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Services
{
    public interface IMyProfileService
    {

        void UpdateProfile(MyProfileEditDto myProfile);

        MyProfileDto GetProfileById(int id);


    }
}
