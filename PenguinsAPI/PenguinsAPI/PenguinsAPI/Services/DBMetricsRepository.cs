/*****************************************************************
 * Name:    DBMetricsRepository.cs                               *
 * By:      TeamPenguins                                         *
 * Purpose: Manipulate Metrics Database                          *
 ****************************************************************/
using Api.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public class DBMetricsRepository : IMetricsRepository
    {
        private readonly MetricsDBContext _db;  //The Database connection
        
        /// Name:       Constructor
        /// Params:     db:MetricsDBContext, the database connection to be passed
        /// Purpose:    Makes a new dyamic database connection and allows for easy manipulation.
        public DBMetricsRepository(MetricsDBContext db)
        {
            _db = db;
        }

        /// Name:       Create
        /// Params:     metrics:Metrics, the metrics
        /// Purpose:    Creates a specific database element
        /// Returns:    metrics:Metrics, the newly created Metrics
        public Metrics Create(Metrics metrics)
        {
            _db.Add(metrics);
            _db.SaveChanges();
            return metrics;
        }

        /// Name:       Delete
        /// Params:     id:int, the user id to return
        /// Purpose:    Deletes a user from the database
        public void Delete(int id)
        {
            Metrics toDelete = Read(id);
            _db.Metrics.Remove(toDelete);
            _db.SaveChanges();
        }

        /// Name:       Read
        /// Params:     id:int, the user id to return
        /// Purpose:    Returns a specific user
        /// Returns:    x:Metrics, gives a specific user
        public Metrics Read(int id)
        {
            return _db.Metrics.FirstOrDefault(p => p.UserId == id);
        }

        /// Name:       ReadAll
        /// Purpose:    Returns all users
        /// Returns:    x:ICollection<Metrics>, Ansynchronously return every user
        public ICollection<Metrics> ReadAll()
        {
            return _db.Metrics.ToList();
        }

        /// Name:       Update
        /// Params:     oldId:int, the user id to return; metrics:Metrics, the metrics
        /// Purpose:    Update Wrapper
        public void Update(int oldId, Metrics metrics)
        {
            Metrics toUpdate = Read(oldId);
            toUpdate.UserName = metrics.UserName;
            toUpdate.LoginTime = metrics.LoginTime;
            toUpdate.LogoutTime = metrics.LogoutTime;
            _db.SaveChanges();
        }
    }
}
