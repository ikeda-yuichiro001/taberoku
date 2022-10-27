using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    public static Color[] PlayerColor = new Color[]
    {
        new Color(1.0f, 0.0f, 0.0f, 0.4f),
        new Color(0.0f, 1.0f, 0.0f, 0.4f),
        new Color(0.0f, 0.0f, 1.0f, 0.4f),
        new Color(1.0f, 1.0f, 0.0f, 0.4f),
        new Color(1.0f, 0.0f, 1.0f, 0.4f),
        new Color(0.0f, 1.0f, 1.0f, 0.4f),
        new Color(1.0f, 1.0f, 1.0f, 0.4f),
        new Color(1.0f, 0.65f, 0.0f, 0.4f),
        new Color(0.5f, 0.0f, 0.5f, 0.4f),
        new Color(0.65f, 0.16f, 0.16f, 0.4f)
    } ;
    bool one;
    public GameObject panel;
    public GameObject Pre1, Pre1_I, Pre2, Pre3;
    public PlayerData[] playerDatas;
    public PlayerDataUI[] playerDataUIs;
    Vector3 vector1, vector2, vector3;
    void Start()
    {
        OPTION.Load();
        Pre1 = Resources.Load("Text") as GameObject;
        Pre1_I = Resources.Load("RawImage") as GameObject;
        Pre2 = Resources.Load("Color") as GameObject;
        Pre3 = Resources.Load("Object") as GameObject;
        //Instantiate(Pre1,new Vector3(0,0,0), Quaternion.identity);
        if (Pre1 == null) Debug.Log("Pre1‹ó‚Á‚Û");
        if (Pre2 == null) Debug.Log("Pre2‹ó‚Á‚Û");
        if (Pre3 == null) Debug.Log("Pre3‹ó‚Á‚Û");
        //playerDatas = new PlayerData[OPTION.menberLen];
        playerDataUIs = new PlayerDataUI[OPTION.menberLen];
        for (int a = 0; a < OPTION.menberLen; a++)
        {
            playerDataUIs[a] = new PlayerDataUI();
            playerDataUIs[a].NAMEImage = Instantiate(Pre1_I, new Vector3((a % 2 == 0) ? -300 : 80, 160 - (30 * a), 0), Quaternion.identity).GetComponent<RawImage>();
            playerDataUIs[a].NAMEImage.transform.SetParent(panel.transform, false);
            playerDataUIs[a].NAME = Instantiate(Pre1, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<Text>();//(a % 2 == 0) ? -300 : 85, 160 - (30 * a)
            playerDataUIs[a].NAME.transform.SetParent(playerDataUIs[a].NAMEImage.transform, false);
            playerDataUIs[a].COLOR = Instantiate(Pre2, new Vector3((a % 2 == 0) ? -180 : 200, 160 - (30 * a), 0), Quaternion.identity).GetComponent<Dropdown>();
            playerDataUIs[a].COLOR.transform.SetParent(panel.transform, false);
            playerDataUIs[a].OBJ = Instantiate(Pre3, new Vector3((a % 2 == 0) ? -80 : 300, 160 - (30 * a), 0), Quaternion.identity).GetComponent<Dropdown>();
            playerDataUIs[a].OBJ.transform.SetParent(panel.transform, false);
            playerDataUIs[a].NAME.text = playerDatas[a].name;
            playerDataUIs[a].NAMEImage.color = Color.clear;
            playerDataUIs[a].COLOR.value = playerDatas[a].color;
            playerDataUIs[a].OBJ.value = playerDatas[a].obj;
        }
    }
    void Update()
    {
        for(int a =0; a < OPTION.menberLen;a++)
        {
            playerDataUIs[a].NAMEImage.color = PlayerColor[playerDataUIs[a].COLOR.value];
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
                color = (byte)playerDataUIs[Save].COLOR.value,
                shape = (byte)playerDataUIs[Save].OBJ.value,
                name = playerDataUIs[Save].NAME.text
            });
        }
        DATA_.userData.Save();
        print("ZeroSave");
        SceneLoader.Load("Game");
    }
    public void OnClick1()
    {
        SceneLoader.Load("Title");
    }

    [System.Serializable]
    public class PlayerDataUI
    {
        public Text NAME;
        public RawImage NAMEImage;
        public Dropdown COLOR, OBJ;
    }


    [System.Serializable]
    public class PlayerData
    {
        public string name;
        public int color, obj;
    }
}
