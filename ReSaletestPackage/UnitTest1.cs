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


            _reSaleController = new ReSaleController(_reSaleService);
            _reSaleService = new FakeReSaleRepo();
                
        
        }

        [Test]
        public void CreateReSale_valid_shouldObject()
        {
            Assert.IsNotNull(_reSaleService);
            Assert.IsNotNull(_reSaleController) ;
            ReSaleModel ReSale = new ReSaleModel() { ProductId = 3, CurrentPrice = 11.4, NewPrice = 9.42, };
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

        }

        [Test]
        public void CreateProduct_InvalidUser_ShouldObject()
        {
            _reSaleService = new FakeReSaleRepo(null);

            Assert.IsNotNull(_reSaleService);
            Assert.IsNotNull(_reSaleController);
            ReSaleModel ReSale = new ReSaleModel() { ProductId = 0, CurrentPrice = 0, NewPrice = 0, };
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

            Assert.AreNotEqual(ReSale.ProductId, PeSaleValue.ProductId);
            Assert.AreNotEqual(ReSale.CurrentPrice, PeSaleValue.CurrentPrice);
            Assert.AreNotEqual(ReSale.NewPrice, PeSaleValue.NewPrice);
        }
    }
}