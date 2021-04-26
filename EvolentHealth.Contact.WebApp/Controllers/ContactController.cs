using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using EvolentHealth.Contact.WebApp.Models;
using EvolentHealth.Contact.WebApp.Interfaces;
namespace EvolentHealth.Contact.WebApp.Controllers
{

    /// <summary>
    /// This controller is used to manage contact  list i.e add, edit, delete, view
    /// </summary>
    public class ContactController : Controller
    {
        IContactList _IContactList;
        public ContactController(IContactList IContactList)
        {
            _IContactList = IContactList;
        }

        #region "View Contact List"
        public IActionResult Index()
        {
            List<EvolentHealth.Contact.WebApp.Models.Contact> lstContact = new List<EvolentHealth.Contact.WebApp.Models.Contact>();
            lstContact = _IContactList.GetItems().ToList();
            return View(lstContact);
        }

        #endregion


        #region "Add Contact"
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] EvolentHealth.Contact.WebApp.Models.Contact contact)
        {
            if (ModelState.IsValid)
            {
                _IContactList.AddUpdateContact(contact, "New");
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        #endregion


        #region "Edit Contact"
        [HttpGet]
        public IActionResult Edit(int id)
        {
            EvolentHealth.Contact.WebApp.Models.Contact contact = _IContactList.GetItemByID(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] EvolentHealth.Contact.WebApp.Models.Contact contact)
        {
            if (ModelState.IsValid)
            {
                _IContactList.AddUpdateContact(contact,"edit");
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        #endregion


        #region "Delete Contact"
        [HttpGet]
        public IActionResult Delete(int id)
        {
            EvolentHealth.Contact.WebApp.Models.Contact contact = _IContactList.GetItemByID(id);

            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _IContactList.DeleteContact(id);
            return RedirectToAction("Index");
        }

        #endregion


        #region "Details Contact"

        [HttpGet]
        public IActionResult Details(int id)
        {
            EvolentHealth.Contact.WebApp.Models.Contact contact = _IContactList.GetItemByID(id);

            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        #endregion

    }
}
