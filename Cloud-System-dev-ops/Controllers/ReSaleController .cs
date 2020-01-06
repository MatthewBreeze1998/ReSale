using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cloud_System_dev_ops.Models;
using Cloud_System_dev_ops.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cloud_System_dev_ops.Controllers
{
    [Route("api/ReSale")]
    [ApiController]
    
    public class ReSaleController : Controller
    {
        private IReSaleRepo _ReSaleRepo;
        public ReSaleController(IReSaleRepo ReSale)
        {
            _ReSaleRepo = ReSale;
        }
        [Route("CreateReSale/")]// method route
        [HttpPost]
        public ActionResult<ReSaleModel> CreateReSale(ReSaleModel ReSale)
        {
            if (ReSale == null)
            {
                return BadRequest();
            }// checks model is not null
            ReSale.CreationTime = DateTime.Now;// creates new data time form current time
           
            _ReSaleRepo.CreateReSale(ReSale);// calls create resale
            
            return CreatedAtAction(nameof(GetReSale), new { id = ReSale.ProductId }, ReSale);// returns a create at action
        }
        [Authorize(Policy = "Manager")]
        [Route("EditReSale/")]
        [HttpPost]
        public ActionResult<ReSaleModel> EditReSale(ReSaleModel Resale)
        {
            if (Resale == null)
            {
                return BadRequest();
            }// checks model is not null
            _ReSaleRepo.EditReSale(Resale);// calls edit and passes Resale 
            return Resale;// returns Resale
        }
        [Authorize(Policy = "Staffpol")]
        [Route("AllReSale")]// route
        [HttpGet]
        public IEnumerable<ReSaleModel> GetAllReSale()
        {
            return _ReSaleRepo.GetAllReSale();// returns list oof resale
        }
        [Authorize(Policy = "Staffpol")]
        [Route("GetReSale/{id}")]//route
        [HttpGet]
        public ActionResult<ReSaleModel> GetReSale(int id)
        {
            ReSaleModel createRaSale = _ReSaleRepo.GetReSale(id);// creates new model and sets it to the return of getresale

            if (createRaSale == null)
            {
                return BadRequest();
            }// if createRaSale reurn bad request 

            return createRaSale;// if not null return createRaSale
        }
        [Authorize(Policy = "Manager")]
        [Route("DeleteResale/")]// route
        [HttpPost]
        public ActionResult<ReSaleModel> Delete(ReSaleModel ReSale)
        {
            if (ReSale == null)
            {
                return BadRequest();
            }// checks not null
            
            _ReSaleRepo.Delete(ReSale);// calls function
            return ReSale;// returns deleted data
        }
    }
}