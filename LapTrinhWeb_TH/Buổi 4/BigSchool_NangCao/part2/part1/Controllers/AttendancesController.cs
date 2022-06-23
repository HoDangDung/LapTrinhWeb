using Microsoft.AspNet.Identity;
using part1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace part1.Controllers
{
    public class AttendancesController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Attend(Course courseDTO)
        {
            var userID = User.Identity.GetUserId(); //get login user
            if(userID == null)
            {
                return BadRequest("Please login first!");
            }
            BigSchoolContext context = new BigSchoolContext();
            var attendance = new Attendance()
            {
                CourseId = courseDTO.Id,
                Attendee = userID //người đăng kí khóa học chính login user
            };
            context.Attendances.Add(attendance);
            context.SaveChanges();
            return Ok();
        }
    }
}
