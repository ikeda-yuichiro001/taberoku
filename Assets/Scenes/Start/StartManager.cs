using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    public GameObject panel;
    public Text Pre1;
    public Dropdown Pre2, Pre3;
    public PlayerData[] playerDatas;
    public PlayerDataUI[] playerDataUIs;
    Vector3 vector1, vector2, vector3;
    void Start()
    {
        OPTION.Load();
        //playerDatas = new PlayerData[OPTION.menberLen];
        playerDataUIs = new PlayerDataUI[OPTION.menberLen];
        for (int a = 0; a < OPTION.menberLen; a++)
        {
            playerDataUIs[a].NAME = Instantiate(Pre1, new Vector3((a % 2 == 0) ? -300:85, 160 - (30 * a), 0), Quaternion.identity);
            playerDataUIs[a].NAME.transform.SetParent(panel.transform, false);
            playerDataUIs[a].COLOR = Instantiate(Pre2, new Vector3((a % 2 == 0) ? -190:190, 160 - (30 * a), 0), Quaternion.identity);
            playerDataUIs[a].OBJ = Instantiate(Pre3, new Vector3((a % 2 == 0) ? -85:300, 160 - (30 * a), 0), Quaternion.identity);
            playerDataUIs[a].NAME.text = playerDatas[a].name;
            playerDataUIs[a].COLOR.value = playerDatas[a].color;
            playerDataUIs[a].OBJ.value = playerDatas[a].obj;
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
    public class PlayerData
    {
        public string name;
        public int color, obj;
    }

    [System.Serializable]
    public class PlayerDataUI
    {
        public Text NAME;
        public Dropdown COLOR, OBJ;
    }
}
