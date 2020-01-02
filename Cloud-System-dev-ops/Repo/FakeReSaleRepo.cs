using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cloud_System_dev_ops.Models;

namespace Cloud_System_dev_ops.Repo
{
    public class FakeReSaleRepo : IReSaleRepo

    {

        private List<ReSaleModel> _ReSaleModelList;
        public FakeReSaleRepo()
        {
            _ReSaleModelList = new List<ReSaleModel>()
            {
                new ReSaleModel() {ProductId = 1,CurrentPrice = 123.12, NewPrice = 110.42, CreationTime = new DateTime(2019,09,10,11,40,28)},
                new ReSaleModel() {ProductId = 2,CurrentPrice= 11.4, NewPrice = 9.42, CreationTime = new DateTime(2019,09,14,10,40,28)},
                new ReSaleModel() {ProductId = 2,CurrentPrice = 341.41, NewPrice = 310.42, CreationTime =new DateTime(2019,09,20,9,40,28)}
            };// data
        }

        public ReSaleModel CreateReSale(ReSaleModel ReSale)
        {
            _ReSaleModelList.Add(ReSale);// add new model to list
            return ReSale;// returns new resale model
        }

        public ReSaleModel Delete(ReSaleModel Resale)
        {
            _ReSaleModelList.Remove(_ReSaleModelList.FirstOrDefault(x => x.ProductId == Resale.ProductId));// removes from the list first or default where the id matches
            return Resale;// return deleted data
        }

        public ReSaleModel EditReSale(ReSaleModel ReSale)
        {
            _ReSaleModelList[_ReSaleModelList.IndexOf(_ReSaleModelList.FirstOrDefault(x => x.ProductId == ReSale.ProductId))] = ReSale; // replaced the data entry of where the index id matches with the new data entry
            return ReSale;// return edited model
        }

        public ReSaleModel GetReSale(int id)
        {
            return _ReSaleModelList.FirstOrDefault(x => id == x.ProductId);// return the matching product
        }

        public IEnumerable<ReSaleModel> GetAllReSale()
        {
            return _ReSaleModelList.AsEnumerable<ReSaleModel>();// return all data entrys from list
        }


    }
}