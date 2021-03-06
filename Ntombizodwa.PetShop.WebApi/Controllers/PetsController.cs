using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ntombizodwa.PetShop.Core.Filtering;
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
        public ActionResult<Pet> Create([FromBody] Pet pet)
        {
            var createdPet = _service.Create(pet);
            return Created($"https://localhost/api/pets/{createdPet.Id}",createdPet);
        }

        [HttpGet]
        public ActionResult<List<Pet>> GetAll([FromQuery] Filter filter)
        {
            return Ok(_service.GetPets(filter));
        }

        [HttpGet("{id}")]
        public ActionResult<Pet> GetById(int id)
        {
            Pet pet = _service.GetPetFromId(id);
            return Ok(pet);
        }


        [HttpPut("{id}")]
        public ActionResult<Pet> Update(int id)
        {
            //_service.UpdatePetName(id,name);
            //_service.updte
            return null;
        }
        
        [HttpDelete]
        public void Remove(int id)
        {
            _service.Remove(id);
        }
    }
}