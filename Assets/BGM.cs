using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM : MonoBehaviour
{
    public AudioSource bgm;
    void Start()
    {
        OPTION.Load();
        bgm.volume = 0;
    }
    void Update()
    {
        if(bgm.volume < OPTION.bgm)
        {
            bgm.volume += OPTION.bgm/10;
        }
    }
}
