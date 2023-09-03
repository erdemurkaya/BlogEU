using System.ComponentModel.DataAnnotations;

namespace Blog.WebUI.Areas.Admin.Models.ViewModel
{
    public class PostAddOrEditVM
    {

        public int Id { get; set; }

        [Display(Name ="Yazı Başlığı"),Required(ErrorMessage ="Bir Yazı Başlığı Giriniz"),MaxLength(100,ErrorMessage ="Uzun Bir Yazı Başlığı Girdiniz")]
        public string Title { get; set; }
        [Display(Name = "İçerik"), Required(ErrorMessage = "Bir İçerik Giriniz"), MaxLength(100, ErrorMessage = "Uzun Bir İçerik  Girdiniz")]
        public string Content { get; set; }
        [Display(Name ="Görsel")]
        public IFormFile? File { get; set; }
        [Display(Name ="Kategori"),Required(ErrorMessage ="Bir Kategori Seçiniz")]
        public int CategoryId { get; set; }

    }
}
