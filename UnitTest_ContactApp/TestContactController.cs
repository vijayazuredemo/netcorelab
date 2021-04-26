using System;
using Xunit;
using EvolentHealth.Contact.WebApp;
using EvolentHealth.Contact.WebApp.Controllers;
using EvolentHealth.Contact.WebApp.Interfaces;
using EvolentHealth.Contact.WebApp.Models;
namespace UnitTest_ContactApp
{
    public class TestContactController
    {
        //private IContactList  _contact;
        private IContactList _IContactList;
        private Contact contact;
        public TestContactController()
        {
            contact = new Contact();
        }
        [Fact]
        public void Test_Index_View_Result()
        {
            var controller = new ContactController(_IContactList);
            //Act
            var result = controller.Index();
            //Assert
            Assert.IsType<Contact>(result);
        }


    }
}
