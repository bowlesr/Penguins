/****************************************************************************************************
 * Name:    IMetricsRepository.cs                                                                   *
 * By:      TeamPenguins                                                                            *
 * Purpose: Interface to ensure metrics implementations contains CRUD ops.                          *
 ****************************************************************************************************/
using Api.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public interface IMetricsRepository
    {
        Metrics Create(Metrics metrics);
        Metrics Read(int id);
        void Update(int oldId, Metrics metrics);
        void Delete(int id);
        ICollection<Metrics> ReadAll();
    }
}
