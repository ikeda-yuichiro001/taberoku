using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alpha : MonoBehaviour
{
    public RawImage Raw;
    public Text text;
    void Start()
    {
        
    }
    void Update()
    {
        text.color = new Color
            (StartManager.PlayerColor[DATA_.userData.data[Player.Num].color].r,
            StartManager.PlayerColor[DATA_.userData.data[Player.Num].color].g,
            StartManager.PlayerColor[DATA_.userData.data[Player.Num].color].b,
            Raw.color.r
            );
    }
}
