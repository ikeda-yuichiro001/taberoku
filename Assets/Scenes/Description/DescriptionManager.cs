using UnityEngine;
using UnityEngine.UI;

public class DescriptionManager : MonoBehaviour
{
    public int next = -1;
    public RawImage[] images;
    void Start()
    {
        VoiceRec.INIT(Recv, new string[] { "‚Â‚¬‚Ö", "‚Â‚¬‚¦", "‚Â‚¬", "‚Â‚¬", "‚¬‚Ö", "‚¬‚¦" ,"‚Â‚¬‚É‚·‚·‚Þ","‚±‚Ü‚¨‚«‚ß‚é"});
    }
    void Recv(string a)
    {
        if (SceneLoader.IsFade) return;
        if (a == "‚±‚Ü‚¨‚«‚ß‚é")
        {
            next = -1;
            SceneLoader.Load("Start");
        }
        else
        {
            next++;
        }
    }
    void Update()
    {
        //if (Input.GetMouseButtonDown(0)) SceneLoader.Load("Start");
        switch(next)
        {
            case 0:
                images[next].color += new Color(0, 0, 0, Time.deltaTime);
                break;
            case 1:
                images[next].color += new Color(0, 0, 0, Time.deltaTime);
                break;
            case 2:
                images[next].color += new Color(0, 0, 0, Time.deltaTime);
                break;
            case 3:
                next = -1;
                SceneLoader.Load("Start");
                break;
            default:
                print("Oops,I did it!");
                break;
        }
    }
}
