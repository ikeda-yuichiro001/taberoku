using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdminToolUIManager : MonoBehaviour
{
    public RawImage RawImage;
    public Text Text;
    RawImage[] rawImages;
    public static Text[] texts;
    public GameObject panel;
    public GameObject Error;
    public int Number;
    static public int MAXNum = 30;
    static public int QNum;
    void Start()
    {
        DATA_.questionData.Load();
        Error.SetActive(false);
        QNum = DATA_.questionData.data.Count;
        rawImages = new RawImage[MAXNum];
        texts = new Text[MAXNum];
        for (int t = 0; t < MAXNum; t++)
        {
            rawImages[Number] = Instantiate(RawImage, new Vector3(-10, 1200 - (80 * t), 0), Quaternion.identity);
            rawImages[Number].transform.SetParent(this.panel.transform, false);
            texts[Number] = Instantiate(Text, new Vector3(-10, 1200 - (80 * t), 0), Quaternion.identity);
            texts[Number].transform.SetParent(this.panel.transform, false);
            texts[Number].text = "–â‘è";
            texts[QNum].text = DATA_.questionData.data[QNum].text;//”z—ñ‚ÌŠO‚Éo‚é‚ç‚µ‚¢
        }
    }
    /*void Update()
    {
        QNum = DATA_.questionData.data.Count;
        for (int t = 0; t < QNum; t++)
        {
            //texts[QNum].text = DATA_.questionData.data[QNum].text;
        }
        //Debug.Log(QNum);
    }*/
}
