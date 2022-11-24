using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUIManager : MonoBehaviour
{
    public AudioSource SE;
    public Text Winner;
    public Text Prename;
    public Image Precolor;
    //public RESULT[] ResultData;
    public GameObject Boxed;
    void Start()
    {
        DATA_.winner.Load();
        Winner.text = DATA_.userData.data[Player.GG].name;
        /*
        Prename = Resources.Load("Text") as Text;
        Precolor = Resources.Load("Image") as Image;
        ResultData = new RESULT[OPTION.menberLen];
        for (int a = 0; a < OPTION.menberLen; a++)
        {
            ResultData[a].BackColor = Instantiate(Precolor, new Vector3(0, 0, 0), Quaternion.identity);
            ResultData[a].BackColor.transform.SetParent(Boxed.transform, false);
            ResultData[a].NAME = Instantiate(Prename, new Vector3(0, 0, 0), Quaternion.identity);
            ResultData[a].NAME.transform.SetParent(ResultData[a].BackColor.transform, false);
        }
        */
        VoiceRec.INIT(Recv, new string[] { "‚¨‚í‚é", "‚¨‚í‚è", "‚µ‚ã‚¤‚è‚å‚¤","‚½‚¢‚Æ‚é‚Ö", "‚½‚¢‚Æ‚é‚¦" });
    }
    void Recv(string a)
    {
        if (SceneLoader.IsFade) return;
        if (a == "‚¨‚í‚é")
        {
            SceneLoader.Load("Title");
            SE.PlayOneShot(SE.clip);
        }
        else
        {
            SceneLoader.Load("Title");
            SE.PlayOneShot(SE.clip);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneLoader.Load("Title");
            SE.PlayOneShot(SE.clip);
        }
    }
}

[System.Serializable]
public class RESULT
{
    public Image BackColor;
    public Text NAME;
}