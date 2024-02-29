//using HomeCompassApi.Models;
//using HomeCompassApi.Models.Facilities;
//using Microsoft.EntityFrameworkCore;

//namespace HomeCompassApi.BLL.Facilities
//{
//    public class CategoryRepository : IRepository<Category>
//    {
//        private readonly ApplicationDbContext _context;
//        public CategoryRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }
//        public void Add(Category entity)
//        {
//            _context.Categories.Add(entity);
//            _context.SaveChanges();
//        }

//        public void Delete(int id)
//        {
//            _context.Categories.Remove(GetById(id));
//            _context.SaveChanges();
//        }

//        public IEnumerable<Category> GetAll() => _context.Categories.AsNoTracking().ToList();

//        public Category GetById(int id) => _context.Categories.AsNoTracking().FirstOrDefault(c => c.Id == id);

//        public void Update(Category entity)
//        {
//            _context.Categories.Update(entity);
//            _context.SaveChanges();
//        }
//    }
//}
using HomeCompassApi.Models;
using HomeCompassApi.Models.Facilities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeCompassApi.BLL.Facilities
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(Category entity)
        {
            _context.Categories.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var category = await GetById(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

<<<<<<< HEAD
        public async Task<IEnumerable<Category>> GetAll() => await _context.Categories.AsNoTracking().ToListAsync();
=======
        public List<Category> GetAll() => _context.Categories.AsNoTracking().ToList();
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b

        public async Task<Category> GetById(int id) => await _context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

<<<<<<< HEAD
        public async Task Update(Category entity)
=======
        public bool IsExisted(Category category) => _context.Categories.Contains(category);


        public void Update(Category entity)
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
        {
            _context.Categories.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
