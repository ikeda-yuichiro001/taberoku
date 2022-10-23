using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdminToolSceneManager : MonoBehaviour
{
    public GameObject QTile,RemoveQ;
    void Start()
    {
        QTile.SetActive(false);
        RemoveQ.SetActive(false);
    }
    public void OnClick0()
    {
        if (AdminToolUIManager.QNum < AdminToolUIManager.MAXNum) AdminToolUIManager.QNum++;
        QTile.SetActive(true);
    }//DATA_.questionData.data.Add(new Question() { text = "‚±‚±‚É–â‘è•¶", answer = ANSWER.NO }); }
    public void OnClick1()
    {
        if (AdminToolUIManager.QNum > 0) AdminToolUIManager.QNum--;
        RemoveQ.SetActive(true);
    }
    public void OnClick2()
    {
        DATA_.questionData.Save();
        SceneManager.LoadScene("Title");
    }
}
