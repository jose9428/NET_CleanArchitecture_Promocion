using Entities.POCO;
using System.Collections.Generic;

namespace Entities.Interfaces
{
    public interface IPromocionRepository
    {
        void Create(Promocion promocion);
        void Update(Promocion promocion);
        IEnumerable<Promocion> GetAll();
    }
}
