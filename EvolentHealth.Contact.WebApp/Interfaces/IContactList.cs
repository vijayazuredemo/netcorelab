using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvolentHealth.Contact.WebApp.Models;
namespace EvolentHealth.Contact.WebApp.Interfaces
{
    public interface IContactList
    {
        public IEnumerable<EvolentHealth.Contact.WebApp.Models.Contact> GetItems();

        public int AddUpdateContact(EvolentHealth.Contact.WebApp.Models.Contact contact, string Mode);
        public EvolentHealth.Contact.WebApp.Models.Contact GetItemByID(int itemID);

        public int DeleteContact(int itemID);
    }
}
