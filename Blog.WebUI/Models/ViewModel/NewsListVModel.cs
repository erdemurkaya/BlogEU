namespace Blog.WebUI.Models.ViewModel
{
    public class NewsListVModel
    {


        public int Id { get; set; }

        public string Title { get; set; }

        public string ImagePath { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? ReadCount { get; set; }

        public int? LikeCount { get; set; }


    }
}
