using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tbox : MonoBehaviour
{
    float alf;
    public RawImage Back;
    public Text h1, bun;
    void SetUp()
    {
        Back.color = new Color(Back.color.r, Back.color.g, Back.color.b, 0);
        h1.color = new Color(0, 0, 0, 0);
        bun.color = new Color(0, 0, 0, 0);
    }
    void Create()
    {
        SetUp();
        alf += Time.deltaTime;
        Back.color = new Color(Back.color.r, Back.color.g, Back.color.b, alf);
        if(Back.color.a >= 1.0f)
        {
            h1.color = new Color(0, 0, 0, 1.0f);
            bun.color = new Color(0, 0, 0, 1.0f);
        }
    }
}
