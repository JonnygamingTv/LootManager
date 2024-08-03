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
        public List<Wrapper.Animtable> animalTable;
        public List<Wrapper.Zombtable> zombieTable;
        public void LoadDefaults()
        {
            ModifyAnimals = false;
            ModifyZombs = true;
            animalTable = new List<Wrapper.Animtable>();
            zombieTable = new List<Wrapper.Zombtable>();
        }
    }
}
