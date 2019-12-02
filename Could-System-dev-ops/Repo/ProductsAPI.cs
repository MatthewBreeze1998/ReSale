﻿using Could_System_dev_ops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Could_System_dev_ops.Repo
{
    public interface ProductsRepo

    {

        ProductsModel UpdateStock(int id, int increase);
        ProductsModel CreateProduct(Models.ProductsModel products);

        ProductsModel GetProduct(int id);

        IEnumerable<Models.ProductsModel> GetProduct(int? ProductId, string ProdcutName, string Description, int? Stocklevel);

        ProductsModel SetResale(int id, Double NewPrice);
    }
}
