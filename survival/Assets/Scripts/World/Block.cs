using UnityEngine;

namespace Assets.Scripts
{
    public enum BlockType
    {
        Grass,
        Dirt,
        Stone,
        Coal,
        Iron
    }

    public class Block : MonoBehaviour
    {
        public BlockType BlockType;

        void Start()
        {

        }
    }
}
