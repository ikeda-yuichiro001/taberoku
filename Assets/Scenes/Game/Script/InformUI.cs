using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformUI : MonoBehaviour
{
    float SmokeTime;
    bool UIset1, UIset2;
    public GameObject InformBoxs;
    public GameObject newInformBoxs;
    public GameObject DiceNum;
    //RawImage Smoke;
    public Texture[] images;
    bool start;
    static public int a;
    void Start()
    {
    }
    public void Inform()
    {
        if (!UIset1)
        {
            SE.AUDIO.PlayOneShot(SE.CRIP[6]);
            //Smoke.color = new Color(1, 1, 1, 0);
            InformBoxs.SetActive(true);
            newInformBoxs.SetActive(true);
            UIset1 = true;

            InformBoxs.GetComponent<RawImage>().texture = images[(OPTION.menberLen-1) - Player.Num];
            newInformBoxs.GetComponent<RawImage>().texture = images[Player.Num];
            InformBoxs.GetComponent<RawImage>().color = Color.clear;
            newInformBoxs.GetComponent<RawImage>().color = Color.clear;
        }

        SmokeTime += Time.deltaTime;

        if (SmokeTime < 4)
        {
            InformBoxs.GetComponent<RawImage>().color += Color.white * Time.deltaTime / 4;
        }
        else if (SmokeTime < 8)
        {
            InformBoxs.GetComponent<RawImage>().color -= Color.white * Time.deltaTime / 4;
            newInformBoxs.GetComponent<RawImage>().color += Color.white * Time.deltaTime / 4;
        }
        else if (SmokeTime < 9)
        {
            InformBoxs.GetComponent<RawImage>().color = Color.clear;
            newInformBoxs.GetComponent<RawImage>().color = Color.white;
        }
        else
        {
            newInformBoxs.GetComponent<RawImage>().color -= Color.white * Time.deltaTime * 2;
        }
        if (SmokeTime > 10)
        {

            InformBoxs.GetComponent<RawImage>().color =
                newInformBoxs.GetComponent<RawImage>().color = Color.clear;
            UIset1 = false;
            InformBoxs.SetActive(false);
            newInformBoxs.SetActive(false);
            SmokeTime = 0;
            //Smoke.transform.localScale = new Vector3(1, 1, 1);
            Main.Phase = 18;

        }
        //Debug.Log(Smoke.color.a);
    }
    public void InformNum()
    {
        if (!UIset2)
        {
            DiceNum.SetActive(true);
            UIset2 = true;
            DiceNum.GetComponent<Text>().text = a.ToString();
            DiceNum.GetComponent<Text>().color = Color.clear;
            SmokeTime = 0;
        }
        SmokeTime += Time.deltaTime;
        if (SmokeTime < 2)
        {
            DiceNum.GetComponent<Text>().color += Color.black * Time.deltaTime;
        }
        else if (SmokeTime < 3)
        {
            DiceNum.GetComponent<Text>().color = Color.black;
        }
        else if (SmokeTime < 5)
        {
            DiceNum.GetComponent<Text>().color -= Color.black * Time.deltaTime;
        }
        else if (SmokeTime < 6)
        {
            DiceNum.GetComponent<Text>().color = Color.clear;
            UIset2 = false;
            DiceNum.SetActive(false);
            SmokeTime = 0;
            Main.Phase = 4;
        }
    }
}
