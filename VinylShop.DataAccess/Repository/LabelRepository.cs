using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinylShop.DataAccess.Repository.IRepository;
using VinylShop.Models;

namespace VinylShop.DataAccess.Repository
{
    public class LabelRepository : Repository<Label>, ILabelRepository
    {
        private ApplicationDbContext _db;

        public LabelRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Label obj)
        {
            _db.Labels.Update(obj);
        }
    }
}
