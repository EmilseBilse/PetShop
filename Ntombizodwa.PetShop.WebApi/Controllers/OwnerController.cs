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
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpPost]
        public void Create(Owner owner)
        {
            _ownerService.CreateOwner(owner);
        }

        [HttpGet]
        public ActionResult<List<Owner>> RealAllOwners()
        {
            return Ok(_ownerService.GetOwners());
        }

        [HttpDelete]
        public void DeleteOwner(int id)
        {
            _ownerService.RemoveOwner(id);
        }

        [HttpPatch]
        public void UpdateOwner(int id, string name)
        {
            _ownerService.UpdateOwner(id, name);
        }
        
        [HttpGet("{id}")]
        public ActionResult<Owner> ReadById(int id)
        {
            try
            {
                return Ok(_ownerService.GetOwnerFromId(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, "Call 911" + e);
            }
            
        }
    }
}