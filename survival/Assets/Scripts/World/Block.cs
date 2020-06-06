using UnityEngine;

namespace Assets.Scripts
{
    public class Block : MonoBehaviour
    {
        void OnMouseEnter()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(gameObject);
            }
        }
    }
}
