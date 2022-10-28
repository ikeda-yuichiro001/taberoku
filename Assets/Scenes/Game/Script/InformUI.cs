using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformUI : MonoBehaviour
{
    float SmokeTime;
    bool UIset;
    public GameObject InformBoxs;
    public RawImage Smoke;
    public Texture[] images;
    void Start()
    {
    }
    public void Inform()
    {
        if (!UIset)
        {
            SE.AUDIO.PlayOneShot(SE.CRIP[6]);
            Smoke.color = new Color(1, 1, 1, 0);
            InformBoxs.SetActive(true);
            UIset = true;
        }
        SmokeTime += Time.deltaTime;
        if (SmokeTime < 2.5f)
        {
            if(Player.Num - 1 < 0)
            {
                InformBoxs.GetComponent<RawImage>().texture = images[images.Length - 1];
            }
            else
            {

                InformBoxs.GetComponent<RawImage>().texture = images[Player.Num - 1];
            }
            Smoke.transform.localScale += new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
            if(Smoke.color.a < 1.0f) Smoke.color += new Color(0, 0, 0, Time.deltaTime);
        }
        else
        {
            Smoke.transform.localScale += new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
            InformBoxs.GetComponent<RawImage>().texture = images[Player.Num];
            Smoke.color -= new Color(0, 0, 0, Time.deltaTime);
        }
        if(SmokeTime > 5)
        {
            UIset = false;
            InformBoxs.SetActive(false);
            SmokeTime = 0;
            Smoke.transform.localScale = new Vector3(1, 1, 1);
            Main.Phase = 2;
        }
        //Debug.Log(Smoke.color.a);
    }
}
