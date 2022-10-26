using UnityEngine;
using UnityEngine.UI;

public class DescriptionManager : MonoBehaviour
{
    public int next = 0;
    bool i;
    public RawImage[] images;
    void Start()
    {
        VoiceRec.INIT(Recv, new string[] { "‚Â‚¬‚Ö", "‚Â‚¬‚¦", "‚Æ‚£‚¬‚Ö", "‚Æ‚£‚¬‚¦" });
    }
    void Recv(string a)
    {
        if (SceneLoader.IsFade) return;
        if (a == "‚Â‚¬‚Ö")
        {
            if(next >= images.Length)SceneLoader.Load("Start");
            i = true;
        }
        if (a == "‚Â‚¬‚¦")
        {
            if (next >= images.Length) SceneLoader.Load("Start");
            i = true;
        }
    }
    void Update()
    {
        //if (Input.GetMouseButtonDown(0)) SceneLoader.Load("Start");
            if(i == true)
            {
                images[next].color -= new Color(0, 0, 0, Time.deltaTime);
                next++;
                i = false;
            }
    }
}
