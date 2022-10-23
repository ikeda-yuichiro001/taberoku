using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveManager : MonoBehaviour
{
    public GameObject RTile;
    public Dropdown Rnum;
    private int Rcount;
    public void Decision()
    {
        DATA_.questionData.Load();
        Rcount = Rnum.value;
        DATA_.questionData.data.RemoveAt(Rcount);
        DATA_.questionData.Save();
        RTile.SetActive(false);
    }
    public void Return()
    {
        DATA_.questionData.Save();
        RTile.SetActive(false);
    }
}
