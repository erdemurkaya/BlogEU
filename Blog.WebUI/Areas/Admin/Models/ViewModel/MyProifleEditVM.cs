using System.ComponentModel.DataAnnotations;

namespace Blog.WebUI.Areas.Admin.Models.ViewModel
{
    public class MyProifleEditVM
    {
        public int Id { get; set; }

        [Display(Name ="İsim"),Required(ErrorMessage ="İsim Alanını Doldurmalısınız"),MaxLength(100,ErrorMessage ="Uzun Bir İsim Girdiniz")]
        public string Name { get; set; }
        [Display(Name = "Soyisim"), Required(ErrorMessage = "Soyisim Alanını Doldurmalısınız"), MaxLength(100, ErrorMessage = "Uzun Bir Soyisim Girdiniz")]
        public string LastName { get; set; }

        [Display(Name = "Instagram Adresi")]
        public string InstagramUrl { get; set; }
        [Display(Name = "Github Adresi")]
        public string GithubUrl { get; set; }

        [Display(Name = "LinkedIn Adresi")]
        public string LinkedInUrl { get; set; }
        [Display(Name = "Profil Açıklaması"), Required(ErrorMessage = "Açıklama Alanını Doldurunuz")]
        public string Description { get; set; }
    }
}
