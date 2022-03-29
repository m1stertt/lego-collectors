using System.Collections.Generic;
using System.IO;
using LegoCollectors.Core.IServices;
using LegoCollectors.Core.Models;
using LegoCollectors.Domain.IRepositories;

namespace LegoCollectors.Domain.Service
{
    public class LegoStockService : ILegoStockService
    {
        private readonly ILegoStockRepository _legoStockRepository;

        public LegoStockService(ILegoStockRepository legoStockRepository)
        {
            _legoStockRepository = legoStockRepository ?? throw new InvalidDataException("LegoStockRepository Cannot Be Null");
        }

        public LegoStock FindById(int id)
        {
            return _legoStockRepository.FindById(id);
        }

        public LegoStock Create(LegoStock legoStock)
        {
            return _legoStockRepository.Create(legoStock);
        }

        public LegoStock Update(LegoStock legoStock)
        {
            return _legoStockRepository.Update(legoStock);
        }

        public LegoStock DeleteById(int id)
        {
            return _legoStockRepository.DeleteById(id);
        }

        public List<LegoStock> FindByUserId(int id)
        {
            return _legoStockRepository.FindByUserId(id);
        }
    }
}