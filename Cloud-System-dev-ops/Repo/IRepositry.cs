using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cloud_System_dev_ops.Models;

namespace Cloud_System_dev_ops.Repo
{
    public interface IRepository<User>
    {
        bool UpdateObject(ReSaleModel Object);


        ReSaleModel CreateObject(ReSaleModel Object);

        IEnumerable<Models.ReSaleModel> GetObject();
    }
}