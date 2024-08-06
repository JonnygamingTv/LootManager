using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LootManager.Wrapper
{
    [Serializable]
    public class Animtier
    {
        public string name;
        public float chance;
        public Animtier() { }
        public Animtier(List<Wrapper.Animspawn> newTable, string newName, float newChance)
        {
            _table = newTable;
            name = newName;
            chance = newChance;
            foreach (Animspawn _spawn in newTable)
            {
                table.Add(new AnimalSpawn(_spawn.animal));
            }
        }
        public Animtier(List<AnimalSpawn> newTable, string newName, float newChance)
        {
            table = newTable;
            name = newName;
            chance = newChance;
            foreach (AnimalSpawn _spawn in newTable)
            {
                _table.Add(new Animspawn(_spawn.animal));
            }
        }

        public List<Animspawn> _table;
        private List<AnimalSpawn> table { get; }
        public List<AnimalSpawn> getTable() { return table; }
    }
}
