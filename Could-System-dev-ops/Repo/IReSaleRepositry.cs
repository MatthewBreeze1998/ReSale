﻿using Could_System_dev_ops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Could_System_dev_ops.Repo
{
    public interface IReSaleRepo

    {

        ReSaleModel CreateReSale(Models.ReSaleModel ReSale);

        ReSaleModel GetReSale(int id);

        IEnumerable<Models.ReSaleModel> GetAllReSale();

        ReSaleModel Delete(Models.ReSaleModel Resale);

        ReSaleModel EditReSale(Models.ReSaleModel ReSale);

        
    }
}
