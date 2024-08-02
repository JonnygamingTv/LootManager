using Rocket.Core.Plugins;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootManager
{
    public class Class1 : RocketPlugin<Config>
    {
        protected override void Load()
        {
            Level.onLevelLoaded += OLL;
            Rocket.Core.Logging.Logger.Log("Loaded");
        }
        protected override void Unload()
        {
            Level.onLevelLoaded -= OLL;
            Rocket.Core.Logging.Logger.Log("Unloaded");
        }
        void OLL(int L)
        {
            bool change=false;
            if (Configuration.Instance.animalTable.Count == 0)
            {
                Configuration.Instance.animalTable = LevelAnimals.tables;
                change = true;
            }
            else if(Configuration.Instance.ModifyAnimals)
            {
                Rocket.Core.Logging.Logger.Log("Modifying Animal tables");
                LevelAnimals.tables.Clear();
                foreach(AnimalTable animal in Configuration.Instance.animalTable)
                {
                    LevelAnimals.tables.Add(animal);
                }
                Rocket.Core.Logging.Logger.Log("Modified Animal tables");
            }
            if (Configuration.Instance.zombieTable.Count == 0)
            {
                Configuration.Instance.zombieTable = LevelZombies.tables;
                change = true;
            }
            else if (Configuration.Instance.ModifyZombs)
            {
                LevelZombies.tables = Configuration.Instance.zombieTable;
                Rocket.Core.Logging.Logger.Log("Modified Zombie tables");
            }
            if(change)Configuration.Save();
        }
    }
}
