
using HomeCompassApi.BLL;
using HomeCompassApi.BLL.Facilities;
using HomeCompassApi.Models.Facilities;
<<<<<<< HEAD
=======
using HomeCompassApi.Models.Feed;
using HomeCompassApi.Repositories.User;
using HomeCompassApi.Services;
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeCompassApi.Controllers.Facilities
{
    [ApiController]
    [Route("[controller]")]
    public class ResourceController : ControllerBase
    {
        private readonly IRepository<Resource> _resourceRepository;

        public ResourceController(IRepository<Resource> resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Resource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _resourceRepository.Add(resource);
            return CreatedAtAction(nameof(Get), new { Id = resource.Id }, resource);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resource>>> Get()
        {
<<<<<<< HEAD
            var resources = await _resourceRepository.GetAll();
            return Ok(resources);
=======
            return Ok(_resourceRepository.GetAll());
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Resource>> Get(int id)
        {
            if (id <= 0)
                return BadRequest();

            var resource = await _resourceRepository.GetById(id);

            if (resource is null)
                return NotFound($"There is no resource with the specified Id: {id}");

            return Ok(resource);
        }

<<<<<<< HEAD
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Resource resource)
=======
        [HttpPost("page")]
        public ActionResult<List<Resource>> GetByPage([FromBody] PageDTO page)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            if (page.Index < 0 || page.Size <= 0)
                return BadRequest();

            return Ok(_resourceRepository.GetAll().Skip((page.Index - 1) * page.Size).Take(page.Size).ToList());
        }


        [HttpPut]
        public IActionResult Update(Resource resource)
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

<<<<<<< HEAD
            if (await _resourceRepository.GetById(resource.Id) is null)
=======
            if (!_resourceRepository.IsExisted(resource))
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
                return NotFound($"There is no resource with the specified Id: {resource.Id}");

            await _resourceRepository.Update(resource);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

<<<<<<< HEAD
            if (await _resourceRepository.GetById(id) is null)
=======
            if (!_resourceRepository.IsExisted(new Resource { Id = id }))
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
                return NotFound($"There is no resource with the specified Id: {id}");

            await _resourceRepository.Delete(id);

            return NoContent();
        }
    }
}
