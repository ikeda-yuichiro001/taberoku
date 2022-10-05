using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingSceneManager : MonoBehaviour
{
    public void OnClick0() { SceneManager.LoadScene("AdminTool"); OPTION.Save(); }
    public void OnClick1() { SceneManager.LoadScene("Title"); OPTION.Save(); }
    public void Nup()   { if (OPTION.menberLen < 10)  OPTION.menberLen++; }
    public void Ndown() { if (OPTION.menberLen > 1)  OPTION.menberLen--; }
    public void Lup()   { if (OPTION.time < 90)      OPTION.time += 5; }
    public void Ldown() { if (OPTION.time > 10)      OPTION.time -= 5; }
    public void Rup()   { if (OPTION.response < 300) OPTION.response += 10; }
    public void Rdown() { if (OPTION.response > 30)  OPTION.response -= 10; }
    public void Bup()   { if (OPTION.bgm < 0.1)      OPTION.bgm += 0.01f; }
    public void Bdown() { if (OPTION.bgm > 0)        OPTION.bgm -= 0.01f; }
    public void Sup()   { if (OPTION.se < 0.1)       OPTION.se += 0.01f; }
    public void Sdown() { if (OPTION.se > 0)         OPTION.se -= 0.01f; }
}
