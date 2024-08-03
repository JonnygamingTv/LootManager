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
                foreach (AnimalTable animal in LevelAnimals.tables)
                {
                    Configuration.Instance.animalTable.Add(new Wrapper.Animtable(animal.tiers, animal.color, animal.name, animal.tableID));
                }
                change = true;
            }
            else if(Configuration.Instance.ModifyAnimals)
            {
                Rocket.Core.Logging.Logger.Log("Modifying Animal tables");
                LevelAnimals.tables.Clear();
                foreach(Wrapper.Animtable animal in Configuration.Instance.animalTable)
                {
                    LevelAnimals.tables.Add(new AnimalTable(animal.GetTier(),animal.color,animal.name,animal.tableID));
                }
                Rocket.Core.Logging.Logger.Log("Modified Animal tables");
            }
            if (Configuration.Instance.zombieTable.Count == 0)
            {
                foreach (ZombieTable zomb in LevelZombies.tables)
                {
                    Configuration.Instance.zombieTable.Add(new Wrapper.Zombtable(zomb.slots, zomb.color, zomb.name, zomb.isMega, zomb.health,zomb.damage,zomb.lootIndex,zomb.lootID,zomb.xp,zomb.regen,zomb.difficultyGUID,zomb.tableUniqueId));
                }
                change = true;
            }
            else if (Configuration.Instance.ModifyZombs)
            {
                LevelZombies.tables.Clear();
                foreach (Wrapper.Zombtable zomb in Configuration.Instance.zombieTable)
                {
                    LevelZombies.tables.Add(new ZombieTable(zomb.GetSlots(), zomb.color, zomb.name, zomb.isMega, zomb.health, zomb.damage, zomb.lootIndex, zomb.lootID, zomb.xp, zomb.regen, zomb.difficultyGUID, zomb.tableUniqueId));
                }
                Rocket.Core.Logging.Logger.Log("Modified Zombie tables");
            }
            if(change)Configuration.Save();
        }
    }
}
