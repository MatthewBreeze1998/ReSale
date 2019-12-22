using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Could_System_dev_ops.Models;
using Could_System_dev_ops.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Could_System_dev_ops.Controllers
{
    [Route("api/ReSale")]
    [ApiController]
    [Authorize]
    public class ReSaleController : Controller
    {
        private IReSaleRepo _ReSaleRepo;
        public ReSaleController(IReSaleRepo ReSale)
        {
            _ReSaleRepo = ReSale;
        }
        [Route("CreateReSale/{Resale}")]
        [HttpPost]
        public ActionResult<ReSaleModel> CreateReSale(ReSaleModel ReSale)
        {
            if (ReSale == null)
            {
                return BadRequest();
            }
            _ReSaleRepo.CreateReSale(ReSale);
            return CreatedAtAction(nameof(getReSale), new { id = ReSale.ProductId }, ReSale);
        }

        [Route("EditReSale/{ReSale}")]
        [HttpPost]
        public ActionResult<ReSaleModel> EditReSale(ReSaleModel Resale)
        {
            if (Resale == null)
            {
                return NotFound();
            }
            _ReSaleRepo.EditReSale(Resale);
            return Resale;
        }
        [Route("AllReSale")]
        [HttpGet]
        public IEnumerable<ReSaleModel> GetAllReSale()
        {
            return _ReSaleRepo.GetAllReSale();
        }

        [Route("GetReSale/{id}")]
        [HttpGet]
        public ActionResult<ReSaleModel> getReSale(int id)
        {
            ReSaleModel createRaSale = _ReSaleRepo.GetReSale(id);

            if (createRaSale == null)
            {
                return NotFound();
            }

            return createRaSale;
        }

        [Route("DeleteResale/{ReSale}")]
        [HttpPost]
        public ActionResult<ReSaleModel> Delete(ReSaleModel ReSale)
        {
            if (ReSale == null)
            {
                return NotFound();
            }
            
            _ReSaleRepo.Delete(ReSale);
            return ReSale;
        }
    }
}