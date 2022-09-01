using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Net;
using ToDoApi.Entities;

namespace ToDoApi.Controllers
{
 //   [Helper.Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : Controller
    {
        private readonly SubjectService _subjectService;

        public SubjectController(SubjectService toToService)
        {
            this._subjectService = toToService;
        }
        [HttpGet]
        public ActionResult<List<SubjectItem>> Get()
        {
            var r = _subjectService.Get();
            return r;
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<SubjectItem> Get(string id)
        {
            var r = _subjectService.Get(id);
            return r == null ? NotFound() : (ActionResult<SubjectItem>)r;
        }


        [HttpGet("{id:length(24)}")]
        [Route("GetByName/{id}")]
        public ActionResult<List<SubjectItem>> GetByUserId(string id)
        {
            var r = _subjectService.GetByName(id);
            return r == null ? NotFound() : (ActionResult<List<SubjectItem>>)r;
        }

        [HttpPost]
        [Route("Add/")]
        public IActionResult AddSubjectItem(SubjectItem item)
        {
            try
            {
                string id = _subjectService.Create(item).Id;
                return Created("", new { id = id });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        [Route("Update/")]
        public IActionResult UpdateSubjectItem(SubjectItem item)
        {
            try
            {
                SubjectItem SubjectItem = _subjectService.Update(item);
                return Ok(SubjectItem);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete]
        [Route("Delete/{id:length(24)}")]
        public IActionResult DeleteSubjectItem(string id)
        {
            try
            {
                _subjectService.Delete(id);
                return Ok(HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
