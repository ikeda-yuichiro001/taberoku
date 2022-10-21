using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NamePlate : MonoBehaviour
{
    public RawImage PreColor;
    public Text PreName;
    RawImage []Color;
    Text []Name;
    public string []NamePleat;
    void Start()
    {
        DATA_.userData.Load();//ikedaさんが作る名前や色を格納する奴をロード
        Color = new RawImage[Stage.Menber];
        Name = new Text[Stage.Menber];
        for(int n = 0; n < Stage.Menber;n++)
        {
            PreName.text = NamePleat[n];
            PreColor.color = new Color32(1, 1, 1, 1);
            Name[n] = PreName;
            Color[n] = PreColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
