using Cloud_System_dev_ops.Controllers;
using Cloud_System_dev_ops.Models;
using Cloud_System_dev_ops.Repo;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ReSaletestPackage
{
    public class ReSaleControllerTest
    {
        private HttpClient _Client;
        private ReSaleController _reSaleController;
        private IRepository<ReSaleModel> _reSaleService;
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
                new ReSaleModel() {ReSaleId = 1, ProductId = 1,CurrentPrice = 123.12, CreationTime = new DateTime(2019,09,10,11,40,28)},
                new ReSaleModel() {ReSaleId = 2, ProductId = 2,CurrentPrice= 11.4,  CreationTime = new DateTime(2019,09,14,10,40,28)},
                new ReSaleModel() {ReSaleId = 3, ProductId = 2,CurrentPrice = 341.41, CreationTime =new DateTime(2019,09,20,9,40,28)}
            };// test data
            _reSaleService = new FakeReSaleRepo();// repo constructor
            _reSaleController = new ReSaleController(_reSaleService);// controller constructor               
        }
        [Test]
        public void CreateReSale_valid_shouldObject()// testing create
        {
            Assert.IsNotNull(_reSaleService);// not null repo
            Assert.IsNotNull(_reSaleController) ;// not null controller
            ReSaleModel ReSale = new ReSaleModel() { ProductId = 4, CurrentPrice = 11.4};// new valid resale model
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
        [Test]
        public void EditReSale_valid_ShouldObject()
        {
            Assert.IsNotNull(_reSaleService);// not null repo
            Assert.IsNotNull(_reSaleController);// not null controller
            ReSaleModel reSale = new ReSaleModel() { ReSaleId = 1, ProductId = 1, CurrentPrice = 123.12, CreationTime = new DateTime(2019, 09, 10, 11, 40, 28) };
            Assert.IsNotNull(reSale);//chekcs not null 

            reSale.CurrentPrice = 110.00;// change lastname

            ActionResult<ReSaleModel> result = _reSaleController.EditReSale(reSale); //calls edit user and set to result 
            Assert.IsNotNull(result);// checks not null
            Assert.IsNotNull(result.Value);

            ReSaleModel updatedUser = result.Value;// sets updatedUser to result.Value
            Assert.IsNotNull(updatedUser);   // checks updatedUser not null 

            Assert.AreEqual(reSale.CurrentPrice, updatedUser.CurrentPrice);// checks the name has changed 

        }

        [Test]
        public void EditReSale_invalid_ShouldObject()
        {

            Assert.IsNotNull(_reSaleService);// not null repo
            Assert.IsNotNull(_reSaleController);// not null controller
            ReSaleModel reSale = new ReSaleModel() { ProductId = 1, CurrentPrice = 123.12, };
            Assert.IsNotNull(reSale);//chekcs not null 


            ActionResult<ReSaleModel> result = _reSaleController.EditReSale(reSale);// sets result to the edit user action
            Assert.IsNotNull(result);// checks its not null

            ActionResult usersResult = result.Result;// sets usersResult to the result.Result
            Assert.AreEqual(usersResult.GetType(), typeof(BadRequestResult));// checks  usersResult        
        }

        [Test]
        public void GetReSale_valid_shouldObject()
        {
            Assert.IsNotNull(_reSaleService);// not null repo
            Assert.IsNotNull(_reSaleController);// not null controller
            ReSaleModel reSale =  new ReSaleModel() { ProductId = 1, CurrentPrice = 123.12, };// users is a valid user 
            Assert.IsNotNull(reSale);// user is not null

            ActionResult<ReSaleModel> result = _reSaleController.GetReSale(reSale.ProductId).Value;// result is the value of the get user controller function 
            Assert.IsNotNull(result);// result is not null
            Assert.IsNotNull(result.Value);// result value is not null

            ReSaleModel resaleResult = result.Value;//  usersResult resut.value 
            Assert.IsNotNull(resaleResult);// checks not null

            Assert.AreEqual(reSale.ProductId, resaleResult.ProductId);//checks if it matches
            Assert.AreEqual(reSale.CurrentPrice, resaleResult.CurrentPrice);//checks if it matches

        }

        [Test]
        public void GetReSale_invalid_shouldObject()
        {

            Assert.IsNotNull(_reSaleService);// not null repo
            Assert.IsNotNull(_reSaleController);// not null controller
            ReSaleModel reSale = null;// user is null
            Assert.IsNull(reSale);// checks user is null

            ActionResult<ReSaleModel> result = _reSaleController.GetReSale(null);// sets result to getuser function
            Assert.IsNotNull(result);// checks not null

            ActionResult usersResult = result.Result;// sets UserResult to the result of result
            Assert.AreEqual(usersResult.GetType(), typeof(BadRequestResult));// checks the resut is of type badrequest
        }
        [Test]
        public void DeleteUser_valid_shouldObject()
        {
            Assert.IsNotNull(_reSaleService);// not null repo
            Assert.IsNotNull(_reSaleController);// not null controller
            ReSaleModel reSale = new ReSaleModel() { ReSaleId = 1, ProductId = 1, CurrentPrice = 123.12, CreationTime = new DateTime(2019, 09, 10, 11, 40, 28) };
            Assert.IsNotNull(reSale);// checks model is not null

            ActionResult<ReSaleModel> getproduct = _reSaleController.GetReSale(reSale.ProductId);
            Assert.IsNotNull(getproduct);// is nit null

            ActionResult<ReSaleModel> product = _reSaleController.Delete(reSale); // product is the return of DeleteProduct
            Assert.IsNotNull(product);// product is not null 

            ActionResult<ReSaleModel> result = _reSaleController.GetReSale(reSale.ProductId);// result is result of get product
            Assert.IsNotNull(result);// is nit null

            ActionResult userResult = result.Result;// staffresult is result.value
            Assert.AreEqual(userResult.GetType(), typeof(BadRequestResult));// StaffResult is of type bad request 
        }
        [Test]
        public void DeleteUser_invalid_shouldObject()
        {
            Assert.IsNotNull(_reSaleService);// not null repo
            Assert.IsNotNull(_reSaleController);// not null controller 
            ReSaleModel deleteresale = null;// null users
            Assert.IsNull(deleteresale);// checks is null

            ActionResult<ReSaleModel> result = _reSaleController.Delete(deleteresale); // product is the return of DeleteProduct
            Assert.IsNotNull(result);// product is not null 

            ActionResult userResult = result.Result;// StaffResult is result of result
            Assert.AreEqual(userResult.GetType(), typeof(BadRequestResult));// StaffResult is of type bad request

        }
    }
}