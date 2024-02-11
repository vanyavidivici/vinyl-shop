using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinylShop.DataAccess.Repository.IRepository;
using VinylShop.Models;

namespace VinylShop.DataAccess.Repository
{
    public class ManufacturerRepository : Repository<Manufacturer>, IManufacturerRepository
    {
        private ApplicationDbContext _db;

        public ManufacturerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Manufacturer obj)
        {
            _db.Manufacturers.Update(obj);
        }
    }
}
