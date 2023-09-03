using System.ComponentModel.DataAnnotations;

namespace Blog.WebUI.Areas.Admin.Models.ViewModel
{
    public class CategoryAddOrEditVM
    {

        public int Id { get; set; }

        [Display(Name ="Kategori Adı"),Required(ErrorMessage ="Kategori Adı Girmelisiniz"),MaxLength(100,ErrorMessage ="Uzun Bir Kategori Adı Girdiniz")]
        public string Name { get; set; }
        [Display(Name ="Açıklama"),MaxLength(1000,ErrorMessage ="Uzun Bir Açıklama Girdiniz")]
        public string Description { get; set; }

    }
}
