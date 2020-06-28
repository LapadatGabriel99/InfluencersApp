using BusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IContactService
    {
        public Task<ICollection<ContactsViewModel>> GetListOfContactsViewModels();
    }
}
