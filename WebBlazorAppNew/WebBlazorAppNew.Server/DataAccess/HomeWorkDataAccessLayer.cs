using System.Collections.Generic;
using System.Linq;
using WebBlazorAppNew.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace WebBlazorAppNew.Server.DataAccess
{
    public class HomeWorkDataAccessLayer
    {
        //private HomeWorkContext db = new HomeWorkContext();
        ////To Get all HomeWorkss details   
        //public IEnumerable<HomeWork> GetAlHomeWorkss()
        //{
        //    try
        //    {
        //        return db.HomeWork.ToList();
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        ////To Add new HomeWork record     
        //public void AddHomeWork(HomeWork homeWork)
        //{
        //    try
        //    {
        //        db.HomeWork.Add(homeWork);
        //        db.SaveChanges();
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        ////To Update the records of a particluar HomeWork    
        //public void UpdateHomeWork(HomeWork homeWork)
        //{
        //    try
        //    {
        //        db.Entry(homeWork).State = EntityState.Modified;
        //        db.SaveChanges();
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        ////Get the details of a particular HomeWork    
        //public HomeWork GetHomeWorkData(int id)
        //{
        //    try
        //    {
        //        HomeWork homeWork = db.HomeWork.Find(id);
        //        return homeWork;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        ////To Delete the record of a particular HomeWork    
        //public void DeleteHomeWork(int id)
        //{
        //    try
        //    {
        //        HomeWork emp = db.HomeWork.Find(id);
        //        db.HomeWork.Remove(emp);
        //        db.SaveChanges();
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
    }
}  
    

