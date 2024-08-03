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
    public class TierItem
    {
        public string name;
        public float chance;

        public TierItem() { }
        public TierItem(List<ItemSpawn> newTable, string newName, float newChance)
        {
            table = newTable;
            name = newName;
            chance = newChance;
            foreach (ItemSpawn item in table) _table.Add(new Itemspawn(item.item));
        }
        public TierItem(List<Wrapper.Itemspawn> newTable, string newName, float newChance)
        {
            _table = newTable;
            name = newName;
            chance = newChance;
            foreach (Itemspawn item in _table) table.Add(new ItemSpawn(item.item));
        }

        public List<Wrapper.Itemspawn> _table;
        private List<ItemSpawn> table { get; }
        public List<ItemSpawn> getTable() { return table; }
    }
}
