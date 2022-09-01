using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Net;
using ToDoApi.Entities;

namespace ToDoApi.Controllers
{
    [Helper.Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly StudentService _StudentService;

        public StudentController(StudentService toToService)
        {
            this._StudentService = toToService;
        }
        [HttpGet]
        public ActionResult<List<StudentItem>> Get()
        {
            var r = _StudentService.Get();
            return r;
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<StudentItem> Get(string id)
        {
            var r = _StudentService.Get(id);
            return r == null ? NotFound() : (ActionResult<StudentItem>)r;
        }


        [HttpGet("{id:length(24)}")]
        [Route("GetByUserId/{id}")]
        public ActionResult<List<StudentItem>> GetByUserId(string id)
        {
            var r = _StudentService.GetByUserId(id);
            return r == null ? NotFound() : (ActionResult<List<StudentItem>>)r;
        }

        [HttpPost]
        [Route("Add/")]
        public IActionResult AddStudentItem(StudentItem item)
        {
            try
            {
                string id = _StudentService.Create(item).Id;
                return Created("", new { id = id });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        [Route("Update/")]
        public IActionResult UpdateStudentItem(StudentItem item)
        {
            try
            {
                StudentItem StudentItem = _StudentService.Update(item);
                return Ok(StudentItem);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete]
        [Route("Delete/{id:length(24)}")]
        public IActionResult DeleteStudentItem(string id)
        {
            try
            {
                _StudentService.Delete(id);
                return Ok(HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
