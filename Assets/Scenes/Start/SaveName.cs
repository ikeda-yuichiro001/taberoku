using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveName : MonoBehaviour
{
    public InputField[] InputField = new InputField[OPTION.menberLen];
    public Dropdown[] ColorNum = new Dropdown[OPTION.menberLen];
    public Dropdown[] ObjNum = new Dropdown[OPTION.menberLen];
    void Start()
    {
        DATA_.userData.Load();
        for (int a = 0;a < InputField.Length; a++)
        {
            DATA_.userData.data.Add(new User() { id = (uint)a, color = 0, shape = 0, name = "チーム" + (a + 1)});
            //InputField[aa] = StartManager.PlayerName[aa];
            //ColorNum[aa] = StartManager.COLOE[aa];
            //ObjNum[aa] = StartManager.OBJ[aa];
        }
        DATA_.userData.data.Add(new User() { id = 0, color = 0, shape = 0, name = "チーム" + 0});
        DATA_.userData.Save();
        print("ZeroSave");
    }
    public void NameSave()
    {
        //DATA_.userData.Load();
        for(int N = 0; N < OPTION.menberLen; N++)
        {
            //DATA_.userData.
        }
        DATA_.userData.Save();
        print("Save name");
    }
    public void ChangeColor()
    {
        //DATA_.userData.Load();
        for (int C = 0; C < OPTION.menberLen; C++)
        {
            //if(ColorNum[C].onValueChanged ==  )
        }
        DATA_.userData.Save();
        print("Save color");
    }
    public void ChangeObject()
    {
        //DATA_.userData.Load();
        for (int O = 0; O < OPTION.menberLen; O++)
        {
            //if(InputField[N])
        }
        DATA_.userData.Save();
        print("Save object");
    }
}
