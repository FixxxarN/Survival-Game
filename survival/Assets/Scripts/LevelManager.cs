using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckpoint;
    private PlayerController player;

    public GameObject DeathParticle;

    public float RespawnDelay;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo()
    {
        Instantiate(DeathParticle, player.transform.position, player.transform.rotation);
        player.enabled = false;
        player.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(RespawnDelay);
        player.transform.position = currentCheckpoint.transform.position;
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.enabled = true;
    }
}
