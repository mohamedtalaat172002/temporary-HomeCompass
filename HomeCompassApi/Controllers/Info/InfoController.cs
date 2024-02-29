<<<<<<< HEAD
﻿//using HomeCompassApi.BLL;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using HomeCompassApi.Models;

//namespace HomeCompassApi.Controllers.Info
//{
//    [Route("[controller]")]
//    [ApiController]
//    public class InfoController : ControllerBase
//    {
//        private readonly IRepository<Models.Info> _infoRepository;

//        public InfoController(IRepository<Models.Info> infoRepository)
//        {
//            _infoRepository = infoRepository;
//        }

//        [HttpGet]
//        public ActionResult<List<Models.Info>> Get()
//        {
//            return Ok(_infoRepository.GetAll());
//        }

//        [HttpGet("{id}")]
//        public ActionResult<Models.Info> GetById(int id)
//        {
//            if (id <= 0)
//                return BadRequest();

//            var info = _infoRepository.GetById(id);
//            if (info is null)
//                return NotFound($"There is no info with the specified id: {id}");

//            return Ok(info);
//        }

//        [HttpGet("bycategory/category")]
//        public async Task<ActionResult<List<Models.Info>>> GetByCategory(string category)
//        {
//            if (category is null || category == string.Empty)
//                return BadRequest();

//            var info = await _infoRepository.GetAll().Where(i => i.Category.ToLower() == category.ToLower());

//            if (info is null || info.Count == 0)
//                return NotFound($"There is no info with the specified category: {category}");

//            return Ok(info);

//        }

//        [HttpPost]
//        public IActionResult Create(Models.Info info)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            _infoRepository.Add(info);

//            return CreatedAtAction(nameof(Get), new { id = info.Id }, info);
//        }

//        [HttpPut]
//        public IActionResult Update(Models.Info entity)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            if (entity.Id <= 0)
//                return BadRequest("Id must be greater than Zero.");

//            var info = _infoRepository.GetById(entity.Id);

//            if (info is null)
//                return NotFound($"There is no info with the specified id: {entity.Id}");

//            _infoRepository.Update(entity);

//            return NoContent();
//        }

//        [HttpDelete("{id}")]
//        public IActionResult Delete(int id)
//        {
//            if (id <= 0)
//                return BadRequest("Id must be greater than Zero.");

//            if (_infoRepository.GetById(id) is null)
//                return NotFound($"There is no info with the specified id: {id}");

//            _infoRepository.Delete(id);

//            return NoContent();
//        }



//    }
//}
using HomeCompassApi.BLL;
using HomeCompassApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
=======
﻿using HomeCompassApi.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HomeCompassApi.Models.Feed;
using HomeCompassApi.Services;
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b

namespace HomeCompassApi.Controllers.Info
{
    [Route("[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly IRepository<Models.Info> _infoRepository;

        public InfoController(IRepository<Models.Info> infoRepository)
        {
            _infoRepository = infoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.Info>>> Get()
        {
            var infoList = await _infoRepository.GetAll();
            return Ok(infoList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Info>> GetById(int id)
        {
            if (id <= 0)
                return BadRequest();

            var info = await _infoRepository.GetById(id);
            if (info is null)
                return NotFound($"There is no info with the specified id: {id}");

            return Ok(info);
        }

        [HttpGet("bycategory/{category}")]
        public async Task<ActionResult<List<Models.Info>>> GetByCategory(string category)
        {
            if (string.IsNullOrEmpty(category))
                return BadRequest();

            var infoList = await _infoRepository.GetAll();
            var filteredInfoList = infoList.Where(i => i.Category.ToLower() == category.ToLower()).ToList();


            if (filteredInfoList.Count == 0)
                return NotFound($"There is no info with the specified category: {category}");

            return Ok(filteredInfoList);
        }

        [HttpPost("page")]
        public ActionResult<List<Models.Info>> GetByPage([FromBody] PageDTO page)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            if (page.Index < 0 || page.Size <= 0)
                return BadRequest();

            return Ok(_infoRepository.GetAll().Skip((page.Index - 1) * page.Size).Take(page.Size).ToList());
        }


        [HttpPost]
        public async Task<IActionResult> Create(Models.Info info)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _infoRepository.Add(info);

            return CreatedAtAction(nameof(Get), new { id = info.Id }, info);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Models.Info entity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (entity.Id <= 0)
                return BadRequest("Id must be greater than Zero.");

<<<<<<< HEAD
            var info = await _infoRepository.GetById(entity.Id);

            if (info is null)
=======
            if (!_infoRepository.IsExisted(entity))
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
                return NotFound($"There is no info with the specified id: {entity.Id}");

            await _infoRepository.Update(entity);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Id must be greater than Zero.");

<<<<<<< HEAD
            var info = await _infoRepository.GetById(id);
            if (info is null)
=======
            if (!_infoRepository.IsExisted(new Models.Info { Id = id }))
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
                return NotFound($"There is no info with the specified id: {id}");

            await _infoRepository.Delete(id);

            return NoContent();
        }
    }
}