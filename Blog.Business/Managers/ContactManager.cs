using Blog.Business.Dtos;
using Blog.Business.Services;
using Blog.DAL.Abstract;
using Blog.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Managers
{
    public class ContactManager : IContactService
    {

        private readonly IRepository<ContactEntity> _repository;

        public ContactManager(IRepository<ContactEntity> repository)
        {
            _repository = repository;
        }

        public void SendMessage(ContactDto contact)
        {

            var entity = new ContactEntity()
            {
                NameAndLastName = contact.NameAndLastName,
                Subject = contact.Subject,
                Email = contact.Email,
                Message = contact.Message
            };


            _repository.Add(entity);

        }
    }
}
