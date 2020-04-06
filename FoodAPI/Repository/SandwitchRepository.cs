using FoodAPI.Data;
using FoodAPI.Models;
using FoodAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAPI.Repository
{
    public class SandwitchRepository : ISandwitchRepository
    {
        // need db object to reach database
        private readonly ApplicationDbContext _db;

        public SandwitchRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        public bool CreateSandwitch(Sandwich sandwich)
        {
            _db.Sandwitches.Add(sandwich);
            return Save();
        }

        public bool DeleteSandwitch(Sandwich sandwich)
        {
            _db.Sandwitches.Remove(sandwich);
            return Save();
        }

        public Sandwich GetSandwitch(int sandwitchId)
        {
            return _db.Sandwitches.FirstOrDefault(sandwitch => sandwitch.ID == sandwitchId);
        }

        public ICollection<Sandwich> GetSandwitches()
        {
            return _db.Sandwitches.OrderBy(sandwitch => sandwitch.SandwichName).ToList();
        }

        public bool SandwitchExists(string name)
        {
            var value = _db.Sandwitches.Any(sandwitch => sandwitch.SandwichName.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool SandwitchExists(int id)
        {
            return _db.Sandwitches.Any(a => a.ID == id);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateSandwitch(Sandwich sandwich)
        {
            _db.Sandwitches.Update(sandwich);
            return Save();
        }
    }
}
