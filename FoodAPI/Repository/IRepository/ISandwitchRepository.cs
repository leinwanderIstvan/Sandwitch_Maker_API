using FoodAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAPI.Repository.IRepository
{
    public interface ISandwitchRepository
    {
        //Perform CRUD operation

        //GET Sandwitches(as collection)
        ICollection<Sandwich> GetSandwitches();
        //GET Sandwitch
        Sandwich GetSandwitch(int sandwitchId);
        //GET sandwitch exits by name
        bool SandwitchExists(string name);
        //GET sandwitch exits by id
        bool SandwitchExists(int id);
        //POST creat new sandwitch
        bool CreateSandwitch(Sandwich sandwich);
        //PATCH update existing sandwitch 
        bool UpdateSandwitch(Sandwich sandwich);
        //DELETE sandwitch
        bool DeleteSandwitch(Sandwich sandwich);
        // Save changes
        bool Save();
    }
}
