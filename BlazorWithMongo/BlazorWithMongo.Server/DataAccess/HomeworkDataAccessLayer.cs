using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorWithMongo.Shared.Models;
using BlazorWithMongo.Shared.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlazorWithMongo.Server.DataAccess
{
    public class HomeworkDataAccessLayer
    {
        HomeworkDBContext db = new HomeworkDBContext();

        //To Get all Homeworks details         
        public List<Homework> GetAllHomeworks()
        {
            try
            {
                
                return db.HomeworkRecord.Find(_ => true).ToList();
            }
            catch
            {
                throw;
            }
        }

        //To Add new homework record         
        public void AddHomework(Homework homework)
        {
            try
            {
                db.HomeworkRecord.InsertOne(homework);
            }
            catch
            {
                throw;
            }
        }


        //Get the details of a particular homework        
        public Homework GetHomeworkData(string id)
        {
            try
            {
                FilterDefinition<Homework> filterHomeworkData = Builders<Homework>.Filter.Eq("Id", id);

                return db.HomeworkRecord.Find(filterHomeworkData).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar homework        
        public void UpdateHomework(Homework homework)
        {
            try
            {
                db.HomeworkRecord.ReplaceOne(filter: g => g.Id == homework.Id, replacement: homework);
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular homework        
        public void DeleteHomework(string id)
        {
            try
            {
                FilterDefinition<Homework> homeworkData = Builders<Homework>.Filter.Eq("Id", id);
                db.HomeworkRecord.DeleteOne(homeworkData);
            }
            catch
            {
                throw;
            }
        }
        // To get the list of Ratings    
        public List<Ratings> GetRatingData()
        {
            try
            {
                return db.RatingRecord.Find(_ => true).ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
