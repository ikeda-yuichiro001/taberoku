using UnityEngine;

public class TitleManager : MonoBehaviour
{
    void Start()
    {
        VoiceRec.INIT(Recv, new string[]{ "���[�ނ��͂��߂�","���Ղ����", "���Ղ����", "���Ղ���", "���Ղ���" });
    }
    void Recv( string a)
    {
        if (SceneLoader.IsFade) return;
        if (a == "���[�ނ��͂��߂�") SceneLoader.Load("Description");
        else SceneLoader.Load("Setting");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) SceneLoader.Load("Description");
    }
}
