using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cloud_System_dev_ops.Models;

namespace Cloud_System_dev_ops.Repo
{
    public class FakeReSaleRepo : IRepository<ReSaleModel>

    {

        private List<ReSaleModel> _ReSaleModelList;
        public FakeReSaleRepo()
        {
            _ReSaleModelList = new List<ReSaleModel>()
            {
                new ReSaleModel() {ReSaleId = 1, ProductId = 1,CurrentPrice = 123.12, CreationTime = new DateTime(2019,09,10,11,40,28)},
                new ReSaleModel() {ReSaleId = 2, ProductId = 2,CurrentPrice= 11.4,  CreationTime = new DateTime(2019,09,14,10,40,28)},
                new ReSaleModel() {ReSaleId = 3, ProductId = 2,CurrentPrice = 341.41, CreationTime =new DateTime(2019,09,20,9,40,28)}
            };// data
        }

        public ReSaleModel CreateObject(ReSaleModel ReSale)
        {
            ReSale.ReSaleId = GetNextId();
            _ReSaleModelList.Add(ReSale);// add new model to list
            return ReSale;// returns new resale model
        }

        public ReSaleModel DeleteObject(ReSaleModel Resale)
        {
            _ReSaleModelList.Remove(_ReSaleModelList.FirstOrDefault(x => x.ReSaleId == Resale.ReSaleId));
            return Resale;
        }

        public ReSaleModel UpdateObject(ReSaleModel ReSale)
        {

            ReSaleModel inMemoryModel = _ReSaleModelList.FirstOrDefault(X => X.ProductId == ReSale.ReSaleId);
            if(inMemoryModel == null)
            {
                return null;
            }
            try
            {
                int index = _ReSaleModelList.IndexOf(inMemoryModel);
                _ReSaleModelList[index] = ReSale;
                return ReSale;
            }
            catch(Exception ex)
            {
                return null; 
            }
        }

        public IEnumerable<ReSaleModel>  GetObjects()
        {
            return _ReSaleModelList.AsEnumerable<ReSaleModel>();
        }

        private int GetNextId()
        {
            return (_ReSaleModelList == null || _ReSaleModelList.Count() == 0) ? 1 : _ReSaleModelList.Max(x => x.ReSaleId) + 1;
        }
    }
}