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
    public class CourseController : Controller
    {
        private readonly CourseService _CourseService;

        public CourseController(CourseService toToService)
        {
            this._CourseService = toToService;
        }
        [HttpGet]
        public ActionResult<List<CourseItem>> Get()
        {
            var r = _CourseService.Get();
            return r;
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<CourseItem> Get(string id)
        {
            var r = _CourseService.Get(id);
            return r == null ? NotFound() : (ActionResult<CourseItem>)r;
        }

        [HttpGet]
        [Route("apple")]
        public ActionResult<CourseItem> apple()
        {
            return Json(new CourseItem { Id = "aaa"});
        }

        [HttpPost]
        [Route("apple")]
        public ActionResult<CourseItem> apple(int id)
        {
            return Content("{ \"name\":\"John\", \"age\":31, \"city\":\"New York\" }", "application/json");
        }
        //[HttpGet("{id:length(24)}")]
        //[Route("GetByUserId/{id}")]
        //public ActionResult<List<CourseItem>> GetByUserId(string id)
        //{
        //    var r = _CourseService.GetByUserId(id);
        //    return r == null ? NotFound() : (ActionResult<List<CourseItem>>)r;
        //}

        [HttpPost]
        [Route("Add/")]
        public IActionResult AddCourseItem(CourseItem item)
        {
            try
            {
                string id = _CourseService.Create(item).Id;
                return Created("", new { id = id });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        [Route("Update/")]
        public IActionResult UpdateCourseItem(CourseItem item)
        {
            try
            {
                CourseItem CourseItem = _CourseService.Update(item);
                return Ok(CourseItem);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete]
        [Route("Delete/{id:length(24)}")]
        public IActionResult DeleteCourseItem(string id)
        {
            try
            {
                _CourseService.Delete(id);
                return Ok(HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
