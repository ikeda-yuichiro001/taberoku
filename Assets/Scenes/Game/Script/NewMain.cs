using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewMain : MonoBehaviour
{
    public static int Phase;//switch���œ��������������߂�
    public GameObject Player_obj, Stage_obj, Dice_obj, Grid_obj;//�X�N���v�g�����Ă�I�u�W�F�N�g
    public GameObject CAM;//���C���J����
    public RawImage seikai, huseikai;
    float delay, cnt, a;
    bool One, Rot, seflag;
    void Start()
    {
        OPTION.Load();
        DATA_.userData.Load();
        Phase = 0;
        //NewStage.GridLength = 0;
        VoiceRec.INIT(Recv, new string[]
        { "���[�ނ����イ��傤", "�Ȃ���", "�ӂ�","�͂�","�܂�","������","�΂�"});
    }
    void Recv(string a)
    {
        if (SceneLoader.IsFade) return;
        if (a == "���[�ނ����イ��傤")
        {
            //�S�[�����Ă�l������Ȃ炻�̂܂܃��U���g��ʂ�
            //���Ȃ��ꍇ�͂����Ƃ��S�[���ɋ߂��l��D���ɂ���
            //���������������Ɏ��͔�΂�����
            //BGM.mute = true;
            SE.AUDIO.PlayOneShot(SE.CRIP[5]);
            SceneLoader.Load("Result");
        }
        else if (a == "�͂�" || a == "�܂�")
        {
            Phase = 9;
        }
        else if (a == "������" || a == "�΂�")
        {
            Phase = 10;
        }
        else if(Phase == 3 && (a == "�Ȃ���" || a == "�ӂ�"))//�T�C�R���𓊂��鏈���ɔ�΂�
        {
            Phase = 4;//Phase�����ɐi�߂�
            One = false;
        }
    }
    void Update()
    {
        //Player_obj.GetComponent<NewPlayer>().PlayerCircular();//�T�[�N��
        switch (Phase)
        {
            case 0://�Q�[���̏��߂ɐݒ�𔽉f������
                Stage_obj.GetComponent<NewStage>().ReserveStage();//�}�X�ƃ��C���̐���
                //Player_obj.GetComponent<NewPlayer>().CreatePlayer();//�v���C���[�̐���
                Phase = 1;//Phase�����ɐi�߂�
                /*
                if(!One)
                {
                    Player_obj.GetComponent<NewPlayer>().CreatePlayer();//�v���C���[�̐���
                    One = true;
                }
                delay += Time.deltaTime;
                if (delay > 1.5f)
                {
                    delay = 0;
                    One = false;
                    Phase = 1;//Phase�����ɐi�߂�
                }
                 */
                break;
            case 1://�v���C���[�̏ꏊ���m�F
                Player_obj.GetComponent<NewPlayer>().PlayerPositionCheak();
                break;
            case 2://�^�[���̊J�n��UI�\��
                break;
            case 3://�v���C���[���ҋ@��Ԃ̎�
                if (!One)
                {
                    Player_obj.GetComponent<NewPlayer>().OnPlayerName();//���O��\��
                    Dice_obj.GetComponent<Dice>().DiceSetting();//�T�C�R���ҋ@
                    Player_obj.GetComponent<NewPlayer>().PlayerCircular();
                    One = true;
                }
                break;
            case 4://�T�C�R���𓊂��鏈��
                if (!Rot)
                {
                    Player_obj.GetComponent<NewPlayer>().OffPlayerName();//���O���\��
                    Dice_obj.GetComponent<Dice>().DiceRotate();
                    Rot = true;
                }
                else delay += Time.deltaTime;
                if (delay > 1.5f)
                {
                    Dice_obj.GetComponent<Dice>().DiceThrow();
                    delay = 0;
                    Rot = false;
                    Main.Phase = 5;//Phase�����ɐi�߂�
                }
                break;
            case 5://�T�C�R���̖ڂ̊m�F
                break;
            case 6://�v���C���[�̍s��(�R�}�̈ړ�)//�Ǝc��̐i�ރ}�X�̕\��
                Player_obj.GetComponent<NewPlayer>().MoveCam();//���_�ړ�
                Player_obj.GetComponent<NewPlayer>().PlayerMoveAvoid();
                Player_obj.GetComponent<NewPlayer>().PlayerMove();
                break;
            case 7://�~�܂����}�X�̏���
                Grid_obj.GetComponent<Grid>().GridProcessing();
                break;
            case 8://�~�܂����}�X�̌��ʂ̏���
                Grid_obj.GetComponent<Grid>().Creating();
                break;
            case 9:
                Grid.set = false;
                Grid.se = false;
                Grid.Gameturn = false;
                if (Grid.staticquestions[Grid.rand].Answer == true) //KeyCode.���Ȃ�YES��I���Ȃ̂�questions[?].Answer��true�Ȃ琳���ƂȂ�
                {
                    Phase = 11;
                }
                else
                {
                    Phase = 12;
                }
                break;
            case 10:
                Grid.set = false;
                Grid.se = false;
                Grid.Gameturn = false;
                if (Grid.staticquestions[Grid.rand].Answer == false) //KeyCode.���Ȃ�YES��I���Ȃ̂�questions[?].Answer��true�Ȃ琳���ƂȂ�
                {
                    Phase = 11;
                }
                else
                {
                    Phase = 12;
                }
                break;
            case 11://����!!
                if (!seflag)
                {
                    SE.AUDIO.PlayOneShot(SE.CRIP[3]);//����!!
                    seflag = true;
                }
                cnt += Time.deltaTime * 10;
                seikai.color = new Color(1, 1, 1, a + (1 - a) * (1 - ((Mathf.Sin(cnt) + 1) * (Mathf.Sin(cnt) + 1))));
                if (cnt > 35)
                {
                    seikai.color = Color.white;
                }
                if (cnt > 50)
                {
                    cnt = 0;
                    seflag = false;
                    seikai.color = Color.clear;
                    Stage.textboxs.SetActive(false);
                    Phase = 13;
                }
                break;
            case 12://�s����  
                if (!seflag)
                {
                    SE.AUDIO.PlayOneShot(SE.CRIP[4]);
                    seflag = true;
                }
                cnt += Time.deltaTime * 10;
                huseikai.color = new Color(1, 1, 1, a + (1 - a) * (1 - ((Mathf.Sin(cnt) + 1) * (Mathf.Sin(cnt) + 1))));
                if (cnt > 35)
                {
                    huseikai.color = Color.white;
                }
                if (cnt > 50)
                {
                    cnt = 0;
                    seflag = false;
                    huseikai.color = Color.clear;
                    Stage.textboxs.SetActive(false);
                    Phase = 14;
                }
                break;
            case 13://����^�[��
                Stage.textboxs2.SetActive(true);
                //targetObj[2].GetComponent<Grid>().Explanat();
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Stage.textboxs2.SetActive(false);
                    Phase = 16;//targetObj[1].GetComponent<Player>().PlayerPass();
                }
                break;
            case 14://���&���Q�[���^�[��(����^�[��)
                Stage.textboxs2.SetActive(true);
                //targetObj[2].GetComponent<Grid>().Explanat();
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Stage.textboxs2.SetActive(false);
                    Phase = 15;
                }
                break;
            case 15://���&���Q�[���^�[��(���Q�[���^�[��)
                Stage.textboxs3.SetActive(true);
                //targetObj[2].GetComponent<Grid>().SinGames();
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Stage.textboxs3.SetActive(false);
                    Phase = 16;//targetObj[1].GetComponent<Player>().PlayerPass();
                }
                break;
            case 16://masu�ɉ����Ȃ��������玟�̐l�ɉ�
                delay += Time.deltaTime;
                if (delay > 1.4f)
                {
                    Player_obj.GetComponent<NewPlayer>().PlayerPass();
                    delay = 0;
                }
                //print("Phase 7�_���[��");
                break;
            case 17://�S�[���̏���
                //targetObj[5].GetComponent<Fin>().Finish();
                print("�I���I");
                break;
            default:
                print("Oops,I did it!");
                break;
        }
    }
}
