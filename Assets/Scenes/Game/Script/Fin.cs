using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fin : MonoBehaviour
{
    public void Finish()
    {
        SE.AUDIO.PlayOneShot(SE.CRIP[5]);//�I�����ۂ����I��ǂ�
                                         //�Ȃ񂩕������o�Ă���
                                         //if (Input.GetKeyDown(KeyCode.Return))
        SceneLoader.Load("Result");//�X�e�[�W�J��
    }
}
