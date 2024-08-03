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
    public class Animtable
    {
        public string name;
        public ushort tableID;
        public List<Animtier> _tiers { get; }
        private List<AnimalTier> tiers { get; }
        public Color color { get; set; }
        public Animtable() { }
        public Animtable(string newName)
        {
            name = newName;
        }
        public Animtable(List<Wrapper.Animtier> newTiers, Color newColor, string newName, ushort newTableID)
        {
            color = newColor;
            name = newName;
            tableID = newTableID;
            foreach(Animtier _tier in newTiers)
            {
                tiers.Add(new AnimalTier(_tier.getTable(), _tier.name, _tier.chance));
            }
        }
        public Animtable(List<AnimalTier> newTiers, Color newColor, string newName, ushort newTableID)
        {
            tiers = newTiers;
            color = newColor;
            name = newName;
            tableID = newTableID;
            foreach (AnimalTier atier in newTiers) _tiers.Add(new Animtier(atier.table, atier.name, atier.chance));
        }

        public List<AnimalTier> GetTier() { return tiers; }
    }
}
