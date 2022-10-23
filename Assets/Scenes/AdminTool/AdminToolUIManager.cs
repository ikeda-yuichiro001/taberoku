using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdminToolUIManager : MonoBehaviour
{
    public InputField Prefab;
    public static InputField InputQ;
    public GameObject TextFab; 
    GameObject[] Q;
    public GameObject panel;
    public GameObject canvas;
    public int Number;
    static public int MAXNum = 30;
    static public int QNum;
    void Start()
    {
        DATA_.questionData.Load();
        Q = new GameObject[MAXNum];
        for(int t = 0; t < MAXNum; t++)
        {
            Q[Number] = Instantiate(TextFab, new Vector3(-10, 1200 - (80 * t), 0), Quaternion.identity);
            Q[Number].transform.SetParent(this.panel.transform, false);
        }
        //QGeneration();
    }
    public void QGeneration()
    {
        Number = QNum;
    }
    public void AddQ()
    {
        InputQ = Instantiate(Prefab, new Vector3(-10, 100 - (80 * Number), 0), Quaternion.identity);
        InputQ.transform.SetParent(this.canvas.transform, false);
        //DATA_.questionData.data.Add(new Question { text = Q[Number].text, answer = ANSWER.YES });
        //DATA_.questionData.Save();
    }
    void Update()
    {
        Debug.Log(QNum);
    }
}
