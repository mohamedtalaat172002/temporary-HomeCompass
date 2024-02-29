<<<<<<< HEAD
﻿
using HomeCompassApi.BLL;
=======
﻿using HomeCompassApi.BLL;
using HomeCompassApi.BLL.Facilities;
using HomeCompassApi.Models;
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
using HomeCompassApi.Models.Facilities;
using HomeCompassApi.Repositories.User;
using HomeCompassApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeCompassApi.Controllers.Facilities
{
    [ApiController]
    [Route("[controller]")]
    public class FacilityController : ControllerBase
    {
        private readonly FacilityRepository _facilityRepository;
        private readonly UserRepository _userRepository;

        public FacilityController(FacilityRepository facilityRepository, UserRepository userRepository)
        {
            _facilityRepository = facilityRepository;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Facility facility)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _facilityRepository.Add(facility);

            return CreatedAtAction(nameof(Get), new { Id = facility.Id }, facility);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Facility>>> Get()
        {
<<<<<<< HEAD
            var facilities = await _facilityRepository.GetAll();
            return Ok(facilities);
=======
            return Ok(_facilityRepository.GetAllReduced());
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Facility>> Get(int id)
        {
            if (id <= 0)
                return BadRequest();

            var facility = await _facilityRepository.GetById(id);

            if (facility is null)
                return NotFound($"There is no facility with the specified Id: {id}");

            return Ok(facility);
        }

        [HttpGet("contributor/{id}")]
        public async Task<ActionResult<List<Facility>>> GetByContributorId(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();

            if (!_userRepository.IsExisted(new ApplicationUser { Id = id }))
                return NotFound($"There is no contibutor with the specified id: {id}");

            var facilities = await _facilityRepository.GetAll();
            var facilitiesfilterd=facilities.Where(f => f.ContributorId == id).ToList();
            return Ok(facilities);
        }

        [HttpGet("bycategory/{categoryId}")]
        public async Task<ActionResult<List<Facility>>> GetByCategory(int categoryId)
        {
            var facilities = await _facilityRepository.GetAll();
            var facilitiesfilterd= facilities.Where(f => f.CategoryId == categoryId).ToList();
            return Ok(facilitiesfilterd);
        }

<<<<<<< HEAD
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Facility facility)
=======
        [HttpPost("page")]
        public ActionResult<List<Facility>> GetByPage([FromBody] PageDTO page)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            if (page.Index < 0 || page.Size <= 0)
                return BadRequest();

            return Ok(_facilityRepository.GetAllReduced().Skip((page.Index - 1) * page.Size).Take(page.Size).ToList());
        }


        [HttpPut]
        public IActionResult Update(Facility facility)
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

<<<<<<< HEAD
            if (await _facilityRepository.GetById(facility.Id) is null)
=======
            if (!_facilityRepository.IsExisted(facility))
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
                return NotFound($"There is no facility with the specified Id: {facility.Id}");

            await _facilityRepository.Update(facility);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

<<<<<<< HEAD
            if (await _facilityRepository.GetById(id) is null)
                return NotFound($"There is no facility with the specified Id: {id}");

            await _facilityRepository.Delete(id);
=======
            if (!_facilityRepository.IsExisted(new Facility { Id = id }))
                return NotFound($"There is no facility with the specified Id: {id}");

            _facilityRepository.Delete(id);
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
            return NoContent();
        }
    }
}
