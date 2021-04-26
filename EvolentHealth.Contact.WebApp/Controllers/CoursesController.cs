using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvolentHealth.Contact.WebApp.Models;
using EvolentHealth.Contact.WebApp.Interfaces;
namespace EvolentHealth.Contact.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {

        ICourses _ICourse;
        public CoursesController(ICourses ICourses)
        {
            _ICourse = ICourses;
        }


        [HttpGet]
        public IEnumerable<Course> GetCourse()
        {
            List<EvolentHealth.Contact.WebApp.Models.Course> lstCourse = new List<EvolentHealth.Contact.WebApp.Models.Course>();
                return lstCourse = _ICourse.GetItems().ToList();
        }

        [HttpGet("{id}")]
        public Course Details(int id)
        {
            EvolentHealth.Contact.WebApp.Models.Course course = _ICourse.GetItemByID(id);
           
            return course;
        }
        [HttpPost]
        public int PostCourse(Course course)
        {
            int result = _ICourse.AddUpdateCourse(course,"New");

            return result;
        }

        
    }
}
