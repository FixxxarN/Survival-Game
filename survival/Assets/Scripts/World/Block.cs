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

        public void OnMouseOver()
        {
            if(Input.GetMouseButtonDown(0))
                gameObject.SetActive(false);
            //if(other.bounds.Contains(Input.mousePosition * 0.125f))
            //{
            //    Debug.Log("Blocktype: " + BlockType);
            //}
        }
    }
}
