using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    public void OnClick0()
    {
        DATA_.userData.Load();
        for (int Save = 0; Save < OPTION.menberLen; Save++)
        {
            DATA_.userData.data.Add(new User() { id = (uint)Save,
                color = (byte)StartManager.COLOE[Save].value,
                shape = (byte)StartManager.OBJ[Save].value,
                name = StartManager.NAME[Save].text });
        }
        DATA_.userData.Save();
        print("ZeroSave");
        SceneManager.LoadScene("Game");
    }
    public void OnClick1() { SceneManager.LoadScene("Title");}
}
