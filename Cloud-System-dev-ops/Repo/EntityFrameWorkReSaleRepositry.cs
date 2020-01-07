using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cloud_System_dev_ops.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Cloud_System_dev_ops.Repo
{
    public class EntityFrameWorkReSaleRepositry : IRepository<ReSaleModel>
    {
        private readonly IServiceScope _scope;
        private readonly ReSaleDataBaseContext _context;

        public EntityFrameWorkReSaleRepositry(IServiceProvider service)
        {
            _scope = service.CreateScope();
            _context = _scope.ServiceProvider.GetRequiredService<ReSaleDataBaseContext>();

        }
        public ReSaleModel CreateObject(ReSaleModel Object)
        {
            _context.ReSale.Add(Object);
            _context.SaveChanges();

            return Object;
        }

        public ReSaleModel DeleteObject(ReSaleModel Object)
        {
            try
            {
                _context.ReSale.Remove(Object);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Object;
            }

            return null;
        }

   
        public IEnumerable<ReSaleModel> GetObjects()
        {
            return _context.ReSale;
        }
        public ReSaleModel UpdateObject(ReSaleModel Object)
        {
            try
            {
                _context.ReSale.Update(Object);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return null;
            }

            return Object;
        }
    }
}