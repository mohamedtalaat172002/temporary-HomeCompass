//using HomeCompassApi.Models;
//using HomeCompassApi.Models.Feed;
//using Microsoft.EntityFrameworkCore;

//namespace HomeCompassApi.BLL
//{
//    public class PostRepository : IRepository<Post>
//    {
//        private readonly ApplicationDbContext _context;

//        public PostRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public void Add(Post entity)
//        {
//            _context.Posts.Add(entity);
//            _context.SaveChanges();
//        }

//        public IEnumerable<Post> GetAll() => _context.Posts.Include(p => p.Comments).AsNoTracking().ToList();

//        public Post GetById(int id) => _context.Posts.Include(p => p.Comments).AsNoTracking().FirstOrDefault(p => p.Id == id);

//        public void Update(Post entity)
//        {
//            _context.Posts.Update(entity);
//            _context.SaveChanges();
//        }

//        public void Delete(int id)
//        {
//            using (var transaction = _context.Database.BeginTransaction())
//            {
//                try
//                {
//                    var post = _context.Posts.Include(p => p.Comments).FirstOrDefault(p => p.Id == id);
//                    if (post != null)
//                    {
//                        _context.Comments.RemoveRange(post.Comments);
//                        _context.Posts.Remove(post);
//                        _context.SaveChanges();
//                        transaction.Commit();
//                    }

//                }
//                catch (Exception ex)
//                {
//                    transaction.Rollback();
//                }
//            }
//        }


//    }
//}

using HomeCompassApi.Models;
using HomeCompassApi.Models.Feed;
using HomeCompassApi.Services.Feed;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeCompassApi.BLL
{
    public class PostRepository : IRepository<Post>
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Post entity)
        {
            _context.Posts.Add(entity);
            await _context.SaveChangesAsync();
        }

<<<<<<< HEAD
        public async Task<IEnumerable<Post>> GetAll()
        {
            return await _context.Posts.Include(p => p.Comments).AsNoTracking().ToListAsync();
        }

        public async Task<Post> GetById(int id)
        {
            return await _context.Posts.Include(p => p.Comments).AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }
=======
        public List<Post> GetAll() => _context.Posts.AsNoTracking().ToList();

        public List<PostDTO> GetAllReduced()
        {
            return _context.Posts.Select(p => new PostDTO
            {
                Id = p.Id,
                AuthorName = $"{p.User.FirstName} {p.User.LastName}",
                Content = p.Content,
                Title = p.Title,
                LikesCount = p.Likes.Count,
                AuthorPhotoUrl = p.User.PhotoUrl,
                CommentsCount = p.Comments.Count
            }
            ).ToList();
        }

        //public IEnumerable<PostDTO> GetByPage() 
        //{ 


        //}

        public Post GetById(int id) => _context.Posts.AsNoTracking().FirstOrDefault(p => p.Id == id);
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b

        public async Task Update(Post entity)
        {
            _context.Posts.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
<<<<<<< HEAD
                    var post = await _context.Posts.Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == id);
=======
                    var post = _context.Posts.FirstOrDefault(p => p.Id == id);
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
                    if (post != null)
                    {
                        _context.Comments.RemoveRange(_context.Comments.Where(c => c.PostId == post.Id));
                        _context.Likes.RemoveRange(_context.Likes.Where(l => l.PostId == post.Id));
                        _context.Posts.Remove(post);
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();
                    }
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();  
                }
            }
        }
<<<<<<< HEAD
=======

        public bool IsExisted(Post post) => _context.Posts.Contains(post);

>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
    }
}

