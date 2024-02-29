//using HomeCompassApi.Models;
//using HomeCompassApi.Models.Facilities;
//using Microsoft.EntityFrameworkCore;

//namespace HomeCompassApi.BLL.Facilities
//{
//    public class ResourceRepository : IRepository<Resource>
//    {
//        private readonly ApplicationDbContext _context;
//        public ResourceRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }
//        public void Add(Resource entity)
//        {
//            _context.Resources.Add(entity);
//            _context.SaveChanges();
//        }

//        public void Delete(int id)
//        {
//            _context.Resources.Remove(GetById(id));
//            _context.SaveChanges();
//        }

//        public IEnumerable<Resource> GetAll() => _context.Resources.AsNoTracking().ToList();

//        public Resource GetById(int id) => _context.Resources.AsNoTracking().FirstOrDefault(r => r.Id == id);

//        public void Update(Resource entity)
//        {
//            _context.Resources.Update(entity);
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
    public class ResourceRepository : IRepository<Resource>
    {
        private readonly ApplicationDbContext _context;

        public ResourceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Resource entity)
        {
            await _context.Resources.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var resource = await GetById(id);
            _context.Resources.Remove(resource);
            await _context.SaveChangesAsync();
        }

<<<<<<< HEAD
        public async Task<IEnumerable<Resource>> GetAll() => await _context.Resources.AsNoTracking().ToListAsync();
=======
        public List<Resource> GetAll() => _context.Resources.AsNoTracking().ToList();
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b

        public async Task<Resource> GetById(int id) => await _context.Resources.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);

<<<<<<< HEAD
        public async Task Update(Resource entity)
=======
        public bool IsExisted(Resource resource) => _context.Resources.Contains(resource);



        public void Update(Resource entity)
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
        {
            _context.Resources.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
