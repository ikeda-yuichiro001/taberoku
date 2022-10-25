using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public int Minutes, Seconds;//�䂭�䂭��private�ɂ���
    private float S;
    float delay;
    public static int Phase;
    bool seflag , dSet, Rot;
    float cnt,cnt2;
    public Text Timer;
    public RawImage seikai, huseikai;
    public GameObject[] targetObj;
    void Start()
    {
        OPTION.Load();
        Minutes = OPTION.time;
        Seconds = 0;
        S = 0;
        Phase = 0;
        seikai.color = Color.clear;
        huseikai.color = Color.clear;
    }
    
    void Update()
    {
        S += Time.deltaTime;
        if(S >= 1.0f)
        {
            Seconds--;
            if (Seconds < 0)
            {
                Seconds = 59;
                Minutes--; 
                if(Minutes < 0)
                {
                    Phase = 8;//�ǂ����ŃS�[�����Ă邩���ĂȂ������݂Ĉ�ʂ̐l�����߂�
                }
            }
            S = 0;
        }
        Timer.text = "�c�莞�� " + Minutes.ToString() + "��"�@+ Seconds.ToString() + "�b";
        //targetObj[1].GetComponent<Player>().PlayerCircular();
        //print("Phase " + Phase + "�_���[��");
        switch (Phase)
        {
            case 0://�X�e�[�W&�v���C���[�̐���
                targetObj[0].GetComponent<Stage>().StageCreate();
                Phase = 1;
                break;
            case 1://�v���C���[�̍s��(�ʒu���݂�)
                targetObj[0].GetComponent<Stage>().MoveCam();//���_�ړ�
                targetObj[1].GetComponent<Player>().PlayerMove0();//��̈ʒu����
                if (Player.goal<OPTION.menberLen)
                {
                    targetObj[1].GetComponent<Player>().PlayerPosition();
                    //�S�[�����Ă��Ȃ��l��������Phase++;
                }
                else if(Player.goal == OPTION.menberLen)
                {
                    Phase = 8;//�S�����S�[��������
                    print("�v���C���[�S�����S�[������ZOI!");
                }
                break;
            case 2://�v���C���[�̍s��(�T�C�R����U��)
                if (!dSet)
                {
                    targetObj[3].GetComponent<Dice>().DiceSetting();
                    dSet = true;
                }
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Rot = true;
                }
                if (Rot)
                {
                    targetObj[3].GetComponent<Dice>().DiceRotate();
                    delay += Time.deltaTime;
                    if (delay > 1.5f)
                    {
                        targetObj[3].GetComponent<Dice>().DiceThrow();
                        delay = 0;
                        dSet = false;
                        Rot = false;
                    }
                }
                Stage.evocation.SetActive(true);
                targetObj[4].GetComponent<Evocat>().Texts();
                break;
            case 3:
                Stage.evocation.SetActive(false);//�T�C�R���̖ڂ̊m�F
                //print("�T�C�R���̖ڂ̊m�F");
                break;
            case 4: //�v���C���[�̍s��(�R�}�̈ړ�)
                targetObj[0].GetComponent<Stage>().MoveCam();//���_�ړ�
                targetObj[1].GetComponent<Player>().PlayerMove0();
                targetObj[1].GetComponent<Player>().PlayerMove1();
                break;
            case 5://�~�܂����}�X�̏���
                targetObj[2].GetComponent<Grid>().GridProcessing();
                //print("Phase 5�_���[��");
                break;
            case 6://�~�܂����}�X�̌��ʂ̏���
                targetObj[2].GetComponent<Grid>().Creating();
                //print("Phase 6�_���[��");
                //Phase++;
                break;
            case 7://���̐l�ɉ�
                delay += Time.deltaTime; 
                if(delay > 1.4f)
                {
                    targetObj[1].GetComponent<Player>().PlayerPass();
                    delay = 0;
                }
                //print("Phase 7�_���[��");
                break;
            case 8://�S�[���̏���
                targetObj[5].GetComponent<Fin>().Finish();
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
                    Stage.textboxs.SetActive(false);
                    Phase = 11;
                }
                break;
            case 10:
                if (!seflag)
                {
                    SE.AUDIO.PlayOneShot(SE.CRIP[4]);//�s����  
                    seflag = true;
                }
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
                    Stage.textboxs.SetActive(false);
                    Phase = 11;
                }
                break;
            case 11://����^�[��
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    targetObj[1].GetComponent<Player>().PlayerPass();
                }
                break;
            default:
                print("Oops,I did it!");
                break;
        }
    }
}
