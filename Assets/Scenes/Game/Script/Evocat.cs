using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Evocat : MonoBehaviour
{
    public GameObject batuGAME;
    public Text[] texts;
    Color color;
    private float time;
    public void Texts()
    {
        time += Time.deltaTime * 2.0f;
        color.a = Mathf.Sin(time);
        for(int c = 0;c < texts.Length;c++)
        {
            color = new Color(texts[c].color.r, texts[c].color.g, texts[c].color.b, color.a);
            texts[c].color = color;
        }
    }
    public void SinGame()
    {

    }
}
