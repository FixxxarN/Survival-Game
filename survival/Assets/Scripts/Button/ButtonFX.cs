using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFX : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip HoverAudio;

    public void HoverSound()
    {
        AudioSource.PlayOneShot(HoverAudio);
    }
}
