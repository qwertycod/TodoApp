//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Net;
//using ToDoApi;
//using ToDoApi.Entities;
//using ToDoApi.Services;
//using UserApi.Services;

//namespace UserApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserController : Controller
//    {
//        private readonly UserService _userService;

//        public UserController(UserService toToService)
//        {
//            this._userService = toToService;
//        }
//        [HttpGet]
//        public ActionResult<List<User>> Get()
//        {
//            var r = _userService.Get();
//            return r;
//        }

//        [HttpGet("{id:length(24)}")]
//        public ActionResult<User> Get(string id)
//        {
//            var r = _userService.Get(id);
//            return r == null ? NotFound() : (ActionResult<User>)r;
//        }

//        //[HttpPost]
//        //[Route("Add/")]
//        //public IActionResult AddUserItem(User item)
//        //{
//        //    try
//        //    {
//        //        string id = _userService.Create(item).Id;
//        //        return Created("", new { id = id });
//        //    }
//        //    catch (Exception e)
//        //    {
//        //        return BadRequest(e);
//        //    }
//        //}

//        //[HttpPut]
//        //[Route("Update/")]
//        //public IActionResult UpdateUserItem(User item)
//        //{
//        //    try
//        //    {
//        //        User UserItem = _userService.Update(item);
//        //        return Ok(UserItem);
//        //    }
//        //    catch (Exception e)
//        //    {
//        //        return BadRequest(e);
//        //    }
//        //}

//        //[HttpDelete]
//        //[Route("Delete/{id:length(24)}")]
//        //public IActionResult DeleteUserItem(string id)
//        //{
//        //    try
//        //    {
//        //        _userService.Delete(id);
//        //        return Ok(HttpStatusCode.NoContent);
//        //    }
//        //    catch (Exception e)
//        //    {
//        //        return BadRequest(e);
//        //    }
//        //}
//    }
//}
