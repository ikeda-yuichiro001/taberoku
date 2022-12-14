using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public AudioSource SE;
    void Start()
    {
        VoiceRec.INIT(Recv, new string[]{ "げーむおはじめる","おぷしょん" });
    }
    void Recv( string a)
    {
        if (SceneLoader.IsFade) return;
        if (a == "げーむおはじめる" && Input.GetKey(KeyCode.Space))
        {
            SceneLoader.Load("Description");
            SE.PlayOneShot(SE.clip);
        }
        if(a == "おぷしょん" && Input.GetKey(KeyCode.Space))
        {
            SceneLoader.Load("Setting");
            SE.PlayOneShot(SE.clip);
        }
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Return))
        {
            SceneLoader.Load("Description");
            SE.PlayOneShot(SE.clip);
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.S))
        {
            SceneLoader.Load("Setting");
            SE.PlayOneShot(SE.clip);
        }
    }
}
