
using HomeCompassApi.BLL;
using HomeCompassApi.Models.Facilities;
using HomeCompassApi.Models.Feed;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeCompassApi.Controllers.Facilities
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryController(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

<<<<<<< HEAD
            await _repository.Add(category);
=======
            _categoryRepository.Add(category);
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
            return CreatedAtAction(nameof(Get), new { Id = category.Id }, category);
        }

        [HttpGet]
<<<<<<< HEAD
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            var categories = await _repository.GetAll();
            return Ok(categories);
        }
=======
        public ActionResult<List<Category>> Get() => Ok(_categoryRepository.GetAll());
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Get(int id)
        {
            if (id <= 0)
                return BadRequest();

<<<<<<< HEAD
            var category = await _repository.GetById(id);
=======
            var category = _categoryRepository.GetById(id);
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b

            if (category is null)
                return NotFound($"There is no category with the specified Id: {id}");

            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Category category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

<<<<<<< HEAD

            if (await _repository.GetById(category.Id) is null)
                return NotFound($"There is no category with the specified Id: {category.Id}");

            await _repository.Update(category);
=======
            if (!_categoryRepository.IsExisted(category))
                return NotFound($"There is no category with the specified Id: {category.Id}");

            _categoryRepository.Update(category);
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

<<<<<<< HEAD
            if (await _repository.GetById(id) is null)
                return NotFound($"There is no category with the specified Id: {id}");

            await _repository.Delete(id);
=======
            if (_categoryRepository.GetById(id) is null)
                return NotFound($"There is no category with the specified Id: {id}");

            _categoryRepository.Delete(id);
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
            return NoContent();
        }
    }
}
