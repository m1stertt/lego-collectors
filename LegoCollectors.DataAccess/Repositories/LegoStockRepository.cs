using System.Collections.Generic;
using System.IO;
using System.Linq;
using LegoCollectors.Core.Models;
using LegoCollectors.DataAccess.Entities;
using LegoCollectors.Domain.IRepositories;
using LegoCollectors.Security.Model;

namespace LegoCollectors.DataAccess.Repositories
{
    public class LegoStockRepository : ILegoStockRepository
    {
        private readonly MainDbContext _context;

        public LegoStockRepository(MainDbContext ctx)
        {
            _context = ctx ?? throw new InvalidDataException("Product Repository Must have a DBContext");
        }

        public LegoStock FindById(int id)
        {
            return _context.LegoStock
                .Select(pe=>new LegoStock
                {
                    Id = pe.Id,
                    Amount = pe.Amount,
                    User = new LoginUser
                    {
                        Id = pe.User.Id,
                        Email = pe.User.Email
                    }
                }).FirstOrDefault(e => e.Id==id);
        }

        public LegoStock Create(LegoStock legoStock)
        {
            var invStockEntity = new LegoStockEntity()
            {
                Id = legoStock.Id,
                Amount = legoStock.Amount,
            };
            if (legoStock.User.Id > 0)
            {
                //invStockEntity.User = _context.User.FirstOrDefault(r => r.Id == legoStock.Product.Id);
            }
            else return null;
            var pe = _context.LegoStock.Add(invStockEntity).Entity;
            _context.SaveChanges();
            return new LegoStock()
            {
                Id = pe.Id,
                Amount = pe.Amount,
                User = new LoginUser
                {
                    Id = pe.User.Id,
                },
            };
        }

        public LegoStock Update(LegoStock legoStock)
        {
            if (legoStock == null) return null;
            var savedEntity = _context.Update(new LegoStockEntity()
            {
                Id = legoStock.Id,
                Amount = legoStock.Amount,
            }).Entity;
            _context.SaveChanges();
            return new LegoStock()
            {
                Id = savedEntity.Id,
                Amount = savedEntity.Amount,
            };
        }

        public LegoStock DeleteById(int id)
        {
            if (id <= 0) return null;
            _context.LegoStock.Remove(new LegoStockEntity() {Id = id});
            _context.SaveChanges();
            return new LegoStock()
            {
                Id = id,
            };
        }

        public List<LegoStock> FindByUserId(int id)
        {
            return _context.LegoStock.Select(pe => new LegoStock
                {
                    Id = pe.Id,
                    Amount = pe.Amount,
                    User = new LoginUser
                    {
                        Id = pe.User.Id,
                    },
                }).Where(e=>e.User.Id==id)
                .ToList();
        }
    }
}