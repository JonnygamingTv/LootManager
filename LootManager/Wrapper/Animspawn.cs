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
    public class Animspawn
    {
        public Animspawn() { }
        public Animspawn(ushort newAnimal) { animal = newAnimal; }

        public ushort animal { get; }
    }
}
