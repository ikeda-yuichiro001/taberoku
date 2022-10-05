using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public AudioSource bgm;
    void Start()
    {
        OPTION.Load();
    }
    void Update()
    {
        bgm.volume = OPTION.bgm;
    }
}
