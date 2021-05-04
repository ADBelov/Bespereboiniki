using System;
using System.Collections.Generic;
using System.Linq;
using Bespereboiniki.Datalayer.Tables;

namespace Bespereboiniki.Datalayer.Repositories
{
    public interface IUPSRepository
    {
        List<UPS> GetUPSs(int skip, int take);
        Guid AddUPS(UPS ups);
    }

    public class UPSRepository : IUPSRepository
    {
        private readonly UPSContext context;

        public UPSRepository(UPSContext context)
        {
            this.context = context;
        }

        public List<UPS> GetUPSs(int skip, int take)
        {
            return context.UPSes.Skip(skip).Take(take).ToList();
        }

        public Guid AddUPS(UPS ups)
        {
            context.UPSes.Add(ups);
            context.SaveChanges();
            return ups.Id;
        }
    }
}