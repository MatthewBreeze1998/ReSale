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
            _context.User.Add(Object);
            _context.SaveChanges();

            return Object;
        }
        public IEnumerable<ReSaleModel> GetObject()
        {
            return _context.User;
        }

        public bool UpdateObject(ReSaleModel Object)
        {
            try
            {
                _context.User.Update(Object);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}