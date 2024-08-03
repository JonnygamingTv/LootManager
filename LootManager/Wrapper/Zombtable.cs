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
    public class Zombtable
    {
        public string name;
        public bool isMega;
        public ushort health;
        public byte damage;
        public byte lootIndex;
        public ushort lootID;
        public uint xp;
        public float regen;

        public Zombtable() { }
        public Zombtable(string newName)
        {
            name = newName;
        }
        public Zombtable(ZombieSlot[] newSlots, Color newColor, string newName, bool newMega, ushort newHealth, byte newDamage, byte newLootIndex, ushort newLootID, uint newXP, float newRegen, string newDifficultyGUID, int newTableUniqueId)
        {
            slots = newSlots;
            color = newColor;
            name = newName;
            isMega = newMega;
            health = newHealth;
            damage = newDamage;
            lootIndex = newLootIndex;
            lootID = newLootID;
            xp = newXP;
            regen = newRegen;
            difficultyGUID = newDifficultyGUID;
            tableUniqueId = newTableUniqueId;
        }
        public Zombtable(Zombslot[] newSlots, Color newColor, string newName, bool newMega, ushort newHealth, byte newDamage, byte newLootIndex, ushort newLootID, uint newXP, float newRegen, string newDifficultyGUID, int newTableUniqueId)
        {
            _slots = newSlots;
            color = newColor;
            name = newName;
            isMega = newMega;
            health = newHealth;
            damage = newDamage;
            lootIndex = newLootIndex;
            lootID = newLootID;
            xp = newXP;
            regen = newRegen;
            difficultyGUID = newDifficultyGUID;
            tableUniqueId = newTableUniqueId;
            foreach (Zombslot zslot in _slots) slots[slots.Length] = new ZombieSlot(zslot.chance, zslot.GetTable());
        }

        //
        // Summary:
        //     ID unique to this zombie table in the level. If this table is deleted the ID
        //     will not be recycled. Used to refer to zombie table from external files, e.g.,
        //     NPC zombie kills condition.
        public int tableUniqueId { get; }
        public Color color { get; set; }
        public Zombslot[] _slots;
        private ZombieSlot[] slots { get; }
        public AssetReference<ZombieDifficultyAsset> difficulty { get; set; }
        public string difficultyGUID { get; set; }
        public ZombieSlot[] GetSlots() { return slots; }
    }
}
