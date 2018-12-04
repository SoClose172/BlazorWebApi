using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using HappyNewYear.Shared.Models;

namespace HappyNewYear.Server.DataAccess
{
    public class NotesDataAccessLayer
    {
        NotesDBContext db = new NotesDBContext();

        //get all dids details
        public List<Did> GetAllDids()
        {
            try
            {
                return db.DidsRecord.Find(_ => true).ToList();
            }
            catch
            {
                throw;
            }
        }

        //get all needs details
        public List<Need> GetAllNeeds()
        {
            try
            {
                return db.NeedsRecord.Find(_ => true).ToList();
            }
            catch
            {
                throw;
            }
        }

        //to add new needs record
        public void AddNeed(Need need)
        {
            try
            {
                db.NeedsRecord.InsertOne(need);
            }
            catch
            {
                throw;
            }
        }

        //to add new dids record
        public void AddDid(Did did)
        {
            try
            {
                db.DidsRecord.InsertOne(did);
            }
            catch
            {
                throw;
            }
        }

        //get the details of a particluar did
        public Did GetDidData(string id)
        {
            try
            {
                FilterDefinition<Did> filterDidData = Builders<Did>.Filter.Eq("Id", id);

                return db.DidsRecord.Find(filterDidData).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        //get the details of a particluar need
        public Need GetNeedData(string id)
        {
            try
            {
                FilterDefinition<Need> filterNeedData = Builders<Need>.Filter.Eq("Id", id);

                return db.NeedsRecord.Find(filterNeedData).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        //to update the records of a perticluar did
        public void UpdateDid(Did did)
        {
            try
            {
                db.DidsRecord.ReplaceOne(filter: g => g.Id == did.Id, replacement: did);

            }
            catch
            {
                throw;
            }
        }

        //to update the records of a perticluar need
        public void UpdateNeed(Need need)
        {
            try
            {
                db.NeedsRecord.ReplaceOne(filter: g => g.Id == need.Id, replacement: need);

            }
            catch
            {
                throw;
            }
        }

        //to delete the record of a particular did
        public void DeleteDid(string id)
        {
            try
            {
                FilterDefinition<Did> didData = Builders<Did>.Filter.Eq("Id", id);
                db.DidsRecord.DeleteOne(didData);

            }
            catch
            {
                throw;
            }
        }

        //to delete the record of a particular need
        public void DeleteNeed(string id)
        {
            try
            {
                FilterDefinition<Need> needData = Builders<Need>.Filter.Eq("Id", id);
                db.NeedsRecord.DeleteOne(needData);

            }
            catch
            {
                throw;
            }
        }

        //to get the list of ratings
        public List<Ratings> GetRatingData()
        {
            try
            {
                return db.Rating.Find(_ => true).ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
