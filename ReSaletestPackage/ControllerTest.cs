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
            };// test data
            _reSaleService = new FakeReSaleRepo();// repo constructor
            _reSaleController = new ReSaleController(_reSaleService);// controller constructor               
        }
        [Test]
        public void CreateReSale_valid_shouldObject()// testing create
        {
            Assert.IsNotNull(_reSaleService);// not null repo
            Assert.IsNotNull(_reSaleController) ;// not null controller
            ReSaleModel ReSale = new ReSaleModel() { ProductId = 4, CurrentPrice = 11.4, NewPrice = 9.42};// new valid resale model
            Assert.IsNotNull(ReSale);// resale not null

            ActionResult<ReSaleModel> result = _reSaleController.CreateReSale(ReSale);// result is the return of create resale
            Assert.IsNotNull(result);// reslut is not null

            ActionResult ReSaleResult = result.Result;// ReSaleResult is result.result
            Assert.AreEqual(ReSaleResult.GetType(), typeof(CreatedAtActionResult));// check ReSaleResult is of type creatataction

            CreatedAtActionResult createdReSaleResult = (CreatedAtActionResult)ReSaleResult;// new creat at action
            Assert.IsNotNull(createdReSaleResult);// createdReSaleResult is not null
            Assert.AreEqual(createdReSaleResult.Value.GetType(), typeof(ReSaleModel));// createdReSaleResult is of type resale model

            ReSaleModel PeSaleValue = (ReSaleModel)createdReSaleResult.Value;// PeSaleValue is createdReSaleResult.value
            Assert.IsNotNull(PeSaleValue);//PeSaleValue is not null

            Assert.AreEqual(ReSale.ProductId, PeSaleValue.ProductId);//cehcks are equal
            Assert.AreEqual(ReSale.CurrentPrice, PeSaleValue.CurrentPrice);//cehcks are equal
            Assert.AreEqual(ReSale.NewPrice, PeSaleValue.NewPrice);//cehcks are equal
            Assert.AreEqual(ReSale.CreationTime, PeSaleValue.CreationTime);//cehcks are equal
        }

        [Test]
        public void CreateReSale_Invalid_ShouldObject()
        {


            Assert.IsNotNull(_reSaleService);// not null repo
            Assert.IsNotNull(_reSaleController);// not null controller
            ReSaleModel ReSale = null;// null resale model
            Assert.IsNull(ReSale);// resale is null

            ActionResult<ReSaleModel> result = _reSaleController.CreateReSale(ReSale);// call creat resale with null model
            Assert.IsNotNull(result);// result is not null

            ActionResult ReSaleResult = result.Result;// ReSaleResult is result of result
            Assert.AreEqual(ReSaleResult.GetType(), typeof(BadRequestResult));// ReSaleResult is of type bad request

        }
    }
}