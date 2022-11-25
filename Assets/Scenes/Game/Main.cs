using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    float a = 0.2f;
    public LineRenderer CircularLine;
    private int Wave;
    float eTime;
    float ttt;
    private float e;  //���k��
    public static int GoalMasu;
    public AudioSource BGM;
    public int Minutes, Seconds;//�䂭�䂭��private�ɂ���
    private float S;
    float delay;
    public static int Phase;
    public static bool Moob;
    bool seflag , dSet, Rot, Zero;
    float cnt,cnt2;
    public Text Timer;
    public RawImage seikai, huseikai;
    public GameObject[] targetObj;
    public GameObject camera_;
    public GameObject OWARI;

    void Start()
    {
        OPTION.Load();
        Minutes = OPTION.time;
        Seconds = 0;
        S = 0;
        Phase = 0;
        BGM.mute = false;
        seikai.color = Color.clear;
        huseikai.color = Color.clear;
        OWARI.SetActive(false);
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
            Phase = 8;
        }
        else if((a == "�͂�" || a == "�܂�") && Phase == 6)
        {
            Phase = 15;
        }
        else if ((a == "������" || a == "�΂�") && Phase == 6)
        {
            Phase = 16;
        }
        else
        {
            Rot = true;
        }
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Escape))
        {
            if(!Player.gg)
            {
                for (int a = 0; a < OPTION.menberLen; a++)
                {
                    if (GoalMasu < Stage.masu[a])
                    {
                        GoalMasu = Stage.masu[a];
                        Player.GG = a;
                    }
                    //������ʂ�����ꍇ
                    /*
                    else if (GoalMasu == Stage.masu[a])
                    {

                    }*/
                }
                Phase = 8;
            }
            else Phase = 8;
        }
        /*S += Time.deltaTime;
        if(S >= 1.0f)
        {
            Seconds--;
            if (Seconds < 0)
            {
                Seconds = 59;
                Minutes--; 
                if(Minutes < 0)
                {
                    //�ǂ����ŃS�[�����Ă邩���ĂȂ������݂Ĉ�ʂ̐l�����߂�
                }
            }
            S = 0;
        }
        Timer.text = "�c�莞�� " + Minutes.ToString() + "��"�@+ Seconds.ToString() + "�b";
        //targetObj[1].GetComponent<Player>().PlayerCircular();
        ttt += Time.deltaTime;
        if (ttt > 0.01f)
        {
            eTime += Time.deltaTime;
            e = Mathf.Cos(eTime) * 1.0f;
            Wave++;
            CircularLine.positionCount = Wave;
            CircularLine.SetPosition(Wave - 1,
                Stage.players[Player.Num].transform.position
                + new Vector3(5, 0, 5) * e);
            ttt = 0;
        }*/
        //print("Phase " + Phase + "�_���[��");
        switch (Phase)
        {
            case 0://�X�e�[�W&�v���C���[�̐���
                targetObj[0].GetComponent<Stage>().StageCreate();
                camera_.transform.position = new Vector3(0, 36, -15);//���_�ړ�
                Phase = 1;
                break;
            case 1://�v���C���[�̍s��(�ʒu���݂�)
                //Stage.Soys[Player.Num].SetActive(true);//���O�̕\��
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
            case 13://���O��UI�o���Ƃ���
                delay += Time.deltaTime;
                if (delay > 1.5f)
                {
                    targetObj[4].GetComponent<InformUI>().Inform();
                }
                break;
            case 18://���O��UI�o���Ƃ���
                if(!Zero)
                {
                    delay = 0;
                    Zero = true;
                }
                delay += Time.deltaTime;
                if (delay > 1.5f)
                {
                    targetObj[0].GetComponent<Stage>().MoveCam();//���_�ړ�
                }
                break;
            case 2://�v���C���[�̍s��(�T�C�R����U��)
                if (!dSet)
                {
                    targetObj[3].GetComponent<Dice>().DiceSetting();
                    dSet = true;
                    Zero = false;
                    delay = 0;
                }
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Rot = true;
                }
                if (Rot)
                {
                    //Stage.Soys[Player.Num].SetActive(false);
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
            case 17:
                delay += Time.deltaTime;
                if (delay > 1.5f)
                {
                    targetObj[4].GetComponent<InformUI>().InformNum();
                }
                break;
            case 4: //�v���C���[�̍s��(�R�}�̈ړ�)
                if(!Moob)
                {
                    targetObj[0].GetComponent<Stage>().ChaseCam();//���_�ړ�
                    Moob = true;
                }
                targetObj[1].GetComponent<Player>().PlayerMove1();
                break;
            case 5://�~�܂����}�X�̏���
                targetObj[1].GetComponent<Player>().PlayerMove0();
                targetObj[2].GetComponent<Grid>().GridProcessing();
                delay = 0;
                break;
            case 6://�~�܂����}�X�̌��ʂ̏���
                targetObj[2].GetComponent<Grid>().Creating();
                break;
            case 7://masu�ɉ����Ȃ��������玟�̐l�ɉ�
                delay += Time.deltaTime; 
                if(delay > 1.4f)
                {
                    targetObj[1].GetComponent<Player>().PlayerPass();
                    camera_.transform.position = new Vector3(0, 36, -15);//���_�ړ�
                    delay = 0;
                }
                //print("Phase 7�_���[��");
                break;
            case 9://����!!
                if (!seflag)
                {
                    SE.AUDIO.PlayOneShot(SE.CRIP[3]);//����!!
                    seflag = true;
                }
                cnt += Time.deltaTime * 10;
                seikai.color = new Color(1, 1, 1, a+(1-a)*(1 - ((Mathf.Sin(cnt) + 1) * (Mathf.Sin(cnt) + 1))));
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
                    Phase = 11;
                }
                break;
            case 10://�s����  
                if (!seflag)
                {
                    SE.AUDIO.PlayOneShot(SE.CRIP[4]);
                    seflag = true;
                }
                cnt += Time.deltaTime * 10;
                huseikai.color = new Color(1, 1, 1, a + (1 - a) * (1 - ((Mathf.Sin(cnt) + 1) * (Mathf.Sin(cnt) + 1))));
                if( cnt > 35)
                {
                    huseikai.color = Color.white;
                }
                if (cnt > 50)
                {
                    cnt = 0;
                    seflag = false;
                    huseikai.color = Color.clear;
                    Stage.textboxs.SetActive(false);
                    Phase = 12;
                }
                break;
            case 11://����^�[��
                Stage.textboxs2.SetActive(true);
                targetObj[2].GetComponent<Grid>().Explanat();
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Stage.textboxs2.SetActive(false);
                    Phase = 7;
                }
                break;
            case 12://��������Q�[���^�[��
                Stage.textboxs2.SetActive(true);
                targetObj[2].GetComponent<Grid>().Explanat();
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Stage.textboxs2.SetActive(false);
                    Phase = 14;
                }
                break;
            case 14:
                Stage.textboxs3.SetActive(true);
                targetObj[2].GetComponent<Grid>().SinGames();
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Stage.textboxs3.SetActive(false);
                    Phase = 7;
                }
                break;
            case 15:
                Grid.set = false;
                Grid.se = false;
                Grid.Gameturn = false;
                if (Grid.staticquestions[Grid.rand].Answer == true) //KeyCode.���Ȃ�YES��I���Ȃ̂�questions[?].Answer��true�Ȃ琳���ƂȂ�
                {
                    Phase = 9;
                }
                else
                {
                    Phase = 10;
                }
                break;
            case 16:
                Grid.set = false;
                Grid.se = false;
                Grid.Gameturn = false;
                if (Grid.staticquestions[Grid.rand].Answer == false) //KeyCode.���Ȃ�YES��I���Ȃ̂�questions[?].Answer��true�Ȃ琳���ƂȂ�
                {
                    Phase = 9;
                }
                else
                {
                    Phase = 10;
                }
                break;
            case 8://�S�[���̏���
                delay += Time.deltaTime;
                if (delay > 1.5f)
                {
                    Zero = true;
                    delay = 0;
                }
                if (Zero)
                {
                    targetObj[5].GetComponent<Fin>().Finish();
                }
                print("�I���I");
                break;
            default:
                print("Oops,I did it!");
                break;
        }
    }
}
