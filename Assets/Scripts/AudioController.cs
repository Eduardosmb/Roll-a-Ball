using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioSource music;
    public AudioSource sfx;

    public AudioClip backgournd;
    public AudioClip chaveAudio;
    public AudioClip pickupAudio;

    void Start()
    {
        music.clip = backgournd;
        music.loop = true;
        music.Play();
    }

    public void chaveSFX(){
        sfx.clip = chaveAudio;
        sfx.Play();
    }

    public void pickupSFX(){
        sfx.clip = pickupAudio;
        sfx.Play();
    }
}
