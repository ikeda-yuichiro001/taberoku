using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public AudioSource SE;
    void Start()
    {
        VoiceRec.INIT(Recv, new string[]{ "Ç∞Å[ÇﬁÇ®ÇÕÇ∂ÇﬂÇÈ","Ç®Ç’ÇµÇÂÇÒ", "Ç†Ç’ÇµÇÂÇÒ", "Ç®Ç’ÇªÇÒ", "Ç†Ç’ÇªÇÒ" });
    }
    void Recv( string a)
    {
        if (SceneLoader.IsFade) return;
        if (a == "Ç∞Å[ÇﬁÇ®ÇÕÇ∂ÇﬂÇÈ")
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
