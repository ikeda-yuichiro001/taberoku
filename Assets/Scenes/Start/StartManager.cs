using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    //public InputField Prefab;
    //public Dropdown Prefab2, Prefab3;
    public GameObject Prefab, panel, DestroyOBJ;//, DestroyOBJ2, DestroyOBJ3;
    //public static InputField[] PlayerName = new InputField[OPTION.menberLen];
    //public static Dropdown[] COLOE = new Dropdown[OPTION.menberLen];
    //public static Dropdown[] OBJ = new Dropdown[OPTION.menberLen];
    public static GameObject[] BOX = new GameObject[OPTION.menberLen];
    Text[] NameNum = new Text[OPTION.menberLen];
    Text[] Name = new Text[OPTION.menberLen];
    //Text[] PlayerNametext = new Text[OPTION.menberLen];
    //string[] PlayerNamestr = new string[OPTION.menberLen];
    //public static string strOfPlayerNameForTest;

    void Start()
    {
        for (int a = 0; a < BOX.Length; a++)
        {
            NameNum[a] = GameObject.Find("Canvas/BOX/Name/Num").GetComponent<Text>();
            NameNum[a].text = "É`Å[ÉÄ" + (a + 1);
            if (a % 2 == 0)
            {
                BOX[a] = Instantiate(Prefab, new Vector3(-235, 205 - (35 * (a + 1)), 0), Quaternion.identity);
                BOX[a].transform.SetParent(panel.transform, false);
                /*COLOE[a] = Instantiate(Prefab2, new Vector3(-200, 205 - (35 * (a + 1)), 0), Quaternion.identity);
                COLOE[a].transform.SetParent(panel.transform, false);
                OBJ[a] = Instantiate(Prefab3, new Vector3(-200, 205 - (35 * (a + 1)), 0), Quaternion.identity);
                OBJ[a].transform.SetParent(panel.transform, false);*/
            }
            if (a % 2 == 1)
            {
                BOX[a] = Instantiate(Prefab, new Vector3(160, 205 - (35 * (a)), 0), Quaternion.identity);
                BOX[a].transform.SetParent(panel.transform, false);
                /*COLOE[a] = Instantiate(Prefab2, new Vector3(200, 205 - (35 * (a)), 0), Quaternion.identity);
                COLOE[a].transform.SetParent(panel.transform, false);
                OBJ[a] = Instantiate(Prefab3, new Vector3(200, 205 - (35 * (a)), 0), Quaternion.identity);
                OBJ[a].transform.SetParent(panel.transform, false);*/
            }
        }
        Destroy(DestroyOBJ);
        //Destroy(DestroyOBJ2);
        //Destroy(DestroyOBJ3);
    }
}
