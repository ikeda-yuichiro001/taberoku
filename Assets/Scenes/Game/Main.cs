using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static int Phase;
    public GameObject[] targetObj;
    void Start()
    {
        Phase = 0;
    }
    
    void Update()
    {
        switch(Phase)
        {
            case 0://�X�e�[�W&�v���C���[�̐���
                targetObj[0].SendMessage("StageCreate");
                Phase++;
                break;
            case 1://�v���C���[�̍s��(�ʒu���݂�)
                if (Player.goal<OPTION.menberLen)
                {
                    targetObj[1].SendMessage("PlayerPosition");
                    Phase++;//�S�[�����Ă��Ȃ��l��������
                }
                else if(Player.goal == OPTION.menberLen) Phase = 6;//�S�����S�[��������
                break;
            case 2://�v���C���[�̍s��(�T�C�R����U��)
                targetObj[1].SendMessage("PlayerRoll");
                break;
            case 3: //�v���C���[�̍s��(�R�}�̈ړ�)
                targetObj[1].SendMessage("PlayerMove");
                break;
            case 4://�~�܂����}�X�̏���
                //if()(�}�X�Ɍ��ʂ���������)Phase++; 
                Phase = 6;//else(�Ȃ�������)
                print("Phase 4�_���[��");
                break;
            case 5:
                //�~�܂����}�X�̌��ʂ̏���
                print("Phase 5�_���[��");
                Phase++;
                break;
            case 6://���̐l�ɉ�
                targetObj[1].SendMessage("PlayerPass");
                print("Phase 6�_���[��");
                break;
            case 7:
                //�S�[���̏���
                break;
            default:
                print("Oops,I did it!");
                break;
        }
    }
}
