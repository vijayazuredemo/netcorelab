using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using EvolentHealth.Contact.WebApp.Common;
using EvolentHealth.Contact.WebApp.Interfaces;
using Microsoft.Extensions.Configuration;

namespace EvolentHealth.Contact.WebApp.DataHelper
{
    public class ContactDataHelper : IContactList
    {
        //IConfiguration _configuration;
        public readonly BaseDataHelper<Models.Contact> objContact = new BaseDataHelper<Models.Contact>();
        private readonly string connString;
        public ContactDataHelper(IConfiguration configuration)
        {
            connString = configuration["ConnectionStrings:DefaultConnection"]; 
        }
        public int AddUpdateContact(Models.Contact contact, string Mode)
        {
            int result = 0;
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@firstname", contact.FirstName);
                parameters.Add("@lastName", contact.LastName);
                parameters.Add("@email", contact.Email);
                parameters.Add("@phoneNumber", contact.PhoneNumber);
                string spName = Mode.ToLower() == "edit" ? DBConstants.SP_UpdateContact : DBConstants.SP_InsertContact;
                if(Mode.ToLower()=="edit") parameters.Add("@ContatcID", contact.ContactID);

                result =objContact.AddUpdatedItem(parameters, spName, connString);
            }
            catch(Exception ex)
            {
                // Error log here
            }
            return result;
        }

        public int DeleteContact(int itemID)
        {
            int result = 0;
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@contatcId", itemID);
                parameters.Add("@status", 0);
                result = objContact.AddUpdatedItem(parameters, DBConstants.SP_DeleteContact, connString);
            }
            catch (Exception ex)
            {
                // Error log here
            }
            return result;
        }

        public Models.Contact GetItemByID(int itemID)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@contatcId", itemID);
            return objContact.GetItemByID(parameters,DBConstants.SP_GetContactByID,connString);
        }

        public IEnumerable<Models.Contact> GetItems()
        {
            return objContact.GetItems(DBConstants.SP_GetContacts, connString);
        }
    }
}
