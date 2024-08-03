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
    public class Spawnpointitem
    {
        public byte type;

        public Spawnpointitem() { }
        public Spawnpointitem(byte newType, Vector3 newPoint)
        {
            type = newType;
            point = newPoint;
        }

        public Vector3 point { get; }
    }
}
