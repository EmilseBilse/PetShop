using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ntombizodwa.PetShop.Core.IServices;
using Ntombizodwa.PetShop.Core.Models;
using Ntombizodwa.PetShop.Domain.Services;

namespace Ntombizodwa.PetShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _service;
        public PetsController(IPetService _petService)
        {
            _service = _petService;
        }

        [HttpPost]
        public Pet Create([FromBody] Pet pet)
        {
            return _service.Create(pet);
        }

        [HttpGet]
        public List<Pet> GetAll()
        {
            return _service.GetPets();
        }

        [HttpDelete]
        public void Remove(int id)
        {
            _service.Remove(id);
        }
    }
}