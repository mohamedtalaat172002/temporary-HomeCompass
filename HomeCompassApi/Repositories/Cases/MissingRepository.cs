//using HomeCompassApi.Models;
//using HomeCompassApi.Models.Cases;
//using Microsoft.EntityFrameworkCore;

//namespace HomeCompassApi.BLL.Cases
//{
//    public class MissingRepository : IRepository<Missing>
//    {
//        private readonly ApplicationDbContext _context;
//        public MissingRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }
//        public void Add(Missing entity)
//        {
//            _context.Missings.Add(entity);
//            _context.SaveChanges();
//        }

//        public void Delete(int id)
//        {
//            _context.Missings.Remove(GetById(id));
//            _context.SaveChanges();
//        }

//        public IEnumerable<Missing> GetAll() => _context.Missings.AsNoTracking().ToList();

//        public Missing GetById(int id) => _context.Missings.AsNoTracking().FirstOrDefault(m => m.Id == id);

//        public void Update(Missing entity)
//        {
//            _context.Missings.Update(entity);
//            _context.SaveChanges();
//        }
//    }
//}
using HomeCompassApi.Models;
using HomeCompassApi.Models.Cases;
using HomeCompassApi.Services.Cases;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeCompassApi.BLL.Cases
{
    public class MissingRepository : IRepository<Missing>
    {
        private readonly ApplicationDbContext _context;

        public MissingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Missing entity)
        {
            await _context.Missings.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var missing = await GetById(id);
            if (missing != null)
            {
                _context.Missings.Remove(missing);
                await _context.SaveChangesAsync();
            }
        }

<<<<<<< HEAD
        public async Task<IEnumerable<Missing>> GetAll() => await _context.Missings.AsNoTracking().ToListAsync();
=======
        public List<Missing> GetAll() => _context.Missings.AsNoTracking().ToList();

        public List<MissingDTO> GetAllReduced()
        {
            return _context.Missings.Select(m => new MissingDTO
            {
                Id = m.Id,
                Address = m.HomeAddress,
                Description = m.PhysicalDescription,
                MissingDate = m.DateOfDisappearance,
                Name = m.FullName,
                PhotoURL = m.PhotoUrl
            })
            .ToList();
        }
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b

        public async Task<Missing> GetById(int id) => await _context.Missings.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

<<<<<<< HEAD
        public async Task Update(Missing entity)
=======
        public bool IsExisted(Missing missing) => _context.Missings.Contains(missing);

        public void Update(Missing entity)
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
        {
            _context.Missings.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
