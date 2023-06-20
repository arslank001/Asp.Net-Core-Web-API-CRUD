using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfulAPIs_Asp.netCore.Data;
using RestfulAPIs_Asp.netCore.Models;

namespace RestfulAPIs_Asp.netCore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationContext context;
        public StudentController(ApplicationContext context)
        {
            this.context = context; 
        }

        [HttpGet]
        [Route("GetAllStudents")]
        public IActionResult GetAllStudents()
        {
            var StdData = context.Student.ToList();
            if (StdData.Count() == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(StdData);
            }
        }

        [Route("GetStudentById/{id}")]
        public IActionResult GetStudentById(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                var StdsData = context.Student.Where(e => e.StudentID == id).SingleOrDefault();
                if (StdsData == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(StdsData);
                }
            }
        }

        [HttpPost]
        [Route("AddStudent")]
        public IActionResult AddStudent([FromBody] StudentModel StdModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var StdData = new StudentModel
                {
                    RegistrationNo = StdModel.RegistrationNo,
                    Name = StdModel.Name,
                    Gender = StdModel.Gender,
                    IsActive = StdModel.IsActive
                };
                context.Student.Add(StdData);
                context.SaveChanges();
                return Ok(StdData);
            }
        }

        [HttpPut]
        [Route("UpdateStudent")]
        public IActionResult UpdateStudent([FromBody] StudentModel StdModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var StdData = context.Student.Where(e=>e.StudentID == StdModel.StudentID).SingleOrDefault();
                if (StdData == null)
                {
                    return BadRequest();
                }
                else
                {
                    //FIRST WAY
                    StdData.RegistrationNo = StdModel.RegistrationNo;
                    StdData.Name = StdModel.Name;
                    StdData.Gender = StdModel.Gender;
                    StdData.IsActive = StdModel.IsActive;

                    //2ND WAY
                    //var StdData = new StudentModel
                    //{
                    //    RegistrationNo = StdModel.RegistrationNo,
                    //    Name = StdModel.Name,
                    //    Gender = StdModel.Gender,
                    //    IsActive = StdModel.IsActive
                    //};
                    context.Student.Update(StdData);
                    context.SaveChanges();
                    return Ok();
                }
            }
        }

        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            if (id != 0)
            {
                var StdData = context.Student.Where(e => e.StudentID == id).SingleOrDefault();
                if (StdData == null)
                {
                    return BadRequest();
                }
                else
                {
                    context.Student.Remove(StdData);
                    context.SaveChanges();
                }
            }
            else
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
