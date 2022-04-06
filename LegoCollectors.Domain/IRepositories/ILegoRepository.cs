using System.Collections.Generic;
using LegoCollectors.Core.Models;

namespace LegoCollectors.Domain.IRepositories
{
    public interface ILegoRepository
    {
        List<Lego> FindAll(int ownerId);
        Lego? FindById(int id);
        Lego Create(Lego lego);
        Lego Update(Lego lego);
        Lego DeleteById(int id);
    }
}