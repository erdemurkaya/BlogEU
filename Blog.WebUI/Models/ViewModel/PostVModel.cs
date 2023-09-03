namespace Blog.WebUI.Models.ViewModel
{
    public class PostVModel
    {

        public int Id { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        public string ImagePath { get; set; }

        public int CategoryId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
