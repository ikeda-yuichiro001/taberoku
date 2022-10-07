using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdminToolUIManager : MonoBehaviour
{
    public InputField Prefab;
    public GameObject panel, DestroyOBJ;
    public int Number;
    static public int QNum;
    void Start()
    {
        DATA_.questionData.Load();
        Number = QNum;
        QGeneration();
        Destroy(DestroyOBJ);
    }
    void QGeneration()
    {
        InputField[] Q = new InputField[QNum];
        for (int a = 0; a < QNum; a++)
        {
            Q[QNum] = Instantiate(Prefab, new Vector3(-10, 100 - (80 * a), 0), Quaternion.identity);
            Q[QNum].transform.SetParent(this.panel.transform, false);
        }
    }
    void Update()
    {
        QGeneration();
        //Debug.Log(QNum);
    }
}
