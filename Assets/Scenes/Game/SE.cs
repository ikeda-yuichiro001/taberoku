using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : MonoBehaviour
{
    public AudioClip[] Crip;
    public AudioSource Audio;
    public static AudioClip[] CRIP;
    public static AudioSource AUDIO;
    void Start()
    {
        CRIP = new AudioClip[Crip.Length];
        for (int a = 0; a < Crip.Length; a++)
        {
            CRIP[a] = Crip[a];
        }
        AUDIO = Audio;
    }
}
