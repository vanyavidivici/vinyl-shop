using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinylShop.Models;

namespace VinylShop.DataAccess.Repository.IRepository
{
    public interface IVinylPlateRepository : IRepository<VinylPlate>
    {
        void Update(VinylPlate obj);
    }
}
