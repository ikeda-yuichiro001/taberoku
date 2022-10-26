using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    bool cheac;
    //public InputField Prefab;
    public Dropdown Prefab2, Prefab3;
    public GameObject panel; 
    //public static InputField[] NAME;
    public Dropdown[] COLOE;
    public Dropdown[] OBJ;
    //Text[] NameNum = new Text[OPTION.menberLen];
    //Text[] Name = new Text[OPTION.menberLen];

    void Start()
    {
        OPTION.Load();
        //NAME = new InputField[OPTION.menberLen];
        COLOE = new Dropdown[OPTION.menberLen];
        OBJ = new Dropdown[OPTION.menberLen];
        for (int a = 0; a < OPTION.menberLen; a++)
        {
            //NameNum[a] = GameObject.Find("Canvas/Name/Num").GetComponent<Text>();
            //NameNum[a].text = "É`Å[ÉÄ" + (a + 1);
            if (a % 2 == 0)
            {
                //NAME[a] = Instantiate(Prefab, new Vector3(-210, 205 - (35 * (a + 1)), 0), Quaternion.identity);
                //NAME[a].transform.SetParent(panel.transform, false);
                COLOE[a] = Instantiate(Prefab2, new Vector3(-90, 205 - (35 * (a + 1)), 0), Quaternion.identity);
                COLOE[a].transform.SetParent(panel.transform, false);
                OBJ[a] = Instantiate(Prefab3, new Vector3(-25, 205 - (35 * (a + 1)), 0), Quaternion.identity);
                OBJ[a].transform.SetParent(panel.transform, false);
            }
            if (a % 2 == 1)
            {
                //NAME[a] = Instantiate(Prefab, new Vector3(135, 205 - (35 * (a + 1)), 0), Quaternion.identity);
                //NAME[a].transform.SetParent(panel.transform, false);
                COLOE[a] = Instantiate(Prefab2, new Vector3(255, 205 - (35 * (a + 1)), 0), Quaternion.identity);
                COLOE[a].transform.SetParent(panel.transform, false);
                OBJ[a] = Instantiate(Prefab3, new Vector3(320, 205 - (35 * (a + 1)), 0), Quaternion.identity);
                OBJ[a].transform.SetParent(panel.transform, false);
            }
        }
    }
    void Update()
    {
        if(!cheac)
        {
            for(int A = 0; A < OPTION.menberLen; A++)
            {
                COLOE[A].value = A;
                OBJ[A].value = Random.Range(0, 6);
            }
            cheac = true;
        }
    }

    public void OnClick0()
    {
        DATA_.userData.Load();
        for (int Save = 0; Save < OPTION.menberLen; Save++)
        {
            DATA_.userData.data.Add(new User()
            {
                id = (uint)Save,
                color = (byte)COLOE[Save].value,
                shape = (byte)OBJ[Save].value,
                //name = StartManager.NAME[Save].text
            });
        }
        DATA_.userData.Save();
        print("ZeroSave");
        cheac = false;
        SceneLoader.Load("Game");
    }
    public void OnClick1() { cheac = false; SceneLoader.Load("Title"); }
}
