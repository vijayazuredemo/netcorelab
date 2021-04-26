using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using EvolentHealth.Contact.WebApp.Common;
using EvolentHealth.Contact.WebApp.Interfaces;
using EvolentHealth.Contact.WebApp.Models;
using Microsoft.Extensions.Configuration;

namespace EvolentHealth.Contact.WebApp.DataHelper
{
    public class CourseDataHelper:ICourses
    {
        //IConfiguration _configuration;
        public readonly BaseDataHelper<Models.Course> objCourse = new BaseDataHelper<Models.Course>();
        private readonly string connString;
        public CourseDataHelper(IConfiguration configuration)
        {
            connString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public int AddUpdateCourse(Course course, string Mode)
        {
            int result = 0;
            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@Id", course.Id);
                parameters.Add("@Name", course.Name);
                parameters.Add("@rating", course.rating);

                result = objCourse.AddUpdatedItem(parameters, "InsertCourse", connString);
            }
            catch (Exception ex)
            {
                // Error log here
            }
            return result;
        }

        public int DeleteCourse(int itemID)
        {
            return 1;
        }

        public Course GetItemByID(int itemID)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@courseId", itemID);
            return objCourse.GetItemByID(parameters, "GetCourseId", connString);
        }

        public IEnumerable<Course> GetItems()
        {
            //getCourseList
            return objCourse.GetItems("getCourseList", connString);
        }
    }
}
