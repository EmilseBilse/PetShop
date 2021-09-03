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
    public class PetTypesController : ControllerBase
    {
        private readonly IPetTypeService _typeService;
        public PetTypesController(IPetTypeService _typeServicePara)
        {
            _typeService = _typeServicePara;
        }

        [HttpGet]
        public List<PetType> GetAllTypes()
        {
            return _typeService.GetAllPetTypes();
        }
    }
}