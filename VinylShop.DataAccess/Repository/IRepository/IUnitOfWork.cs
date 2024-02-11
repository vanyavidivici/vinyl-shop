using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinylShop.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        ILabelRepository Label { get; }
        IAuthorRepository Author { get; }
        IVinylPlateRepository VinylPlate { get; }
        IManufacturerRepository Manufacturer { get; }
        IVinylPlayerRepository VinylPlayer { get; }
        IShoppingCartRepository ShoppingCart { get; }
        IApplicationUserRepository ApplicationUser { get; }
        IOrderDetailRepository OrderDetail { get; }
        IOrderHeaderRepository OrderHeader { get; }
        void Save();
    }
}
