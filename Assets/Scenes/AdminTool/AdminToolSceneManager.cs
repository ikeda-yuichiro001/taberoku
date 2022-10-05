using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdminToolSceneManager : MonoBehaviour
{
    public void OnClick0() { if (AdminToolUIManager.QNum > 0) AdminToolUIManager.QNum++; }//DATA_.questionData.data.Add(new Question() { text = "‚±‚±‚É–â‘è•¶", answer = ANSWER.NO }); }
    public void OnClick1() { if (AdminToolUIManager.QNum < 30) AdminToolUIManager.QNum--; }//DATA_.questionData.data.Remove(new Question() { text = "‚±‚±‚É–â‘è•¶", answer = ANSWER.NO }); }
    public void OnClick2() {  DATA_.questionData.Save(); SceneManager.LoadScene("Title"); }
}
