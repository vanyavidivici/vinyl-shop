using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VinylShop.DataAccess.Repository.IRepository;
using VinylShop.Models;

namespace VinylShop.DataAccess.Repository
{
    public class VinylPlateRepository : Repository<VinylPlate>, IVinylPlateRepository
    {
        private ApplicationDbContext _db;

        public VinylPlateRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        

        public void Update(VinylPlate obj)
        {
            var objFromDb = _db.VinylPlates.FirstOrDefault(x => x.Id == obj.Id);
            if(objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.Description = obj.Description;
                objFromDb.Year = obj.Year;
                objFromDb.Country = obj.Country;
                objFromDb.Format = obj.Format;
                objFromDb.Code = obj.Code;
                objFromDb.Size = obj.Title;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Price10 = obj.Price10;
                objFromDb.Price50 = obj.Price50;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.AuthorId = obj.AuthorId;
                objFromDb.LabelId = obj.LabelId;
                if(obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
