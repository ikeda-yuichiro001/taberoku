using UnityEngine;

public class SettingSceneManager : MonoBehaviour
{
    public AudioSource SE;
    public AudioClip[] clips;
    public void OnClick0() { SE.PlayOneShot(clips[0]); OPTION.Save(); SceneLoader.Load("AdminTool"); }
    public void OnClick1() { SE.PlayOneShot(clips[0]); OPTION.Save(); SceneLoader.Load("Title"); }
    public void Nup()   { SE.PlayOneShot(clips[1]); if (OPTION.menberLen < 10)  OPTION.menberLen++; }
    public void Ndown() { SE.PlayOneShot(clips[1]); if (OPTION.menberLen > 1)  OPTION.menberLen--; }
    public void Lup()   { SE.PlayOneShot(clips[1]); if (OPTION.time < 90)      OPTION.time += 5; }
    public void Ldown() { SE.PlayOneShot(clips[1]); if (OPTION.time > 10)      OPTION.time -= 5; }
    public void Rup()   { SE.PlayOneShot(clips[1]); if (OPTION.response < 300) OPTION.response += 10; }
    public void Rdown() { SE.PlayOneShot(clips[1]); if (OPTION.response > 30)  OPTION.response -= 10; }
    public void Bup()   { SE.PlayOneShot(clips[1]); if (OPTION.bgm < 0.1)      OPTION.bgm += 0.01f; }
    public void Bdown() { SE.PlayOneShot(clips[1]); if (OPTION.bgm > 0)        OPTION.bgm -= 0.01f; }
    public void Sup()   { SE.PlayOneShot(clips[1]); if (OPTION.se < 0.1)       OPTION.se += 0.01f; }
    public void Sdown() { SE.PlayOneShot(clips[1]); if (OPTION.se > 0)         OPTION.se -= 0.01f; }
}
