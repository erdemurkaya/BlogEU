using System.ComponentModel.DataAnnotations;

namespace Blog.WebUI.Areas.Admin.Models.ViewModel
{
    public class NewsAddOrUpdateVM
    {

        public int Id { get; set; }

        [Display(Name ="Haber Başlığı"),Required(ErrorMessage ="Bir Başlık Giriniz"),MaxLength(100,ErrorMessage ="Çok Uzun Bir Başlık Girdiniz")] 
        public string Title { get; set; }

        [Display(Name ="Haber İçeriği"),Required(ErrorMessage = "Bir İçerik Giriniz"), MaxLength(1000, ErrorMessage = "Çok Uzun Bir İçerik Girdiniz")]
        public string Content { get; set; }
        [Display(Name ="Görsel")]
        public IFormFile? File { get; set; }


    }
}
