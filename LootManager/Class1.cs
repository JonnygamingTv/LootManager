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
        Class1 Instance;
        protected override void Load()
        {
            if (Instance != null) OLL(0);
            Instance = this;
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
            if(Configuration.Instance.itemTable.Count == 0)
            {
                foreach(ItemTable itemtab in LevelItems.tables)
                {
                    Configuration.Instance.itemTable.Add(new Wrapper.TableItem(itemtab.tiers, itemtab.color, itemtab.name, itemtab.tableID));
                }
                change = true;
            }else if (Configuration.Instance.ModifyItems)
            {
                LevelItems.tables.Clear();
                foreach(Wrapper.TableItem item in Configuration.Instance.itemTable)
                {
                    LevelItems.tables.Add(new ItemTable(item.GetTiers(),item.color,item.name,item.tableID));
                }
                Rocket.Core.Logging.Logger.Log("Modified Item tables");
            }
            if(Configuration.Instance.SpawnpointA.Count == 0)
            {
                foreach (List<ItemSpawnpoint> Spawnpoint in LevelItems.spawns) {
                    //List<Wrapper.Spawnpointitem> Spawnpoints = new List<Wrapper.Spawnpointitem>();
                    foreach (ItemSpawnpoint realSpawn in Spawnpoint) Configuration.Instance.SpawnpointA.Add(new Wrapper.Spawnpointitem(realSpawn.type, realSpawn.point));
                }
                change = true;
            }
            else if (Configuration.Instance.ModifySpawns)
            {
                List<ItemSpawnpoint> Spawnpoints = new List<ItemSpawnpoint>();
                foreach (Wrapper.Spawnpointitem Spawnpoint in Configuration.Instance.SpawnpointA)
                {
                    Spawnpoints.Add(new ItemSpawnpoint(Spawnpoint.type, Spawnpoint.point));
                }
                LevelItems.spawns[LevelItems.spawns.GetLength(0), LevelItems.spawns.GetLength(1)] = Spawnpoints;
                Rocket.Core.Logging.Logger.Log("Modified Itemspawn tables");
            }
            
            if(change)Configuration.Save();
        }
    }
}
