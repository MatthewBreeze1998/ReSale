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
        private IRepository<ReSaleModel> _ReSaleRepo;
        public ReSaleController(IRepository<ReSaleModel> ReSale)
        {
            _ReSaleRepo = ReSale;
        }
        [Authorize(Policy = "Staffpol")]
        [Route("CreateReSale/")]// method route
        [HttpPost]
        public ActionResult<ReSaleModel> CreateReSale(ReSaleModel ReSale)
        {

            if (ReSale == null)
            {
                return BadRequest();
            }// checks model is not null
            ReSale.CreationTime = DateTime.Now;// creates new data time form current time
           
            _ReSaleRepo.CreateObject(ReSale);// calls create resale
            
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

            ReSaleModel livemodel = _ReSaleRepo.GetObjects().FirstOrDefault(x => x.ProductId == Resale.ProductId);// checks for user
            if(livemodel == null)
            {
                return BadRequest();
            }
            
            livemodel.CurrentPrice = Resale.CurrentPrice;
            livemodel.CreationTime = Resale.CreationTime;

            livemodel =  _ReSaleRepo.UpdateObject(Resale);// calls edit and passes Resale 
            if (livemodel == null)
            {
                return Conflict();
            }
            return Resale;// returns Resale
        }
        [Authorize(Policy = "Staffpol")]
        [Route("AllReSale")]// route
        [HttpGet]
        public IEnumerable<ReSaleModel> GetAllReSale()
        {
            return _ReSaleRepo.GetObjects();// returns list oof resale
        }
        [Authorize(Policy = "Staffpol")]
        [Route("GetReSale/{id}")]//route
        [HttpGet]
        public ActionResult<ReSaleModel> GetReSale(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }

            ReSaleModel RaSale = _ReSaleRepo.GetObjects().FirstOrDefault(x => x.ProductId == id);// creates new model and sets it to the return of getresale

            if (RaSale == null)
            {
                return BadRequest();
            }// if createRaSale reurn bad request 

            return RaSale;// if not null return createRaSale
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
            ReSaleModel LiveModel = _ReSaleRepo.GetObjects().FirstOrDefault(x => x.ProductId == ReSale.ProductId);
            
            if(LiveModel == null)
            {
                return BadRequest();
            }

            LiveModel = _ReSaleRepo.DeleteObject(LiveModel);

            if(LiveModel != null)
            {
                return Conflict();
            }
                
            return LiveModel;// returns deleted data
        }
    }
}