<<<<<<< HEAD
﻿
using HomeCompassApi.BLL;
=======
﻿using HomeCompassApi.BLL;
using HomeCompassApi.Models;
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
using HomeCompassApi.Models.Feed;
using HomeCompassApi.Repositories.Feed;
using HomeCompassApi.Repositories.User;
using HomeCompassApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeCompassApi.Controllers.Feed
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly CommentRepository _commentRepository;
        private readonly UserRepository _userRepository;
        private readonly PostRepository _postRepository;

        public CommentController(CommentRepository commentRepository, UserRepository userRepository, PostRepository postRepository)
        {
            _commentRepository = commentRepository;
            _userRepository = userRepository;
            _postRepository = postRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Comment comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _commentRepository.Add(comment);
            return CreatedAtAction(nameof(Get), new { Id = comment.Id }, comment);
        }

        [HttpGet]
<<<<<<< HEAD
        public async Task<ActionResult<IEnumerable<Comment>>> Get()
        {
            var comments = await _commentRepository.GetAll();
            return Ok(comments);
        }
=======
        public ActionResult<List<Comment>> Get() => Ok(_commentRepository.GetAllReduced());

        [HttpGet("post/{id}")]
        public ActionResult<List<Comment>> GetByPostId(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid post id");

            if (!_postRepository.IsExisted(new Post { Id = id }))
                return NotFound($"There is no post with the specified Id: {id}");

            return Ok(_commentRepository.GetAll().Where(c => c.PostId == id).ToList());
        }

>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b

        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> Get(int id)
        {
            if (id <= 0)
                return BadRequest();

            var comment = await _commentRepository.GetById(id);

            if (comment is null)
                return NotFound($"There is no comment with the specified Id: {id}");

            return Ok(comment);
        }

<<<<<<< HEAD
        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetByUserId(string id)
=======
        [HttpPost("user/{id}")]
        public ActionResult<List<Post>> GetByUserId(string id)
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
        {
            if (id is null || id == string.Empty)
                return BadRequest();

            if (!_userRepository.IsExisted(new ApplicationUser { Id = id }))
                return NotFound($"There is no user with the specified id: {id}");

            var comments = await _commentRepository.GetAll();
            var commentsByUser = comments.Where(c => c.UserId == id).ToList();
            return Ok(commentsByUser);
        }

<<<<<<< HEAD
=======
        [HttpPost("post/{postId}/page")]
        public ActionResult<List<Comment>> GetByPage(int postId, [FromBody] PageDTO page)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            if (page.Index < 0 || page.Size <= 0)
                return BadRequest();

            return Ok(_commentRepository.GetAll().Where(c => c.PostId == postId).Skip((page.Index - 1) * page.Size).Take(page.Size).ToList());
        }


>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

<<<<<<< HEAD
            var comment = await _commentRepository.GetById(id);

            if (comment is null)
=======
            if (!_commentRepository.IsExisted(new Comment { Id = id }))
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
                return NotFound($"There is no comment with the specified Id: {id}");

            await _commentRepository.Delete(id);
            return NoContent();
        }

        [HttpPut("user/{id}")]
        public async Task<IActionResult> Update(Comment comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

<<<<<<< HEAD
            if (await _commentRepository.GetById(comment.Id) is null)
                return NotFound($"There is no record with the specified Id: {comment.Id}");
=======
            if (!_commentRepository.IsExisted(comment))
                return NotFound($"There is no comment with the specified Id: {comment.Id}");
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b

            await _commentRepository.Update(comment);
            return NoContent();
        }
    }
}
