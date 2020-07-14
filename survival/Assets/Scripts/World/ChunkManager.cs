using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    public List<Transform> blocks;
    private ChunksHandler chunksHandler;
    // Start is called before the first frame update
    void Start()
    {
        chunksHandler = FindObjectOfType<ChunksHandler>();
        foreach(Transform child in transform)
        {
            blocks.Add(child);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void OnMouseOver()
    //{
    //    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        foreach(var block in blocks.ToList())
    //        {
    //            if(block.position.x > worldPosition.x - 0.05 &&
    //                block.position.x < worldPosition.x + 0.05 &&
    //                block.position.y > worldPosition.y - 0.05 &&
    //                block.position.y < worldPosition.y + 0.05)
    //            {
    //                blocks.Remove(block);
    //                Destroy(block.gameObject);
    //            }
    //        }
    //    }
    //    if (Input.GetMouseButtonDown(1))
    //    {
    //        foreach (var block in blocks.ToList())
    //        {
    //            if (block.position.x > worldPosition.x - 0.05 &&
    //                block.position.x < worldPosition.x + 0.05 &&
    //                block.position.y > worldPosition.y - 0.05 &&
    //                block.position.y < worldPosition.y + 0.05)
    //            {
    //                Debug.Log("There is a block here");
    //            }
    //            else
    //            {
    //                GameObject b = (GameObject)Instantiate(chunksHandler.IronPrefab, worldPosition, Quaternion.identity, this.transform);
    //                blocks.Add(b.transform);
    //                break;
    //            }
    //        }
    //    }
    //}
}
