using Blog.Business.Dtos;
using Blog.Business.Services;
using Blog.WebUI.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }


        [HttpGet]
        public IActionResult Send()
        {

            return View(new ContactVM());
        }

        [HttpPost]
        public IActionResult Send(ContactVM formData)
        {

            var dto = new ContactDto()
            {
                NameAndLastName = formData.NameAndLastName,
                Email = formData.Email,
                Subject = formData.Subject,
                Message = formData.Message
            };

            _contactService.SendMessage(dto);

            return RedirectToAction("Index");
        }

    }
}
