<<<<<<< HEAD
﻿


using HomeCompassApi.BLL;
=======
﻿using HomeCompassApi.BLL;
using HomeCompassApi.BLL.Cases;
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
using HomeCompassApi.Models.Cases;
using HomeCompassApi.Models.Feed;
using HomeCompassApi.Repositories.User;
using HomeCompassApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace HomeCompassApi.Controllers.Cases
{
    [ApiController]
    [Route("[controller]")]

    public class HomelessController : Controller
    {
        private readonly HomelessRepository _homelessRepository;
        private readonly UserRepository _userRepository;
        public HomelessController(HomelessRepository homelessRepository, UserRepository userRepository)
        {
            _homelessRepository = homelessRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
<<<<<<< HEAD
            var homeless = await _homelessRepository.GetAll();
            return Ok(homeless);
=======
            return Ok(_homelessRepository.GetAllReduced());
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Homeless>> Get(int id)
        {
            if (id <= 0)
                return BadRequest();

            var homeless = await _homelessRepository.GetById(id);

            if (homeless == null)
                return NotFound($"There is no record with the specified Id: {id}");

            return Ok(homeless);
        }


        [HttpPost("page")]
        public ActionResult<List<Homeless>> GetByPage([FromBody] PageDTO page)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            if (page.Index < 0 || page.Size <= 0)
                return BadRequest();

            return Ok(_homelessRepository.GetAllReduced().Skip((page.Index - 1) * page.Size).Take(page.Size).ToList());
        }

        [HttpGet("reporter/{id}")]
        public async Task<ActionResult<List<Homeless>>> GetByReporterId(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();

            //if (await _userRepository.GetById(id) == null)
            //    return NotFound("There is no reporter with the specified id.");

            var homeless = await _homelessRepository.GetAll();
            return Ok(homeless.Where(h => h.ReporterId == id).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Homeless homeless)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _homelessRepository.Add(homeless);
            return CreatedAtAction(nameof(Get), new { id = homeless.Id }, homeless);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Homeless homeless)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingHomeless = await _homelessRepository.GetById(homeless.Id);
            if (existingHomeless == null)
                return NotFound($"There is no record with the specified Id: {homeless.Id}");

            await _homelessRepository.Update(homeless);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            var existingHomeless = await _homelessRepository.GetById(id);
            if (existingHomeless == null)
                return NotFound($"There is no record with the specified Id: {id}");

            await _homelessRepository.Delete(id);
            return NoContent();
        }
    }
}
