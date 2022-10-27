using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public AudioSource SE;
    void Start()
    {
        VoiceRec.INIT(Recv, new string[]{ "げーむおはじめる","おぷしょん", "あぷしょん", "おぷそん", "あぷそん" });
    }
    void Recv( string a)
    {
        if (SceneLoader.IsFade) return;
        if (a == "げーむおはじめる")
        {
            SceneLoader.Load("Description");
            SE.PlayOneShot(SE.clip);
        }
        else
        {
            SceneLoader.Load("Setting");
            SE.PlayOneShot(SE.clip);
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneLoader.Load("Description");
            SE.PlayOneShot(SE.clip);
        }
    }
}
