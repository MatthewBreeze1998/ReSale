using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Could_System_dev_ops.Models;

namespace Could_System_dev_ops.Repo
{
    public interface IRepository<User>
    {
        bool UpdateObject(ReSaleModel Object);


        ReSaleModel CreateObject(ReSaleModel Object);

        IEnumerable<Models.ReSaleModel> GetObject();
    }
}