using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinylShop.DataAccess.Repository.IRepository;
using VinylShop.Models;

namespace VinylShop.DataAccess.Repository
{
    public class VinylPlayerRepository : Repository<VinylPlayer>, IVinylPlayerRepository
    {
        private ApplicationDbContext _db;

        public VinylPlayerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(VinylPlayer obj)
        {
            var objFromDb = _db.VinylPlayers.FirstOrDefault(x => x.Id == obj.Id);
            if(objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.Description = obj.Description;
                objFromDb.Connectivity = obj.Connectivity;
                objFromDb.Motor = obj.Motor;
                objFromDb.Speed = obj.Speed;
                objFromDb.Weight = obj.Weight;
                objFromDb.Dimensions = obj.Dimensions;
                objFromDb.Price = obj.Price;
                objFromDb.ManufacturerId = obj.ManufacturerId;
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
