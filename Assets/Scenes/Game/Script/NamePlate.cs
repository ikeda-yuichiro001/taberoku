using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NamePlate : MonoBehaviour
{
    public Text []Name;
    public RawImage []Color;
    void Start()
    {
        //ikedaさんが作る名前や色を格納する奴をロード
        Name = new Text[Stage.Menber];
        Color = new RawImage[Stage.Menber];
        for (int c = 0; c < Stage.Menber; c++)
        {
            Name[c].text = ("斉藤");
            Color[c].color = new Color32(1,1,1,1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
