using System.Collections.Generic;
using System.IO;
using System.Linq;
using LegoCollectors.Core.Models;
using LegoCollectors.DataAccess.Entities;
using LegoCollectors.Domain.IRepositories;

namespace LegoCollectors.DataAccess.Repositories
{
    public class LegoRepository : ILegoRepository
    {
        private readonly MainDbContext _context;

        public LegoRepository(MainDbContext ctx)
        {
            _context = ctx ?? throw new InvalidDataException("Lego Repository Must have a DBContext");
        }

        public List<Lego> FindAll(int ownerId)
        {
            return _context.Legos.Select(pe => new Lego
                {
                    Id = pe.Id,
                    Name=pe.Name,
                    Year=pe.Year,
                    Image=pe.Image,
                    Number_Parts = pe.Number_Parts,
                    Amount = pe.Amount,
                    Set_Number = pe.Set_Number,
                    OwnerId = pe.OwnerId
                }).Where(lego=>lego.OwnerId==ownerId)
                .ToList();
        }

        public Lego? FindById(int id)
        {
            if (id == 0) return null;
            return _context.Legos.Select(pe => new Lego
            {
                Id = pe.Id,
                Name=pe.Name,
                Year=pe.Year,
                Image=pe.Image,
                Number_Parts = pe.Number_Parts,
                Amount = pe.Amount,
                Set_Number = pe.Set_Number,
                OwnerId = pe.OwnerId
            }).FirstOrDefault(lego => lego.Id == id);
        }

        public Lego Create(Lego lego)
        {
            if (lego == null) return null;
            var entity = new LegoEntity()
            {
                Name=lego.Name,
                Year=lego.Year,
                Image=lego.Image,
                Number_Parts = lego.Number_Parts,
                Amount = lego.Amount,
                Set_Number = lego.Set_Number,
                OwnerId = lego.OwnerId
            };
            var pe = _context.Legos.Add(entity).Entity;
            _context.SaveChanges();
            return new Lego()
            {
                Id = pe.Id,
                Name=pe.Name,
                Year=pe.Year,
                Image=pe.Image,
                Number_Parts = pe.Number_Parts,
                Amount = pe.Amount,
                Set_Number = pe.Set_Number,
                OwnerId = pe.OwnerId
            };
        }

        public Lego Update(Lego lego)
        {
            if (lego == null) return null;
            var pe = _context.Update(new LegoEntity
            {
                Id = lego.Id,
                Name=lego.Name,
                Year=lego.Year,
                Image=lego.Image,
                Number_Parts = lego.Number_Parts,
                Amount = lego.Amount,
                Set_Number = lego.Set_Number,
                OwnerId = lego.OwnerId
            }).Entity;
            _context.SaveChanges();
            return new Lego()
            {
                Id = pe.Id,
                Name=pe.Name,
                Year=pe.Year,
                Image=pe.Image,
                Number_Parts = pe.Number_Parts,
                Amount = pe.Amount,
                Set_Number = pe.Set_Number,
                OwnerId = pe.OwnerId
            };
        }

        public Lego DeleteById(int id)
        {
            if (id == 0) return null;
            var pe = _context.Legos.Remove(new LegoEntity() {Id = id}).Entity;
            _context.SaveChanges();
            return new Lego()
            {
                Id = pe.Id,
                Name=pe.Name,
                Year=pe.Year,
                Image=pe.Image,
                Number_Parts = pe.Number_Parts,
                Amount = pe.Amount,
                Set_Number = pe.Set_Number,
                OwnerId = pe.OwnerId
            };
        }
    }
}