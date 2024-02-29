

using HomeCompassApi.BLL;
using HomeCompassApi.Models;
using HomeCompassApi.Models.Cases;
using HomeCompassApi.Models.Feed;
using HomeCompassApi.Repositories.User;
using HomeCompassApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeCompassApi.Controllers.Feed
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly PostRepository _postRepository;
        private readonly UserRepository _userRepository;

        public PostController(PostRepository postRepository, UserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _postRepository.Add(post);
            return CreatedAtAction(nameof(Get), new { id = post.Id }, post);
        }

        [HttpGet]
<<<<<<< HEAD
        public async Task<ActionResult<IEnumerable<Post>>> Get()
        {
            return Ok(await _postRepository.GetAll());
        }
=======
        public ActionResult<List<Post>> Get() => Ok(_postRepository.GetAllReduced());
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> Get(int id)
        {
            if (id <= 0)
                return BadRequest();

            var post = await _postRepository.GetById(id);

            if (post is null)
                return NotFound($"There is no post with the specified Id: {id}");

            return Ok(post);
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<List<Post>>> GetByUserId(string id)
        {
            if (id is null || id == string.Empty)
                return BadRequest();

            if (!_userRepository.IsExisted(new ApplicationUser { Id = id }))
                return NotFound($"There is no user with the specified id: {id}");

            return Ok((await _postRepository.GetAll()).Where(p => p.UserId == id).ToList());
        }

<<<<<<< HEAD
        [HttpPut("user/{id}")]
        public async Task<IActionResult> Update(Post post)
=======
        [HttpPost("page")]
        public ActionResult<List<Post>> GetByPage([FromBody] PageDTO page)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            if (page.Index < 0 || page.Size <= 0)
                return BadRequest();

            return Ok(_postRepository.GetAllReduced().Skip((page.Index - 1) * page.Size).Take(page.Size).ToList());
        }


        [HttpPut]
        public IActionResult Update(Post post)
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

<<<<<<< HEAD
            if (await _postRepository.GetById(post.Id) is null)
=======
            if (!_postRepository.IsExisted(post))
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
                return NotFound($"There is no post with the specified Id: {post.Id}");

            await _postRepository.Update(post);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

<<<<<<< HEAD
            var post = await _postRepository.GetById(id);

            if (post is null)
=======
            if (!_postRepository.IsExisted(new Post { Id = id }))
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
                return NotFound($"There is no post with the specified Id: {id}");

            await _postRepository.Delete(id);
            return NoContent();
        }
    }
}


