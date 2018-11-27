using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebBlazorAppNew.Shared.Models;
using WebBlazorAppNew.Server.DataAccess;

namespace WebBlazorAppNew.Server.Controllers
{
    public class HomeWorkController : ControllerBase //Mifort: убираем функционал mvc
    {
        private readonly HomeWorkContext _context; //Mifort: изменил на контекст базы данных
        //HomeWorkDataAccessLayer objhomework = new HomeWorkDataAccessLayer();

        public HomeWorkController(HomeWorkContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("api/HomeWork/Index")]
        public IEnumerable<HomeWork> Index()
        {
            return _context.HomeWork.ToList(); //Mifort:
        }

        [HttpPost]
        [Route("api/HomeWork/Create")]
        public void Create([FromBody] HomeWork homeWork)
        {
            if (ModelState.IsValid)
            {
                _context.HomeWork.Add(homeWork); //Mifort: 
                _context.SaveChanges();
            }

            //objhomework.AddHomeWork(homeWork);
        }

        [HttpGet]
        [Route("api/HomeWork/Details/{id}")]
        public HomeWork Details(int id)
        {
            return _context.HomeWork.FirstOrDefault(e => e.Id == id);
            //return objhomework.GetHomeWorkData(id);
        }

        [HttpPost]
        [Route("api/HomeWork/Edit")]
        public void Edit([FromBody] HomeWork homeWork)
        {
            if (ModelState.IsValid)
            {
                var home = _context.HomeWork.FirstOrDefault(e => e.Id == homeWork.Id);
                home.Block = homeWork.Block;
                home.Comment = homeWork.Comment;
                home.Name = homeWork.Name;
                home.Rating = homeWork.Rating;

                _context.SaveChanges();
            }

            // objhomework.UpdateHomeWork(homeWork);
        }

        [HttpDelete]
        [Route("api/HomeWork/Delete/{id}")]
        public void Delete(int id)
        {
            var homeWork = _context.HomeWork.FirstOrDefault(e => e.Id == id);

            if(homeWork == null)return;

            _context.HomeWork.Remove(homeWork);
            _context.SaveChanges();
        }
    }
}