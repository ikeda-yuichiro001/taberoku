using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingSceneUIManager : MonoBehaviour
{
    public Text Number, TimeLimits, ResponseTime, BGM, SE;
    //public static int n, l, r, b, s;
    float b, s;
    void Start()
    {
        //n = 1;l = 30;r = 150; b = 60;s = 60;
        OPTION.Load();
    }
    void Update()
    {
        b = OPTION.bgm * 1000;
        s = OPTION.se * 1000;
        Number.text =       (OPTION.menberLen + "êl");
        TimeLimits.text =   (OPTION.time + "ï™");
        ResponseTime.text = (OPTION.response + "ïb");
        BGM.text =          (b.ToString("N0") + "%");
        SE.text =           (s.ToString("N0") + "%");
    }
}
