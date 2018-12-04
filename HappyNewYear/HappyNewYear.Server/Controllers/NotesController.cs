using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HappyNewYear.Server.DataAccess;
using HappyNewYear.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HappyNewYear.Server.Controllers
{
    
    public class NotesController : Controller
    {

        NotesDataAccessLayer objNote = new NotesDataAccessLayer();

        [HttpGet]
        [Route("api/Did/index")]
        public IEnumerable<Did> Index()
        {
            return objNote.GetAllDids();
        }

        [HttpGet]
        [Route("api/Need/index1")]
        public IEnumerable<Need> Index1()
        {
            return objNote.GetAllNeeds();
        }

        [HttpPost]
        [Route("api/Did/Create")]
        public void Create([FromBody] Did did)
        {
            objNote.AddDid(did);
        }


        [HttpPost]
        [Route("api/Need/Create")]
        public void Create([FromBody] Need need)
        {
            objNote.AddNeed(need);
        }

        [HttpGet]
        [Route("api/Did/Details/{id}")]
        public Did Details(string id)
        {
            return objNote.GetDidData(id);
        }

        [HttpGet]
        [Route("api/Need/Details/{id}")]
        public Need Details1(string id)
        {
            return objNote.GetNeedData(id);
        }

        [HttpPut]
        [Route("api/Did/Edit")]
        public void Edit([FromBody] Did did)
        {
            objNote.UpdateDid(did);
        }

        [HttpPut]
        [Route("api/Need/Edit")]
        public void Edit1([FromBody] Need need)
        {
            objNote.UpdateNeed(need);
        }

        [HttpDelete]
        [Route("api/Did/Delete/{id}")]
        public void Delete(string id)
        {
            objNote.DeleteDid(id);
        }

       [HttpDelete]
        [Route("api/Need/Delete1/{id}")]
        public void Delete1(string id)
        {
            objNote.DeleteNeed(id);
        }

        [HttpGet]
        [Route("api/Did/GetRatings")]
        public List<Ratings> GetRatings()
        {
            return objNote.GetRatingData();
        }
       // [HttpGet]
        //[Route("api/Need/GetRatings")]
        //public List<Ratings> GetRatings1()
      //  {
        //    return objNote.GetRatingData();
        //}
    }
}