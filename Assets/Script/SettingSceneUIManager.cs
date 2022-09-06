using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingSceneUIManager : MonoBehaviour
{
    public Text Number, TimeLimits, ResponseTime, BGM, SE;
    public static int n, l, r, b, s;
    void Start()
    {
        n = 1;l = 30;r = 150; b = 60;s = 60; OPTION.Load();
    }
    void Update()
    {
        Number.text = (n + "êl");
        TimeLimits.text = (l + "ï™");
        ResponseTime.text = (r + "ïb");
        BGM.text = (b + "%");
        SE.text = (s + "%");
    }
}
