using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinylShop.DataAccess.Repository.IRepository;

namespace VinylShop.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Label = new LabelRepository(_db);
            Author = new AuthorRepository(_db);
            VinylPlate = new VinylPlateRepository(_db);
            Manufacturer = new ManufacturerRepository(_db);
            VinylPlayer = new VinylPlayerRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
            OrderHeader = new OrderHeaderRepository(_db);
            OrderDetail = new OrderDetailRepository(_db);
        }

        public ICategoryRepository Category { get; private set; }
        public ILabelRepository Label { get; private set; }
        public IAuthorRepository Author { get; private set; }  
        public IVinylPlateRepository VinylPlate { get; private set; }
        public IManufacturerRepository Manufacturer { get; private set; }
        public IVinylPlayerRepository VinylPlayer { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IOrderHeaderRepository OrderHeader { get; private set; }
        public IOrderDetailRepository OrderDetail { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
