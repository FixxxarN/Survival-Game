using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryFinishedParticle : MonoBehaviour
{
    private ParticleSystem thisParticleSystem;

    void Start()
    {
        thisParticleSystem = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (thisParticleSystem.isPlaying)
            return;
        else
            Destroy(gameObject);
    }
}
