using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fin : MonoBehaviour
{
    void Finish()
    {
        SE.AUDIO.PlayOneShot(SE.CRIP[0]);//�I�����ۂ����I��ǂ�
        //�Ȃ񂩕������o�Ă���
        //if (Input.GetKeyDown(KeyCode.Return))
            SceneManager.LoadScene("Result");//�X�e�[�W�J��
    }
}
