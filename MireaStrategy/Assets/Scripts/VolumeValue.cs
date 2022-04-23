using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeValue : MonoBehaviour
{
    public GameObject audioSrc;
    private float musicVolume;

    private void Update()
    {
        audioSrc.GetComponent<AudioSource>().volume = musicVolume;
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
