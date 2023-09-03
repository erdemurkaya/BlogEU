using Blog.Business.Dtos;
using Blog.Business.Services;
using Blog.DAL.Abstract;
using Blog.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Managers
{
    public class NewsManager : INewsService
    {

        private readonly IRepository<NewsEntity> _newsRepository;

        public NewsManager(IRepository<NewsEntity> newsRepository)
        {
            _newsRepository = newsRepository;
        }


        public void AddNews(NewsAddOrEditDto news)
        {

            NewsEntity entity = new NewsEntity()
            {
                Title = news.Title,
                Content = news.Content,
                Image = news.ImagePath,
                

            };

            _newsRepository.Add(entity);

        }

        public void DeleteNews(int id)
        {
            var news=_newsRepository.GetById(id);

            _newsRepository.Delete(news);
        }

        public List<NewsListDto> GetAllNews()
        {

            var newsList = _newsRepository.GetAll(x=>x.IsActive==true&&x.IsDeleted==false);

            var newsDto=newsList.Select(x=>new NewsListDto()
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                CreatedDate = x.CreatedDate,
                LikeCount=x.LikeCount,
                ReadCount=x.ReadCount,
                ImagePath=x.Image

            }).ToList();

            return newsDto;
        }

        public NewsDto GetDetailNews(int id)
        {
            var entity=_newsRepository.GetById(id);

            var newsDto = new NewsDto()
            {
                Id = entity.Id,
                Content = entity.Content,
                Image = entity.Image,
                Title = entity.Title
            };

            return newsDto;


        }

        public NewsDto GetNewsById(int id)
        {
            var news=_newsRepository.GetById(id);

            var newsDto = new NewsDto()
            {
                Id = news.Id,
                Title = news.Title,
                Content = news.Content,
                Image = news.Image,
            };

            return newsDto;

        }

        public List<NewsListDto> GetNewsOrderBy()
        {


            var listEntity = _newsRepository.GetAll(x=>x.IsDeleted==false && x.IsActive==true).OrderByDescending(x => x.CreatedDate).Take(5).ToList();

            var newsListDto = listEntity.Select(x => new NewsListDto()
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,                
                ImagePath = x.Image,
                CreatedDate = x.CreatedDate
            }).ToList();

            return newsListDto;
        }

        public NewsDto LastNews()
        {
            var lastEntity = _newsRepository.GetAll(x=>x.IsDeleted==false&&x.IsActive==true).OrderBy(x => x.CreatedDate).FirstOrDefault();

            if(lastEntity != null)
            {
                var newsDto = new NewsDto()
                {
                    Id = lastEntity.Id,
                    Title = lastEntity.Title,
                    Content = lastEntity.Content,
                    Image = lastEntity.Image

                };

                return newsDto;
            }
            else
            {
                return null;
            }

            
        }

        public void UpgradeNews(NewsAddOrEditDto news)
        {

            var entity = _newsRepository.Get(x => x.Id == news.Id);


            entity.Title = news.Title;
            entity.Content = news.Content;

            if (news.ImagePath != null)
            {
                entity.Image = news.ImagePath;
            }

            _newsRepository.Update(entity);


        }
    }
}
