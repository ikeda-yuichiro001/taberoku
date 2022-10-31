using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public AudioSource SE;
    void Start()
    {
        VoiceRec.INIT(Recv, new string[]{ "���[�ނ��͂��߂�","���Ղ����" });
    }
    void Recv( string a)
    {
        if (SceneLoader.IsFade) return;
        if (a == "���[�ނ��͂��߂�" && Input.GetKey(KeyCode.Space))
        {
            SceneLoader.Load("Description");
            SE.PlayOneShot(SE.clip);
        }
        if(a == "���Ղ����" && Input.GetKey(KeyCode.Space))
        {
            SceneLoader.Load("Setting");
            SE.PlayOneShot(SE.clip);
        }
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A))
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
