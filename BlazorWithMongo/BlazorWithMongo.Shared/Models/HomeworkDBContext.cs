using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace BlazorWithMongo.Shared.Models
{
     public class HomeworkDBContext
     {
         private readonly IMongoDatabase _mongoDatabase;

         public HomeworkDBContext()
         {
             var client = new MongoClient("mongodb://localhost:27017");
             _mongoDatabase = client.GetDatabase("HomeworkDB");
         }
         public IMongoCollection<Homework> HomeworkRecord
         {
             get
             {
                 return _mongoDatabase.GetCollection<Homework>("HomeworkRecord");
             }
         }

         public IMongoCollection<Ratings> RatingRecord
         {
             get
             {
                 return _mongoDatabase.GetCollection<Ratings>("Ratings");
             }
         }
    }
}
