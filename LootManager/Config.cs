using Rocket.API;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootManager
{
    public class Config : IRocketPluginConfiguration
    {
        public bool ModifyAnimals;
        public bool ModifyZombs;
        public List<AnimalTable> animalTable;
        public List<ZombieTable> zombieTable;
        public void LoadDefaults()
        {
            ModifyAnimals = false;
            ModifyZombs = true;
            animalTable = new List<AnimalTable>();
            zombieTable = new List<ZombieTable>();
        }
    }
}
