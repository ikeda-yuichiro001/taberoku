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
        switch (Phase)
        {
            case 0://�X�e�[�W&�v���C���[�̐���
                targetObj[0].SendMessage("StageCreate");
                Phase++;
                break;
            case 1://�v���C���[�̍s��(�ʒu���݂�)
                targetObj[0].SendMessage("MoveCam");
                //targetObj[3].SendMessage("DiceDestroy");
                if (Player.goal<OPTION.menberLen)
                {
                    targetObj[1].SendMessage("PlayerPosition");
                    //�S�[�����Ă��Ȃ��l��������Phase++;
                }
                else if(Player.goal == OPTION.menberLen)
                {
                    Phase = 8;//�S�����S�[��������
                    print("�v���C���[�S�����S�[������ZOI!");
                }
                break;
            case 2://�v���C���[�̍s��(�T�C�R����U��)
                targetObj[3].SendMessage("DiceThrow");
                break;
            case 3: //�T�C�R���̖ڂ̊m�F
                print("�T�C�R���̖ڂ̊m�F");
                break;
            case 4: //�v���C���[�̍s��(�R�}�̈ړ�)
                targetObj[1].SendMessage("PlayerMove");
                break;
            case 5://�~�܂����}�X�̏���
                targetObj[2].SendMessage("GridProcessing");
                //print("Phase 5�_���[��");
                break;
            case 6://�~�܂����}�X�̌��ʂ̏���
                targetObj[2].SendMessage("MINIGame");
                //print("Phase 6�_���[��");
                //Phase++;
                break;
            case 7://���̐l�ɉ�
                targetObj[1].SendMessage("PlayerPass");
                //print("Phase 7�_���[��");
                break;
            case 8:
                //�S�[���̏���
                print("�I���I");
                break;
            default:
                print("Oops,I did it!");
                break;
        }
    }
}
