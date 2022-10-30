using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThinWallsManager : MonoBehaviour
{
    public GameObject QTile;
    public InputField QQQ;
    public Dropdown YesOrNo;
    public GameObject error;
    private int Qcount;
    private float al;
    public void Decision()
    {
        DATA_.questionData.Load();
        error.SetActive(false);
        Qcount = DATA_.questionData.data.Count;
        if (Qcount < 30 && Qcount >= 0)
        {
            error.SetActive(false);
            if (YesOrNo.value == 0) DATA_.questionData.data.Add(new Question_ { text = QQQ.text, answer = ANSWER.YES });
            if (YesOrNo.value == 1) DATA_.questionData.data.Add(new Question_ { text = QQQ.text, answer = ANSWER.NO });
            AdminToolUIManager.texts[Qcount].text = DATA_.questionData.data[Qcount].text;
            DATA_.questionData.Save();
            QTile.SetActive(false);
        }
        else
        {
            DATA_.questionData.Save();
            error.SetActive(true);
        }
    }
    public void Return()
    {
        DATA_.questionData.Save();
        QTile.SetActive(false);
    }
}
