//using HomeCompassApi.Models;
//using HomeCompassApi.Models.Feed;
//using Microsoft.EntityFrameworkCore;

//namespace HomeCompassApi.BLL
//{
//    public class CommentRepository : IRepository<Comment>
//    {
//        private readonly ApplicationDbContext _context;

//        public CommentRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public void Add(Comment entity)
//        {
//            _context.Comments.Add(entity);
//            _context.SaveChanges();
//        }

//        public IEnumerable<Comment> GetAll() => _context.Comments.AsNoTracking().ToList();

//        public Comment GetById(int id) => _context.Comments.AsNoTracking().FirstOrDefault(c => c.Id == id);


//        public void Update(Comment entity)
//        {
//            _context.Comments.Update(entity);
//            _context.SaveChanges();
//        }

//        public void Delete(int id)
//        {
//            _context.Comments.Remove(GetById(id));
//            _context.SaveChanges();
//        }

//    }
//}
using HomeCompassApi.Models;
using HomeCompassApi.Models.Feed;
using HomeCompassApi.Services.Feed;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeCompassApi.BLL
{
    public class CommentRepository : IRepository<Comment>
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Comment entity)
        {
            _context.Comments.Add(entity);
            await _context.SaveChangesAsync();
        }

<<<<<<< HEAD
        public async Task<IEnumerable<Comment>> GetAll() => await _context.Comments.AsNoTracking().ToListAsync();

        public async Task<Comment> GetById(int id) => await _context.Comments.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

        public async Task Update(Comment entity)
=======
        public List<Comment> GetAll() => _context.Comments.AsNoTracking().ToList();

        public List<CommentDTO> GetAllReduced()
        {
            return _context.Comments.Select(c => new CommentDTO
            {
                Id = c.Id,
                Content = c.Content,
                AuthorName = $"{c.User.FirstName} {c.User.LastName}",
                AuthorPhotoURL = c.User.PhotoUrl
            }
            ).ToList();
        }

        public Comment GetById(int id) => _context.Comments.AsNoTracking().FirstOrDefault(c => c.Id == id);
        public bool IsExisted(Comment comment) => _context.Comments.Contains(comment);

        public void Update(Comment entity)
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
        {
            _context.Comments.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var comment = await GetById(id);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }
<<<<<<< HEAD
=======


>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
    }
}
