﻿using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Net;

namespace ToDoApi.Controllers
{
    [Helper.Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemController : Controller
    {
        private readonly ToDoService _toToService;

        public ToDoItemController(ToDoService toToService)
        {
            this._toToService = toToService;
        }
        [HttpGet]
        public ActionResult<List<ToDoItem>> Get()
        {
            var r = _toToService.Get();
            return r;
        }
        public ActionResult Index(int i)
        {
            return Json(1);
        }
        public ActionResult Index(double i)
        {
            return Json(1.2);
        }

        [HttpGet("{id:length(24)}")]
        //   [HttpGet]
        public ActionResult<ToDoItem> Get(string id)
        {
            var r = _toToService.Get(id);
            return r == null ? NotFound() : (ActionResult<ToDoItem>)r;
        }


        [HttpGet("{id:length(24)}")]
        [Route("GetByUserId/{id}")]
        public ActionResult<List<ToDoItem>> GetByUserId(string id)
        {
            var r = _toToService.GetByUserId(id);
            return r == null ? NotFound() : (ActionResult<List<ToDoItem>>)r;
        }

        [HttpPost]
        [Route("Add/")]
        public IActionResult AddToDoItem(ToDoItem item)
        {
            try
            {
                string id = _toToService.Create(item).Id;
                return Created("", new { id = id });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        [Route("Update/")]
        public IActionResult UpdateToDoItem(ToDoItem item)
        {
            try
            {
                ToDoItem toDoItem = _toToService.Update(item);
                return Ok(toDoItem);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete]
        [Route("Delete/{id:length(24)}")]
        public IActionResult DeleteToDoItem(string id)
        {
            try
            {
                _toToService.Delete(id);
                return Ok(HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
