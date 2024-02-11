using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinylShop.Models;

namespace VinylShop.DataAccess.Repository.IRepository
{
    public interface IManufacturerRepository : IRepository<Manufacturer>
    {
        void Update(Manufacturer obj);
    }
}
