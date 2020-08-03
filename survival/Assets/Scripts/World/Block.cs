using System.Collections;
using System.Threading.Tasks;
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
        public float DestroyTime;
        private IEnumerator coroutine;
        private bool isBeingDestroyed = false;

        public float Timer = 0.0f;

        private int index = 0;

        public void DestroyBlock(Sprite[] animation)
        {
            coroutine = AnimateAndDestoryBlock(animation);
            StartCoroutine(coroutine);
        }

        private IEnumerator AnimateAndDestoryBlock(Sprite[] animation)
        {
            float time = DestroyTime / animation.Length;
            isBeingDestroyed = true;
            while (isBeingDestroyed)
            {
                for(int i = 0; i < animation.Length; i++)
                {
                    if(!Input.GetMouseButton(0))
                    {
                        GetComponent<SpriteRenderer>().sprite = animation[0];
                        isBeingDestroyed = false;
                        break;
                    }
                    GetComponent<SpriteRenderer>().sprite = animation[i];
                    if(i == animation.Length - 1)
                    {
                        Destroy(gameObject);
                        break;
                    }
                    yield return new WaitForSeconds(time);
                }
            }
        }
    }
}
