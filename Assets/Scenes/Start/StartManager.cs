using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    public InputField Prefab;
    public GameObject panel , DestroyOBJ;
    InputField[] PlayerName = new InputField[OPTION.menberLen];
    Text[] NameNum = new Text[OPTION.menberLen];
    //Text[] PlayerNametext = new Text[OPTION.menberLen];
    //string[] PlayerNamestr = new string[OPTION.menberLen];
    //public static string strOfPlayerNameForTest;

    void Start()
    {
        for (int a = 0; a < PlayerName.Length; a++)
        {
            NameNum[a] = GameObject.Find("Canvas/Name/Num").GetComponent<Text>();
            NameNum[a].text = "É`Å[ÉÄ" + (a + 1);
            if (a % 2 == 0)
            {
                PlayerName[a] = Instantiate(Prefab, new Vector3(-200, 205 - (35 * (a + 1)), 0), Quaternion.identity);
                PlayerName[a].transform.SetParent(panel.transform, false);
            }
            if (a % 2 == 1)
            {
                PlayerName[a] = Instantiate(Prefab, new Vector3(200, 205 - (35 * (a)), 0), Quaternion.identity);
                PlayerName[a].transform.SetParent(panel.transform, false);
            }
        }
        Destroy(DestroyOBJ);
    }
    void Update()
    {
        
    }
}
