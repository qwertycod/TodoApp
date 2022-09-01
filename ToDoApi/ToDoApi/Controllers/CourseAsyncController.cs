using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApi.Controllers
{
    public class CourseAsyncController : Controller
    {
        public CourseAsyncController(CourseService toToService)
        {
            this._CourseService = toToService;
        }
        private readonly CourseService _CourseService;


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var r =  _CourseService.Get();
            return Json(r);
        }
    }
}
