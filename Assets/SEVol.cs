using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEVol : MonoBehaviour
{
    public AudioSource se;
    void Start()
    {
        OPTION.Load();
    }
    void Update()
    {
        se.volume = OPTION.se;
    }
}
