using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace HappyNewYear.Shared.Models
{
    public class NotesDBContext
    {
        private readonly IMongoDatabase _mongoDatabase;

        public NotesDBContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _mongoDatabase = client.GetDatabase("NotesDB");
            
        }

        public IMongoCollection<Did> DidsRecord
        {
            get { return _mongoDatabase.GetCollection<Did>("DidsRecord"); }
        }

        public IMongoCollection<Need> NeedsRecord
        {
            get { return _mongoDatabase.GetCollection<Need>("NeedsRecord"); }
        }

        public IMongoCollection<Ratings> Rating
        {
            get { return _mongoDatabase.GetCollection<Ratings>("Rating"); }
        }
    }
}
