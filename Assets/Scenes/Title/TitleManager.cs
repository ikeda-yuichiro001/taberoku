using UnityEngine;

public class TitleManager : MonoBehaviour
{
    void Start()
    {
        VoiceRec.INIT(Recv, new string[]{ "げーむをはじめる","おぷしょん", "あぷしょん", "おぷそん", "あぷそん" });
    }
    void Recv( string a)
    {
        if (SceneLoader.IsFade) return;
        if (a == "げーむをはじめる") SceneLoader.Load("Description");
        else SceneLoader.Load("Setting");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) SceneLoader.Load("Description");
    }
}
