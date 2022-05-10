using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.germanfica.vrmmorpg.entity
{
    [Serializable]
    public class Item
    {
        /*
        public string id;
        public string name;
        public int level;
        public int durability;
        public string player_character_id;
        */

        public string id;
        public int level;
        public int durability;
        public string playerCharacterId;

        public Item(ScriptableItem data)
        {
            this.data = data;
        }

        public ScriptableItem data;

        public string name => data.name;
        public string detail => data.detail;
        public bool tradable => data.tradable;
        public Sprite image => data.image;
    }
}
