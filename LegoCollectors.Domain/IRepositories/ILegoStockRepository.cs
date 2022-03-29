using System.Collections.Generic;
using LegoCollectors.Core.Models;

namespace LegoCollectors.Domain.IRepositories
{
    public interface ILegoStockRepository
    {
        LegoStock FindById(int id);
        LegoStock Create(LegoStock legoStock);
        LegoStock Update(LegoStock legoStock);
        LegoStock DeleteById(int id);
        List<LegoStock> FindByUserId(int id);
    }
}