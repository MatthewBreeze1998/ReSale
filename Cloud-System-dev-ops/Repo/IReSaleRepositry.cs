using Cloud_System_dev_ops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cloud_System_dev_ops.Repo
{
    public interface IReSaleRepo

    {

        ReSaleModel CreateReSale(ReSaleModel ReSale);

        ReSaleModel GetReSale(int id);

        IEnumerable<Models.ReSaleModel> GetAllReSale();

        ReSaleModel Delete(ReSaleModel Resale);

        ReSaleModel EditReSale(ReSaleModel ReSale);

        
    }
}
