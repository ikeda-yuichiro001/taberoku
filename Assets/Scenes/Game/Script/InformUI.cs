using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformUI : MonoBehaviour
{
    float SmokeTime;
    bool UIset;
    public GameObject InformBoxs;
   public GameObject newInformBoxs;
    //RawImage Smoke;
    public Texture[] images;
    bool start;
    void Start()
    {
    }
    public void Inform()
    {
        if (!UIset)
        {
            SE.AUDIO.PlayOneShot(SE.CRIP[6]);
            //Smoke.color = new Color(1, 1, 1, 0);
            InformBoxs.SetActive(true);
            newInformBoxs.SetActive(true);
            UIset = true;

            InformBoxs.GetComponent<RawImage>().texture = images[Player.Num];
            newInformBoxs.GetComponent<RawImage>().texture = images[Player.Num+1 % OPTION.menberLen];
            InformBoxs.GetComponent<RawImage>().color = Color.white;
            newInformBoxs.GetComponent<RawImage>().color = Color.clear;
        }

        SmokeTime += Time.deltaTime;

        if (SmokeTime < 4)
        {
            InformBoxs.GetComponent<RawImage>().color -= Color.white * Time.deltaTime / 4;
            newInformBoxs.GetComponent<RawImage>().color += Color.white * Time.deltaTime / 4;
        }

        else if (SmokeTime < 5)
        {
            InformBoxs.GetComponent<RawImage>().color = Color.clear;
            newInformBoxs.GetComponent<RawImage>().color = Color.white;
        }
        else
        {
            newInformBoxs.GetComponent<RawImage>().color -= Color.white * Time.deltaTime * 2;
        }

        /*
        if (SmokeTime < 3)
        {
            if (!start)
            {
                InformBoxs.GetComponent<RawImage>().texture = images[Player.Num];
                start = true;
            }
            else
            {
                if (Player.Num - 1 < 0)
                {
                    InformBoxs.GetComponent<RawImage>().texture = images[OPTION.menberLen - 1];

                }
                else
                {

                    InformBoxs.GetComponent<RawImage>().texture = images[Player.Num - 1];
                }
                Smoke.transform.localScale += new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
                if (Smoke.color.a < 1.0f) Smoke.color += new Color(0, 0, 0, Time.deltaTime);
            }
        }
        else
        {
            Smoke.transform.localScale += new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
            InformBoxs.GetComponent<RawImage>().texture = images[Player.Num];
            Smoke.color -= new Color(0, 0, 0, Time.deltaTime);
        }
        */
        if (SmokeTime > 6)
        {

            InformBoxs.GetComponent<RawImage>().color =
                newInformBoxs.GetComponent<RawImage>().color = Color.clear;
            UIset = false;
            InformBoxs.SetActive(false);
            SmokeTime = 0;
            //Smoke.transform.localScale = new Vector3(1, 1, 1);
            Main.Phase = 2;

        }
        //Debug.Log(Smoke.color.a);
    }
}
