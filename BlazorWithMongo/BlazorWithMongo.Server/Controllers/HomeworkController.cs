using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorWithMongo.Server.DataAccess;
using BlazorWithMongo.Shared.Models;

namespace BlazorWithMongo.Server.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class HomeworkController : ControllerBase
    {
        HomeworkDataAccessLayer objhomework = new HomeworkDataAccessLayer();

        [HttpGet]
        [Route("api/Homework/Index")]
        public IEnumerable<Homework> Index()
        {
            return objhomework.GetAllHomeworks();
        }

        [HttpPost]
        [Route("api/Homework/Create")]
        public void Create([FromBody] Homework homework)
        {
            objhomework.AddHomework(homework);
        }

        [HttpGet]
        [Route("api/Homework/Details/{id}")]
        public Homework Details(string id)
        {
            return objhomework.GetHomeworkData(id);
        }

        [HttpPut]
        [Route("api/Homework/Edit")]
        public void Edit([FromBody]Homework homework)
        {
            objhomework.UpdateHomework(homework);
        }

        [HttpDelete]
        [Route("api/Homework/Delete/{id}")]
        public void Delete(string id)
        {
            objhomework.DeleteHomework(id);
        }

        [HttpGet]
        [Route("api/Homework/GetRatings")]
        public List<Ratings> GetRatings()
        {
            return objhomework.GetRatingData();
        }
    }
}