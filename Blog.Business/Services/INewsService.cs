using Blog.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Services
{
    public interface INewsService
    {

        void AddNews(NewsAddOrEditDto news);

        void UpgradeNews(NewsAddOrEditDto news);

        void DeleteNews(int id);

        NewsDto GetNewsById(int id);

        List<NewsListDto> GetAllNews();

        NewsDto LastNews();

        List<NewsListDto> GetNewsOrderBy();

        NewsDto GetDetailNews(int id);





    }
}
