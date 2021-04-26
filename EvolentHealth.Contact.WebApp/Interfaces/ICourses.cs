using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvolentHealth.Contact.WebApp.Interfaces
{
    public interface ICourses
    {

        public IEnumerable<EvolentHealth.Contact.WebApp.Models.Course> GetItems();

        public int AddUpdateCourse(EvolentHealth.Contact.WebApp.Models.Course course, string Mode);
        public EvolentHealth.Contact.WebApp.Models.Course GetItemByID(int itemID);

        public int DeleteCourse(int itemID);
    }
}
