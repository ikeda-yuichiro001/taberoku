using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    float delay;
    public static int Phase;
    bool seflag;
    float cnt,cnt2;
    public RawImage seikai, huseikai;
    public GameObject[] targetObj;
    void Start()
    {
        Phase = 0;
        seikai.color = Color.clear;
        huseikai.color = Color.clear;
    }
    
    void Update()
    {
        targetObj[1].SendMessage("PlayerCircular");
        //print("Phase " + Phase + "�_���[��");
        switch (Phase)
        {
            case 0://�X�e�[�W&�v���C���[�̐���
                targetObj[0].SendMessage("StageCreate");
                Phase = 1;
                break;
            case 1://�v���C���[�̍s��(�ʒu���݂�)
                targetObj[0].SendMessage("MoveCam");//���_�ړ�
                targetObj[1].SendMessage("PlayerMove0");//��̈ʒu����
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
                Stage.evocation.SetActive(true);
                targetObj[4].SendMessage("Texts");
                break;
            case 3:
                Stage.evocation.SetActive(false);//�T�C�R���̖ڂ̊m�F
                //print("�T�C�R���̖ڂ̊m�F");
                break;
            case 4: //�v���C���[�̍s��(�R�}�̈ړ�)
                targetObj[0].SendMessage("MoveCam");//���_�ړ�
                targetObj[1].SendMessage("PlayerMove0");
                targetObj[1].SendMessage("PlayerMove1");
                break;
            case 5://�~�܂����}�X�̏���
                targetObj[2].SendMessage("GridProcessing");
                //print("Phase 5�_���[��");
                break;
            case 6://�~�܂����}�X�̌��ʂ̏���
                targetObj[2].SendMessage("Creating");
                //print("Phase 6�_���[��");
                //Phase++;
                break;
            case 7://���̐l�ɉ�
                delay += Time.deltaTime; 
                if(delay > 1.4f)
                {
                    targetObj[1].SendMessage("PlayerPass");
                    delay = 0;
                }

                //print("Phase 7�_���[��");
                break;
            case 8://�S�[���̏���
                targetObj[5].SendMessage("Finish");
                print("�I���I");
                break;
            case 9:
                if (!seflag)
                {
                    SE.AUDIO.PlayOneShot(SE.CRIP[3]);//����!!
                    seflag = true;
                }
                    cnt += Time.deltaTime * 10;
                    if (Mathf.Sin(cnt) > 0)
                    {
                        seikai.color = Color.red;
                    }
                    else
                    {
                        seikai.color = Color.clear;
                    }
                    if (cnt > 50)
                    {
                        cnt = 0;
                        seflag = false;
                        seikai.color = Color.clear;
                        Phase = 7;
                    }
                    
                
                break;
            case 10:
                if (!seflag)
                {
                    SE.AUDIO.PlayOneShot(SE.CRIP[4]);//�s����  
                    seflag = true;
                    cnt += Time.deltaTime * 10;
                    if (Mathf.Sin(cnt) > 0)
                    {
                        seikai.color = Color.blue;
                    }
                    else
                    {
                        seikai.color = Color.clear;
                    }
                    if (cnt > 50)
                    {
                        cnt = 0;
                        seflag = false;
                        seikai.color = Color.clear;
                        Phase = 11;
                    }
                }
                break;
            case 11:
                cnt2 += Time.deltaTime;
                break;
            default:
                print("Oops,I did it!");
                break;
        }
    }
}
