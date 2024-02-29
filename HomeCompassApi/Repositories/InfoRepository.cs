//using HomeCompassApi.BLL;
//using HomeCompassApi.Models;

//namespace HomeCompassApi.Repositories
//{
//    public class InfoRepository : IRepository<Info>
//    {
//        private readonly ApplicationDbContext _context;

//        public InfoRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task Add(Info entity)
//        {
//            _context.Info.Add(entity);
//            await _context.SaveChangesAsync();
//        }


//        public void Delete(int id)
//        {
//            _context.Info.Remove(GetById(id));
//            _context.SaveChanges();
//        }

//        public void IEnumerable<Info> GetAll()
//        {
//           return  _context.Info.ToList();
//        }

//        public Info GetById(int id)
//        {
//            return _context.Info.FirstOrDefault(i => i.Id == id);
//        }

//        public void Update(Info entity)
//        {
//            _context.Info.Update(entity);
//            _context.SaveChanges();
//        }
//    }
//}
using HomeCompassApi.BLL;
using HomeCompassApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeCompassApi.Repositories
{
    public class InfoRepository : IRepository<Info>
    {
        private readonly ApplicationDbContext _context;

        public InfoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Info entity)
        {
            _context.Info.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                _context.Info.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

<<<<<<< HEAD
        public async Task<IEnumerable<Info>> GetAll()
=======
        public List<Info> GetAll()
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
        {
            return await _context.Info.ToListAsync();
        }

        public async Task<Info> GetById(int id)
        {
            return await _context.Info.FirstOrDefaultAsync(i => i.Id == id);
        }

<<<<<<< HEAD
        public async Task Update(Info entity)
=======
        public bool IsExisted(Info entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Info entity)
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
        {
            _context.Info.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}