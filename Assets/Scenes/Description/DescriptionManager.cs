using UnityEngine;
using UnityEngine.UI;

public class DescriptionManager : MonoBehaviour
{
    public AudioSource SE;
    public AudioClip[] clips;
    public int next;
    public RawImage[] images;
    void Start()
    {
        next = -1;
        VoiceRec.INIT(Recv, new string[] {"‚Â‚¬‚É‚·‚·‚Þ","‚±‚Ü‚¨‚«‚ß‚é"});
    }
    void Recv(string a)
    {
        if (SceneLoader.IsFade) return;
        if (a == "‚±‚Ü‚¨‚«‚ß‚é" && Input.GetKey(KeyCode.Space))
        {
            next = -1;
            SE.PlayOneShot(clips[0]);
            SceneLoader.Load("Start");
        }
        else if(a == "‚Â‚¬‚É‚·‚·‚Þ" && Input.GetKey(KeyCode.Space))
        {
            next++;
            SE.PlayOneShot(clips[1]);
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            next++;
            SE.PlayOneShot(clips[1]);
        }
        //if (Input.GetMouseButtonDown(0)) SceneLoader.Load("Start");
        switch (next)
        {
            case 0:
                images[0].color -= new Color(0, 0, 0, Time.deltaTime);
                break;
            case 1:
                images[1].color -= new Color(0, 0, 0, Time.deltaTime);
                break;
            /*case 2:
                images[2].color -= new Color(0, 0, 0, Time.deltaTime);
                break;*/
            case 2:
                next = -1;
                SE.PlayOneShot(clips[1]);
                SceneLoader.Load("Start");
                break;
            default:
                print("Oops,I did it!");
                break;
        }
    }
}
