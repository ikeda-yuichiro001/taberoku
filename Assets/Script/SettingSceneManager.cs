using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingSceneManager : MonoBehaviour
{
    public void OnClick0() { SceneManager.LoadScene("AdminTool"); }
    public void OnClick1() { SceneManager.LoadScene("Title"); }
    public void Nup() { if (SettingSceneUIManager.n < 9) SettingSceneUIManager.n++; }
    public void Ndown() { if (SettingSceneUIManager.n > 1) SettingSceneUIManager.n--; }
    public void Lup() { if (SettingSceneUIManager.l < 90) SettingSceneUIManager.l += 5; }
    public void Ldown() { if (SettingSceneUIManager.l > 10) SettingSceneUIManager.l -= 5; }
    public void Rup() { if (SettingSceneUIManager.r < 300) SettingSceneUIManager.r += 10; }
    public void Rdown() { if (SettingSceneUIManager.r > 30) SettingSceneUIManager.r -= 10; }
    public void Bup() { if (SettingSceneUIManager.b < 100) SettingSceneUIManager.b += 10; }
    public void Bdown() { if (SettingSceneUIManager.b > 0) SettingSceneUIManager.b -= 10; }
    public void Sup() { if (SettingSceneUIManager.s < 100) SettingSceneUIManager.s += 10; }
    public void Sdown() { if (SettingSceneUIManager.s > 0) SettingSceneUIManager.s -= 10; }
}
