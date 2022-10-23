using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    public InputField Prefab;
    public Dropdown Prefab2, Prefab3;
    public GameObject panel, DestroyOBJ, DestroyOBJ2, DestroyOBJ3;
    public static InputField[] NAME;
    public static Dropdown[] COLOE;
    public static Dropdown[] OBJ;
    //public static GameObject[] BOX = new GameObject[OPTION.menberLen];
    Text[] NameNum = new Text[OPTION.menberLen];
    Text[] Name = new Text[OPTION.menberLen];

    void Start()
    {
        NAME = new InputField[OPTION.menberLen];
        COLOE = new Dropdown[OPTION.menberLen];
        OBJ = new Dropdown[OPTION.menberLen];
        for (int a = 0; a < OPTION.menberLen; a++)
        {
            NameNum[a] = GameObject.Find("Canvas/Name/Num").GetComponent<Text>();
            NameNum[a].text = "É`Å[ÉÄ" + (a + 1);
            /*if (a % 2 == 0)
            {
                NAME[a] = Instantiate(Prefab, new Vector3(-240, 205 - (35 * (a + 1)), 0), Quaternion.identity);
                NAME[a].transform.SetParent(panel.transform, false);
                COLOE[a] = Instantiate(Prefab2, new Vector3(-110, 205 - (35 * (a + 1)), 0), Quaternion.identity);
                COLOE[a].transform.SetParent(panel.transform, false);
                OBJ[a] = Instantiate(Prefab3, new Vector3(-35, 205 - (35 * (a + 1)), 0), Quaternion.identity);
                OBJ[a].transform.SetParent(panel.transform, false);
            }
            if (a % 2 == 1)
            {
                NAME[a] = Instantiate(Prefab, new Vector3(165, 205 - (35 * (a + 1)), 0), Quaternion.identity);
                NAME[a].transform.SetParent(panel.transform, false);
                COLOE[a] = Instantiate(Prefab2, new Vector3(290, 205 - (35 * (a + 1)), 0), Quaternion.identity);
                COLOE[a].transform.SetParent(panel.transform, false);
                OBJ[a] = Instantiate(Prefab3, new Vector3(365, 205 - (35 * (a + 1)), 0), Quaternion.identity);
                OBJ[a].transform.SetParent(panel.transform, false);
            }*/
            if (a % 2 == 0)
            {
                NAME[a] = Instantiate(Prefab, new Vector3(-210, 205 - (35 * (a + 1)), 0), Quaternion.identity);
                NAME[a].transform.SetParent(panel.transform, false);
                COLOE[a] = Instantiate(Prefab2, new Vector3(-90, 205 - (35 * (a + 1)), 0), Quaternion.identity);
                COLOE[a].transform.SetParent(panel.transform, false);
                OBJ[a] = Instantiate(Prefab3, new Vector3(-25, 205 - (35 * (a + 1)), 0), Quaternion.identity);
                OBJ[a].transform.SetParent(panel.transform, false);
            }
            if (a % 2 == 1)
            {
                NAME[a] = Instantiate(Prefab, new Vector3(135, 205 - (35 * (a + 1)), 0), Quaternion.identity);
                NAME[a].transform.SetParent(panel.transform, false);
                COLOE[a] = Instantiate(Prefab2, new Vector3(255, 205 - (35 * (a + 1)), 0), Quaternion.identity);
                COLOE[a].transform.SetParent(panel.transform, false);
                OBJ[a] = Instantiate(Prefab3, new Vector3(320, 205 - (35 * (a + 1)), 0), Quaternion.identity);
                OBJ[a].transform.SetParent(panel.transform, false);
            }
        }
        Destroy(DestroyOBJ);
        Destroy(DestroyOBJ2);
        Destroy(DestroyOBJ3);
    }
}
