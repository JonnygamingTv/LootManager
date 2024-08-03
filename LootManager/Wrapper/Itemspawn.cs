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
    public class Itemspawn
    {
        public Itemspawn() { }
        public Itemspawn(ushort newItem) { item = newItem; }

        public ushort item { get; }
    }
}
