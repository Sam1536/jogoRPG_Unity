using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorSFX : MonoBehaviour
{
    [SerializeField] private  AudioSource audioSource;

    public void PlayerSFX(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
