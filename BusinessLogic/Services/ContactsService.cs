using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ContactsService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactsService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        
        public async Task<ICollection<ContactsViewModel>> GetListOfContactsViewModels()
        {
            //TODO: Better function naming :)

            var contacts = await _contactRepository.GetAll();            

            ICollection<ContactsViewModel> contactsViewModelList = new List<ContactsViewModel>();

            contacts.ToList().ForEach(a =>
            {
                contactsViewModelList.Add(new ContactsViewModel { ContactEmail = a.ContactEmail, MailService = a.MailService});
            });

            return contactsViewModelList;
        }
    }
}
