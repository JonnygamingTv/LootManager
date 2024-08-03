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
    public class Zombslot
    {
        public float chance;
        public Zombslot() { }
        public Zombslot(float newChance, List<ZombieCloth> newTable)
        {
            table = newTable;
            foreach (ZombieCloth zcloth in table) _table.Add(new Zombcloth(zcloth.item));
        }
        public Zombslot(float newChance, List<Zombcloth> newTable)
        {
            _table = newTable;
            foreach (Zombcloth zcloth in _table) table.Add(new ZombieCloth(zcloth.item));
        }

        public List<Zombcloth> _table;
        private List<ZombieCloth> table { get; }
        public List<ZombieCloth> GetTable() { return table; }

        public void addCloth(ushort id) { }
        public void removeCloth(byte index) { }
    }
}
