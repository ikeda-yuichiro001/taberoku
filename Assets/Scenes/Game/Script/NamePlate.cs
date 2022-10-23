using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NamePlate : MonoBehaviour
{
    //public RawImage PreColor;
    //public Text PreName;
    public RawImage Color;
    public Text Name;
    //public string []NamePleat;
    void Start()
    {
        //DATA_.userData.Load();//ikeda‚³‚ñ‚ªì‚é–¼‘O‚âF‚ğŠi”[‚·‚é“z‚ğƒ[ƒh
        print(DATA_.userData.data.Count);
        //Color = new RawImage[Stage.Menber];
        //Name = new Text[Stage.Menber];
        for (int n = 0; n < OPTION.menberLen; n++)
        {
            if (Stage.num[n] == (int)DATA_.userData.data[n].id)
            {
                //print(DATA_.userData.data[n].color);
                Name.text = DATA_.userData.data[n].name;
                switch (DATA_.userData.data[n].color)
                {
                    case 0:
                        Color.color = new Color(1.0f, 0.0f, 0.0f, 0.4f);
                        break;
                    case 1:
                        Color.color = new Color(0.0f, 1.0f, 0.0f, 0.4f);
                        break;
                    case 2:
                        Color.color = new Color(0.0f, 0.0f, 1.0f, 0.4f);
                        break;
                    case 3:
                        Color.color = new Color(1.0f, 1.0f, 0.0f, 0.4f);
                        break;
                    case 4:
                        Color.color = new Color(1.0f, 0.0f, 1.0f, 0.4f);
                        break;
                    case 5:
                        Color.color = new Color(0.0f, 1.0f, 1.0f, 0.4f);
                        break;
                    case 6:
                        Color.color = new Color(1.0f, 1.0f, 1.0f, 0.4f);
                        break;
                    case 7:
                        Color.color = new Color(1.0f, 0.65f, 0.0f, 0.4f);
                        break;
                    case 8:
                        Color.color = new Color(0.5f, 0.0f, 0.5f, 0.4f);
                        break;
                    case 9:
                        Color.color = new Color(0.65f, 0.16f, 0.16f, 0.4f);
                        break;
                }
            }
        }
    }
}
