using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.World
{
    public class BlockAnimationsHandler : MonoBehaviour
    {
        public Sprite[] grassDestroyAnimation;
        public Sprite[] dirtDestroyAnimation;
        public Sprite[] stoneDestroyAnimation;
        public Sprite[] coalDestroyAnimation;
        public Sprite[] ironDestroyAnimation;

        public Sprite[] GetDestroyAnimationForSelectedBlock(BlockType blockType)
        {
            switch(blockType)
            {
                case BlockType.Grass:
                    return grassDestroyAnimation;
                case BlockType.Dirt:
                    return dirtDestroyAnimation;
                case BlockType.Stone:
                    return stoneDestroyAnimation;
                case BlockType.Coal:
                    return coalDestroyAnimation;
                case BlockType.Iron:
                    return ironDestroyAnimation;
                default: return new Sprite[0];
            }
        }
    }
}
