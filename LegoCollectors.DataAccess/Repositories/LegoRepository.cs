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

        public List<Lego> FindAll()
        {
            return _context.Legos.Select(pe => new Lego
                {
                    Id = pe.Id,
                    Title=pe.Title,
                    Description = pe.Description
                })
                .ToList();
        }

        public Lego FindById(int id)
        {
            if (id == 0) return null;
            return _context.Legos.Select(pe => new Lego
            {
                Id = pe.Id,
                Title=pe.Title,
                Description = pe.Description
            }).FirstOrDefault(lego => lego.Id == id);
        }

        public Lego Create(Lego lego)
        {
            if (lego == null) return null;
            var entity = new LegoEntity()
            {
                Title=lego.Title,
            };
            var savedEntity = _context.Legos.Add(entity).Entity;
            _context.SaveChanges();
            return new Lego()
            {
                Id = lego.Id,
                Title=lego.Title,
            };
        }

        public Lego Update(Lego lego)
        {
            if (lego == null) return null;
            var pe = _context.Update(new LegoEntity
            {
                Id = lego.Id,
                Title = lego.Title
            }).Entity;
            _context.SaveChanges();
            return new Lego
            {
                Id = pe.Id,
                Title = pe.Title
            };
        }

        public Lego DeleteById(int id)
        {
            if (id == 0) return null;
            var savedEntity = _context.Legos.Remove(new LegoEntity() {Id = id}).Entity;
            _context.SaveChanges();
            return new Lego()
            {
                Id = savedEntity.Id,
                Title = savedEntity.Title,
            };
        }
    }
}