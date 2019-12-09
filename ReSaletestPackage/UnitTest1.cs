using Could_System_dev_ops.Controllers;
using Could_System_dev_ops.Models;
using Could_System_dev_ops.Repo;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;

namespace ReSaletestPackage
{
    public class ReSaleControllerTest
    {
        private HttpClient _Client;
        private ReSaleController _reSaleController;
        private ReSaleRepo _reSaleService;
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
                new ReSaleModel() {ProductId = 1,CurrentPrice = 123.12, NewPrice = 110.42, },
                new ReSaleModel() {ProductId = 2,CurrentPrice= 11.4, NewPrice = 9.42, },
                new ReSaleModel() {ProductId = 2,CurrentPrice = 341.41, NewPrice = 310.42,}
            };


            
        
        
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}