﻿//using HomeCompassApi.Models;
//using HomeCompassApi.Models.Cases;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;

//namespace HomeCompassApi.BLL.Cases
//{
//    public class HomelessRepository : IRepository<Homeless>
//    {
//        private readonly ApplicationDbContext _context;
//        public HomelessRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }
//        public void Add(Homeless entity)
//        {
//            _context.Homeless.Add(entity);
//            _context.SaveChanges();
//        }

//        public void Delete(int id)
//        {
//            _context.Homeless.Remove(GetById(id));
//            _context.SaveChanges();
//        }

//        public IEnumerable<Homeless> GetAll() => _context.Homeless.AsNoTracking().ToList();

//        public Homeless GetById(int id) => _context.Homeless.AsNoTracking().FirstOrDefault(h => h.Id == id);


//        public void Update(Homeless entity)
//        {
//            _context.Homeless.Update(entity);
//            _context.SaveChanges();

//        }
//    }
//}


using HomeCompassApi.Models;
using HomeCompassApi.Models.Cases;
using HomeCompassApi.Services.Cases;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeCompassApi.BLL.Cases
{
    public class HomelessRepository : IRepository<Homeless>
    {
        private readonly ApplicationDbContext _context;
        public HomelessRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(Homeless entity)
        {
            _context.Homeless.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                _context.Homeless.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

<<<<<<< HEAD
        public async Task<IEnumerable<Homeless>> GetAll()
        {
            return await _context.Homeless.AsNoTracking().ToListAsync();
        }

        public async Task<Homeless> GetById(int id)
        {
            return await _context.Homeless.AsNoTracking().FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task Update(Homeless entity)
=======
        public List<Homeless> GetAll() => _context.Homeless.AsNoTracking().ToList();

        public List<HomelessDTO> GetAllReduced()
        {
            return _context.Homeless.Select(h => new HomelessDTO
            {
                Id = h.Id,
                Name = h.FullName,
                Address = h.CurrentLocation,
                Description = h.AdditionalDetails,
                PhotoURL = h.PhotoUrl
            }
            ).ToList();
        }
        public Homeless GetById(int id) => _context.Homeless.AsNoTracking().FirstOrDefault(h => h.Id == id);

        public bool IsExisted(Homeless homeless) => _context.Homeless.Contains(homeless);


        public void Update(Homeless entity)
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
        {
            _context.Homeless.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

