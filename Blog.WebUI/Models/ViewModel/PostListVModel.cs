namespace Blog.WebUI.Models.ViewModel
{
    public class PostListVModel
    {


        public int Id { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        public string ImagePath { get; set; }

        public int? LikeCount { get; set; }

        public int? ReadCount { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CategoryId { get; set; }
    }
}
