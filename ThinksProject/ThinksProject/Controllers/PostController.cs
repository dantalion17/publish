using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThinksProject.DataClasses;
using ThinksProject.Models.DTOs;

namespace ThinksProject.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly DbWorkingForPostOperations _context;
        public PostController(DbWorkingForPostOperations context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

      
        [HttpPost]
        public JsonResult Edit([FromBody]PostDto postDto)
        {
            _context.EditPost(postDto.id, postDto.text);
            var res = new JsonResult(postDto);
            return new JsonResult(postDto);
        }

        [HttpPost]
        public JsonResult Delete([FromBody] PostDto postDto)
        {
            _context.DeletePost(postDto.id);
            return new JsonResult("correct");
        }
    }
}