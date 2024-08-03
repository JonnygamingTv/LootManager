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
        public bool ModifySpawns;
        public bool ModifyItems;
        public bool ModifyAnimals;
        public bool ModifyZombs;
        public List<Wrapper.Spawnpointitem> SpawnpointA;
        public List<Wrapper.Spawnpointitem> SpawnpointB;
        public List<Wrapper.TableItem> itemTable;
        public List<Wrapper.Animtable> animalTable;
        public List<Wrapper.Zombtable> zombieTable;
        public void LoadDefaults()
        {
            ModifySpawns = false;
            ModifyItems = false;
            ModifyAnimals = false;
            ModifyZombs = true;
            SpawnpointA = new List<Wrapper.Spawnpointitem>();
            SpawnpointB = new List<Wrapper.Spawnpointitem>();
            itemTable = new List<Wrapper.TableItem>();
            animalTable = new List<Wrapper.Animtable>();
            zombieTable = new List<Wrapper.Zombtable>();
        }
    }
}
