//using HomeCompassApi.Models;
//using HomeCompassApi.Models.Facilities;
//using Microsoft.EntityFrameworkCore;

//namespace HomeCompassApi.BLL.Facilities
//{
//    public class FacilityRepository : IRepository<Facility>
//    {
//        private readonly ApplicationDbContext _context;
//        public FacilityRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }
//        public void Add(Facility entity)
//        {
//            _context.Facilities.Add(entity);
//            _context.SaveChanges();
//        }

//        public void Delete(int id)
//        {
//            _context.Facilities.Remove(GetById(id));
//            _context.SaveChanges();
//        }

//        public IEnumerable<Facility> GetAll() => _context.Facilities.AsNoTracking().ToList();
//        #region DTO
//        /*
//           var facilities = _context.Facilities.Select(f =>

//           new FacilityDTO
//           {
//               Name = f.Name,
//               Address = f.Location,
//               PhoneNumber = f.ContactInformaton
//           }

//           );
//           return facilities.Tolist(); */
//        #endregion

//        public Facility GetById(int id) => _context.Facilities.AsNoTracking().FirstOrDefault(f => f.Id == id);


//        public void Update(Facility entity)
//        {
//            _context.Facilities.Update(entity);
//            _context.SaveChanges();
//        }
//    }
//}
using HomeCompassApi.Models;
using HomeCompassApi.Models.Facilities;
using HomeCompassApi.Services.Facilities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeCompassApi.BLL.Facilities
{
    public class FacilityRepository : IRepository<Facility>
    {
        private readonly ApplicationDbContext _context;
        public FacilityRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(Facility entity)
        {
            _context.Facilities.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var facility = await GetById(id);
            _context.Facilities.Remove(facility);
            await _context.SaveChangesAsync();
        }

<<<<<<< HEAD
        public async Task<IEnumerable<Facility>> GetAll() => await _context.Facilities.AsNoTracking().ToListAsync();

        public async Task<Facility> GetById(int id) => await _context.Facilities.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);

        public async Task Update(Facility entity)
=======
        public List<Facility> GetAll() => _context.Facilities.AsNoTracking().ToList();

        public List<FacilityDTO> GetAllReduced()
        {
            return _context.Facilities.Select(f => new FacilityDTO
            {
                Id = f.Id,
                Name = f.Name,
                ContactInformation = f.ContactInformaton,
                Description = f.Description,
                Location = f.Location,
                Resources = f.Resources,
                Target = f.Target

            }).ToList();
        }

        public Facility GetById(int id) => _context.Facilities.AsNoTracking().FirstOrDefault(f => f.Id == id);

        public bool IsExisted(Facility facility) => _context.Facilities.Contains(facility);


        public void Update(Facility entity)
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
        {
            _context.Facilities.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
