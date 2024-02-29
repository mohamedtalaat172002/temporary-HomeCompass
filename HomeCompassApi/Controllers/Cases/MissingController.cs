using HomeCompassApi.BLL;
using HomeCompassApi.BLL.Cases;
using HomeCompassApi.Models.Cases;
using HomeCompassApi.Repositories.User;
using HomeCompassApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeCompassApi.Controllers.Cases
{
    [ApiController]
    [Route("[controller]")]
    public class MissingController : ControllerBase
    {
        private readonly MissingRepository _missingRepository;
        private readonly UserRepository _userRepository;

        public MissingController(MissingRepository missingRepository, UserRepository userRepository)
        {
            _missingRepository = missingRepository;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Missing missing)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _missingRepository.Add(missing);

            return CreatedAtAction(nameof(Get), new { Id = missing.Id }, missing);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Missing>>> Get()
        {
<<<<<<< HEAD
            var missings = await _missingRepository.GetAll();
            return Ok(missings);
=======
            return Ok(_missingRepository.GetAllReduced());
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Missing>> Get(int id)
        {
            if (id <= 0)
                return BadRequest();

            var missing = await _missingRepository.GetById(id);

            if (missing is null)
                return NotFound($"There is no record with the specified Id: {id}");

            return Ok(missing);
        }

        [HttpPost("page")]
        public ActionResult<List<Missing>> GetByPage([FromBody] PageDTO page)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            if (page.Index < 0 || page.Size <= 0)
                return BadRequest();

            return Ok(_missingRepository.GetAllReduced().Skip((page.Index - 1) * page.Size).Take(page.Size).ToList());
        }

        [HttpGet("reporter/{id}")]
        public async Task<ActionResult<IEnumerable<Missing>>> GetByReporterId(string id)
        {
            if (id is null || id == string.Empty)
                return BadRequest();

            if (_userRepository.GetById(id) is null)
                return NotFound("There is no reporter with the specified id.");

            var missings = await _missingRepository.GetAll();
            var missingsByReporter = missings.Where(m => m.ReporterId == id).ToList();
            return Ok(missingsByReporter);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Missing missing)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _missingRepository.GetById(missing.Id) is null)
                return NotFound($"There is no record with the specified Id: {missing.Id}");

            await _missingRepository.Update(missing);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            var missing = await _missingRepository.GetById(id);

            if (missing is null)
                return NotFound($"There is no record with the specified Id: {id}");

            await _missingRepository.Delete(id);
            return NoContent();
        }
    }
}
