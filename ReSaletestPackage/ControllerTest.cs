using Could_System_dev_ops.Controllers;
using Could_System_dev_ops.Models;
using Could_System_dev_ops.Repo;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;

namespace ReSaletestPackage
{
    public class ReSaleControllerTest
    {
        private HttpClient _Client;
        private ReSaleController _reSaleController;
        private IReSaleRepo _reSaleService;
        private List<ReSaleModel> _ReSaleTestData;

       public ReSaleControllerTest()
        {
            _Client = new HttpClient();
        }


        [SetUp]
        public void Setup()
        {


            _ReSaleTestData = new List<ReSaleModel>
            {
                new ReSaleModel() {ProductId = 1,CurrentPrice = 123.12, NewPrice = 110.42,},
                new ReSaleModel() {ProductId = 2,CurrentPrice= 11.4, NewPrice = 9.42,},
                new ReSaleModel() {ProductId = 2,CurrentPrice = 341.41, NewPrice = 310.42,}
            };

            _reSaleService = new FakeReSaleRepo();
            _reSaleController = new ReSaleController(_reSaleService);
            
                
        
        }

        [Test]
        public void CreateReSale_valid_shouldObject()
        {
            Assert.IsNotNull(_reSaleService);
            Assert.IsNotNull(_reSaleController) ;
            ReSaleModel ReSale = new ReSaleModel() { ProductId = 4, CurrentPrice = 11.4, NewPrice = 9.42};
            Assert.IsNotNull(ReSale);

            ActionResult<ReSaleModel> result = _reSaleController.CreateReSale(ReSale);
            Assert.IsNotNull(result);

            ActionResult ReSaleResult = result.Result;
            Assert.AreEqual(ReSaleResult.GetType(), typeof(CreatedAtActionResult));

            CreatedAtActionResult createdReSaleResult = (CreatedAtActionResult)ReSaleResult;
            Assert.IsNotNull(createdReSaleResult);
            Assert.AreEqual(createdReSaleResult.Value.GetType(), typeof(ReSaleModel));

            ReSaleModel PeSaleValue = (ReSaleModel)createdReSaleResult.Value;
            Assert.IsNotNull(PeSaleValue);

            Assert.AreEqual(ReSale.ProductId, PeSaleValue.ProductId);
            Assert.AreEqual(ReSale.CurrentPrice, PeSaleValue.CurrentPrice);
            Assert.AreEqual(ReSale.NewPrice, PeSaleValue.NewPrice);
            Assert.AreEqual(ReSale.CreationTime, PeSaleValue.CreationTime);
        }

        [Test]
        public void CreateReSale_Invalid_ShouldObject()
        {
            

            Assert.IsNotNull(_reSaleService);
            Assert.IsNotNull(_reSaleController);
            ReSaleModel ReSale = null;
            Assert.IsNull(ReSale);

            ActionResult<ReSaleModel> result = _reSaleController.CreateReSale(ReSale);
            Assert.IsNotNull(result);

            ActionResult ReSaleResult = result.Result;
            Assert.AreEqual(ReSaleResult.GetType(), typeof(BadRequestResult));

        }
    }
}