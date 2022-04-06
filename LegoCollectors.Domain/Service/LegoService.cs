using System.Collections.Generic;
using System.IO;
using LegoCollectors.Core.IServices;
using LegoCollectors.Core.Models;
using LegoCollectors.Domain.IRepositories;

namespace LegoCollectors.Domain.Service
{
    public class LegoService: ILegoService
    {
        private readonly ILegoRepository _legoRepository;

        public LegoService(ILegoRepository legoRepository)
        {
            _legoRepository = legoRepository ?? throw new InvalidDataException("LegoRepository Cannot Be Null");
        }
        public List<Lego> GetLegos(int ownerId)
        {
            return _legoRepository.FindAll(ownerId);
        }

        public Lego Create(Lego lego)
        {
            return _legoRepository.Create(lego);
        }

        public Lego? GetLegoById(int id)
        {
            return _legoRepository.FindById(id);
        }

        public Lego Update(Lego lego)
        {
            return _legoRepository.Update(lego);
        }

        public Lego DeleteById(int id)
        {
            return  _legoRepository.DeleteById(id);
        }
    }
}