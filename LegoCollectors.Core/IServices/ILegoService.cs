using System.Collections.Generic;
using LegoCollectors.Core.Models;

namespace LegoCollectors.Core.IServices
{
    public interface ILegoService
    {
        List<Lego> GetLegos();
        Lego GetLegoById(int id);
        Lego Create(Lego lego);
        Lego Update(Lego lego);
        Lego DeleteById(int id);
    }
}