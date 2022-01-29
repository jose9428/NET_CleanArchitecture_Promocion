using Entities.Interfaces;
using Entities.POCO;
using Repositories.EntityFrameworkCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EntityFrameworkCore.Repositories
{
    public class PromocionRepository : IPromocionRepository
    {
        readonly DatabaseContext DatabaseContext;
        public PromocionRepository(DatabaseContext databaseContext)
            => DatabaseContext = databaseContext;

        public void Create(Promocion promocion)
        {
            DatabaseContext.Add(promocion);
        }

        public IEnumerable<Promocion> GetAll()
        {
            return DatabaseContext.Promocion;
        }

        public void Update(Promocion promocion)
        {
            DatabaseContext.Update(promocion);
        }
    }
}
