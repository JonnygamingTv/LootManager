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
    public class TableItem
    {
        public string name;
        public ushort tableID;

        public TableItem() { }
        public TableItem(string newName) { name = newName; }
        public TableItem(List<ItemTier> newTiers, Color newColor, string newName, ushort newTableID) {
            tiers = newTiers;
            color = newColor;
            name = newName;
            tableID = newTableID;
            foreach (ItemTier tier in tiers) _tiers.Add(new TierItem(tier.table, tier.name, tier.chance));
        }
        public TableItem(List<TierItem> newTiers, Color newColor, string newName, ushort newTableID)
        {
            _tiers = newTiers;
            color = newColor;
            name = newName;
            tableID = newTableID;
            foreach (TierItem tier in _tiers) tiers.Add(new ItemTier(tier.getTable(), tier.name, tier.chance));
        }
        public List<ItemTier> GetTiers() { return tiers; }

        public List<TierItem> _tiers;
        private List<ItemTier> tiers { get; }
        public Color color { get; set; }
    }
}
