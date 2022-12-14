using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    public AudioSource SE;
    public AudioClip[] clips;
    public static Color[] PlayerColor = new Color[]
    {
        new Color(1.0f, 0.65f, 0.0f),// 0.4f),
        new Color(0.5f, 0.0f, 0.5f),// 0.4f),
        new Color(0.0f, 1.0f, 0.0f),// 0.4f),
        new Color(1.0f, 1.0f, 1.0f),// 0.4f),
        new Color(1.0f, 0.0f, 0.0f),// 0.4f),
        new Color(1.0f, 1.0f, 0.0f),// 0.4f),
        new Color(0.65f, 0.16f, 0.16f),// 0.4f),
        new Color(1.0f, 0.0f, 1.0f),// 0.4f),
        new Color(0.78f, 0.08f, 0.52f)//, 0.4f)
    } ;
    bool one;
    public GameObject panel;
    public GameObject Pre1, Pre1_I,  Pre3;//Pre2,
    public PlayerData[] playerDatas;
    public PlayerDataUI[] playerDataUIs;
    Vector3 vector1, vector2, vector3;
    void Start()
    {
        OPTION.Load();
        Pre1 = Resources.Load("Text") as GameObject;
        Pre1_I = Resources.Load("RawImage") as GameObject;
        //Pre2 = Resources.Load("Color") as GameObject;
        Pre3 = Resources.Load("Object") as GameObject;
        //Instantiate(Pre1,new Vector3(0,0,0), Quaternion.identity);
        if (Pre1 == null) Debug.Log("Pre1??????");
        //if (Pre2 == null) Debug.Log("Pre2??????");
        if (Pre3 == null) Debug.Log("Pre3??????");
        //playerDatas = new PlayerData[OPTION.menberLen];
        playerDataUIs = new PlayerDataUI[OPTION.menberLen];
        for (int a = 0; a < OPTION.menberLen; a++)
        {
            playerDataUIs[a] = new PlayerDataUI();
            playerDataUIs[a].NAMEImage = Instantiate(Pre1_I, new Vector3((a % 2 == 0) ? -280 : 100, 160 - (30 * a), 0), Quaternion.identity).GetComponent<RawImage>();
            playerDataUIs[a].NAMEImage.transform.SetParent(panel.transform, false);
            playerDataUIs[a].NAME = Instantiate(Pre1, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<Text>();//(a % 2 == 0) ? -300 : 85, 160 - (30 * a)
            playerDataUIs[a].NAME.transform.SetParent(playerDataUIs[a].NAMEImage.transform, false);
            //playerDataUIs[a].COLOR = Instantiate(Pre2, new Vector3((a % 2 == 0) ? -180 : 200, 160 - (30 * a), 0), Quaternion.identity).GetComponent<Dropdown>();
            //playerDataUIs[a].COLOR.transform.SetParent(panel.transform, false);
            playerDataUIs[a].OBJ = Instantiate(Pre3, new Vector3((a % 2 == 0) ? -100 : 280, 160 - (30 * a), 0), Quaternion.identity).GetComponent<Dropdown>();
            playerDataUIs[a].OBJ.transform.SetParent(panel.transform, false);
            playerDataUIs[a].NAME.text = playerDatas[a].name;
            playerDataUIs[a].NAMEImage.color = Color.clear;
            playerDataUIs[a].OBJ.value = playerDatas[a].color;
            playerDataUIs[a].OBJ.value = playerDatas[a].obj;
            playerDataUIs[a].OBJ.onValueChanged.AddListener(delegate { PlaySE(); });
            playerDataUIs[a].OBJ.onValueChanged.AddListener(delegate { PlaySE(); });
        }
    }
    void Update()
    {
        for(int a =0; a < OPTION.menberLen;a++)
        {
            playerDataUIs[a].NAMEImage.color = PlayerColor[playerDataUIs[a].OBJ.value];
            playerDataUIs[a].NAME.text = playerDatas[playerDataUIs[a].OBJ.value].name;
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
                color = (byte)playerDataUIs[Save].OBJ.value,
                shape = (byte)playerDataUIs[Save].OBJ.value,
                name = playerDataUIs[Save].NAME.text
            });
        }
        DATA_.userData.Save();
        print("ZeroSave");
        SE.PlayOneShot(clips[0]);
        SceneLoader.Load("Game");
    }
    public void OnClick1()
    {
        SE.PlayOneShot(clips[0]);
        SceneLoader.Load("Title");
    }

    void PlaySE()
    {
        SE.PlayOneShot(clips[1]);
    }

    [System.Serializable]
    public class PlayerDataUI
    {
        public Text NAME;
        public RawImage NAMEImage;
        public Dropdown OBJ;//COLOR,
    }


    [System.Serializable]
    public class PlayerData
    {
        public string name;
        public int color, obj;
    }
}
