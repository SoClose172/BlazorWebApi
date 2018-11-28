using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorWithMongo.Shared.Models
{
     public class Homework
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Complexity { get; set; }
        public string Rating { get; set; }
        public string Comment { get; set; }

    }
}
