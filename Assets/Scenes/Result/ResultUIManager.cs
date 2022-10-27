using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUIManager : MonoBehaviour
{
    public AudioSource SE;
    public Text Winner;
    public Text PastWinner;
    void Start()
    {
        DATA_.winner.Load();
        Winner.text = "aaaaa";
        VoiceRec.INIT(Recv, new string[] { "おわる", "おわり", "しゅうりょう","たいとるへ", "たいとるえ" });
    }
    void Recv(string a)
    {
        if (SceneLoader.IsFade) return;
        if (a == "おわる")
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
        if (Input.GetMouseButtonDown(0))
        {
            SceneLoader.Load("Title");
            SE.PlayOneShot(SE.clip);
        }
    }
}
