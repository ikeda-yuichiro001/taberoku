using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    int Phase;
    void Start()
    {
        Phase = 0;
    }
    
    void Update()
    {
        switch(Phase)
        {
            case 0:
                //�X�e�[�W&�v���C���[�̐���
                Phase++;
                break;
            case 1:
                //�v���C���[�̍s��(�T�C�R����U��)
                //�S�[�����Ă��Ȃ��l��������Phese++;
                //���Ȃ�������Phese = 5;
                Phase++;
                break;
            case 2:
                //�v���C���[�̍s��(�R�}�̈ړ�)
                break;
            case 3:
                //�~�܂����}�X�̏���
                //if()(�}�X�Ɍ��ʂ��Ȃ�������)Phese--;
                //else(�Ȃ�������)Phese++;
                break;
            case 4:
                //�~�܂����}�X�̌��ʂ̏���
                Phase = 2;
                break;
            case 5:
                //�S�[���̏���
                break;
            default:
                print("Oops,I did it!");
                break;
        }
    }
}
