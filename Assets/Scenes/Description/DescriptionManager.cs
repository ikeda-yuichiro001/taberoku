using UnityEngine;
using UnityEngine.UI;

public class DescriptionManager : MonoBehaviour
{
    public int next;
    public RawImage[] images;
    void Start()
    {
        VoiceRec.INIT(Recv, new string[] { "����", "����", "�Ƃ�����", "�Ƃ�����" });
    }
    void Recv(string a)
    {
        if (SceneLoader.IsFade) return;
        if (a == "����")
        {
            next++;
            if(next >= images.Length)SceneLoader.Load("Start");
        }
        if (a == "����")
        {
            next++;
            if (next >= images.Length) SceneLoader.Load("Start");
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) SceneLoader.Load("Start");
        for(int a = 0;a<images.Length - 1;)
        {
            if (a < next)
            {
                a++;
                images[next].color -= new Color(0, 0, 0, Time.deltaTime);
            }
        }
    }
}
