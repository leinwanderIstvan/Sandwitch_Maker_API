using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FoodAPI.Models;
using FoodAPI.Models.Dtos;
using FoodAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SandwitchMakerController : Controller
    {
        private ISandwitchRepository _sandwitchRepo;
        private readonly IMapper _mapper;

        public SandwitchMakerController(ISandwitchRepository sandwitchRepos, IMapper mapper)
        {
            _sandwitchRepo = sandwitchRepos;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetNationalParks() 
        {
            var objList = _sandwitchRepo.GetSandwitches();

            var objDto = new List<SandwichDto>();

            foreach (var obj in objList)
            {
                objDto.Add(_mapper.Map<SandwichDto>(obj));
            }

            return Ok(objDto);
        }

        [HttpGet("{sandwichId:int}", Name = "GetSandwitch")]
        public IActionResult GetSandwich(int sandwichId) 
        {
            var obj = _sandwitchRepo.GetSandwitch(sandwichId);

            if (obj == null)
            {
                return NotFound();
            }

            var objDto = _mapper.Map<SandwichDto>(obj);

            return Ok(objDto);
            
        }

        [HttpPost]
        public IActionResult CreateSandwitch([FromBody] SandwichDto sandwichDto) 
        {
            if (sandwichDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_sandwitchRepo.SandwitchExists(sandwichDto.SandwichName))
            {
                ModelState.AddModelError("", "This sandwitch is already exists!");
                return StatusCode(404, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sandwitchObj = _mapper.Map<Sandwich>(sandwichDto);

            if (!_sandwitchRepo.CreateSandwitch(sandwitchObj))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {sandwitchObj.SandwichName}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetSandwitch", new { sandwichId = sandwitchObj.ID }, sandwitchObj);


        }


    }
}