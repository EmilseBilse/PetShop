using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ntombizodwa.PetShop.Core.IServices;
using Ntombizodwa.PetShop.Core.Models;

namespace Ntombizodwa.PetShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsurance _insureanceService;

        public InsuranceController(IInsurance insuranceService)
        {
            _insureanceService = insuranceService;
        }

        [HttpGet("{id}")]
        public ActionResult<Insurance> ReadById(int id)
        {
            try
            {
                return Ok(_insureanceService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, "Call 911");
            }
            
        }

        [HttpGet]
        public ActionResult<List<Insurance>> ReadAll()
        {
            try
            {
                return Ok(_insureanceService.ReadAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, "Something went wrong, and that is your problem");
            }
        }
        
        [HttpPost]
        public ActionResult<Insurance> Create([FromBody] Insurance insurance)
        {
            try
            {
                return Ok(_insureanceService.Create(insurance));
            }
            catch (Exception e)
            {
                return StatusCode(500, "Call 911");
            }
            
        }

    }
}