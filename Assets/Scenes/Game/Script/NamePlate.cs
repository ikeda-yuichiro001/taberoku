using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NamePlate : MonoBehaviour
{
    public RawImage PreColor;
    public Text PreName;
    public RawImage[] Color;
    public Text[] Name;
    public int number;
    //public string []NamePleat;
    void Start()
    {
        OPTION.Load();
        DATA_.userData.Load();//ikeda‚³‚ñ‚ªì‚é–¼‘O‚âF‚ğŠi”[‚·‚é“z‚ğƒ[ƒh
        Color = new RawImage[OPTION.menberLen];
        Name = new Text[OPTION.menberLen];
        //print(DATA_.userData.data.Count);
        for (int n = 0; n < OPTION.menberLen; n++)
        {
            //Color[n]=
            //number = Stage.num[n];
            for (int N = 0; N < OPTION.menberLen; N++)
            {
                //print(Stage.num[n]);
                //print((int)DATA_.userData.data[n].id);
                switch ((int)DATA_.userData.data[N].id)
                {
                    case 0:
                        break;
                }
                /*if (Stage.num[n] == (int)DATA_.userData.data[N].id)
                {
                    //print(DATA_.userData.data[n].color);
                    Name.text = DATA_.userData.data[N].name;
                    switch (DATA_.userData.data[N].color)
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
                }*/
            }
        }
    }
}
