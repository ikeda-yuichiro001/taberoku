using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPlayer : MonoBehaviour
{
    public static int DiceNum;//�T�C�R���̏o����
    public static int Num;//���̃v���C���[�̏���
    public static int goal;//�S�[�����Ă�l�̐�
    public GameObject Camera;//�J���������锠
    public GameObject PreNameTag;//�v���C���[�̖��O�̌������锠
    public RawImage PreNameCol;//�v���C���[�̖��O(�F)�̌������锠
    public Text PreNameStr;//�v���C���[�̖��O(����)�̌������锠
    public GameObject[] PlayerOBJ;//�v���C���[�̃I�u�W�F�N�g�����Ƃ���
    public PlayerDeta[] playerDetas = new PlayerDeta[OPTION.menberLen];//�v���C���[�̃f�[�^
    //public static PlayerDeta[] Serializable_playerDetas = new PlayerDeta[OPTION.menberLen];
    public LineRenderer CircularLine;//�v���C���[�̋���
    int CircularPoint;
    private float CircularTime;
    float MoveTime, set;
    int NumSet;
    bool Cheak, Move;

    public void CreatePlayer()//��̐���
    {
        for (int C = 0;C < OPTION.menberLen;C++)
        {
            //playerDetas[C].KOMAOBJ = Instantiate(PlayerOBJ[DATA_.userData.data[C].shape],
            //    NewStage.GridPositions[C], Quaternion.identity);//��̎w��
            //playerDetas[C].PlayerPos = NewStage.GridPositions[C];//�C���X�y�N�^�[�Ō���p
            playerDetas[C].NowGridNum = 0;//���̃}�X��
            playerDetas[C].Goal = false;//�S�[������
            playerDetas[C].NameTag = Instantiate(PreNameTag, new Vector3(0, 0, 0)/*�����ʒu�̎w��*/, Quaternion.identity);//�L�����o�X�̎w��            
            playerDetas[C].KOMAOBJ.transform.SetParent(playerDetas[C].NameTag.transform, false);//KOMAOBJ�̎q�I�u�W�F�N�g��
            playerDetas[C].NameCol = Instantiate(PreNameCol, new Vector3(0, 0, 0), Quaternion.identity);//Image�I�u�W�F�N�g������
            playerDetas[C].NameCol.color = StartManager.PlayerColor[DATA_.userData.data[C].color];//�F�̎w��
            playerDetas[C].NameTag.transform.SetParent(playerDetas[C].NameCol.transform, false);//NameTag�̎q�I�u�W�F�N�g��
            playerDetas[C].NameStr = Instantiate(PreNameStr, new Vector3(0,0,0), Quaternion.identity);//Text�I�u�W�F�N�g������
            playerDetas[C].NameStr.text = DATA_.userData.data[C].name;//���O�̎w��
            playerDetas[C].NameTag.transform.SetParent(playerDetas[C].NameStr.transform, false);//NameTag�̎q�I�u�W�F�N�g��
            //playerDetas[C].NameTag;//�L�����o�X�̓����x���グ��
        }
        Num = goal = 0;//������
    }

    public void PlayerCircular()//��̋���
    {
        CircularTime += Time.deltaTime;
        if (CircularTime > 0.01f)
        {
            CircularPoint++;
            CircularLine.positionCount = CircularPoint;
            CircularLine.SetPosition(CircularPoint - 1,
                playerDetas[Num].KOMAOBJ.transform.position
                + new Vector3(Mathf.Sin(CircularPoint), 0, Mathf.Cos(CircularPoint)));
            if (CircularPoint < 360) CircularPoint = 0;
        }
    }

    public void PlayerPositionCheak()//��̏ꏊ�̊m�F
    {
        if (playerDetas[Num].Goal == true)//�S�[�����Ă���
        {
            //NewMain.Phase = ??;//���̐l�ɉ񂷏����ɔ�΂�
            return;
        }
        else//�S�[�����ĂȂ�������
        {
            if (playerDetas[Num].NowGridNum == NewStage.GridLength)//�~�܂����}�X���S�[�������ʂ���
            {
                playerDetas[Num].Goal = true;//player�̏��Ƃ��ăS�[�������true�ɂ���
                goal++;
                //DATA_.winner.data.Add(new Winner() { name = (string)Stage.texts[Num].text, time = });
                DATA_.winner.Save();
                //Main.Phase = 7;//���̐l�ɉ񂷏����ɔ�΂�
                print("�v���C���[ " + Num + " ���S�[������ZOI!");
                if(goal >= OPTION.menberLen)//�S�[�������l�̐����v���C�l������������I��Phase�ɂƂ΂�
                {

                }
            }
            else NewMain.Phase = 2;//Phase�����ɐi�߂�
        }
    }
    
    public void OnPlayerName()//Standby()
    {
        playerDetas[Num].NameTag.SetActive(true);
    }
    public void OffPlayerName()
    {
        playerDetas[Num].NameTag.SetActive(false);
    }

    public void MoveCam()//�J�����̈ړ�
    {
        Camera.transform.position =
            playerDetas[Num].PlayerPos
            + new Vector3(0, 4, -5);
    }

    public void PlayerMoveAvoid()//�������Ƃ��ɂ悯�鏈��
    {
        for (int leep = 0; leep < Stage.Menber; leep++)
        {
            //playerDetas[Num].KOMAOBJ.transform.position = NewStage.GridPositions[Num];
            if (Num != leep)
            {
                Cheak = false;
                if (Stage.masu[Num] == Stage.masu[leep])
                {
                    if (Cheak == false)
                    {
                        Vector3 Newpos = Stage.players[Num].transform.position
                                             + new Vector3(Mathf.Sin(leep), 0, Mathf.Cos(leep));// * scl;
                        Stage.players[leep].transform.position = Newpos;//�ړ��I�ȓz
                        Cheak = true;
                        //print("�v���C���[" + Num + "�ƃv���C���[" + leep + "���ׂĂ郓�S");
                    }
                }
            }
        }
    }

    public void PlayerMove()//�R�}�̈ړ�
    {
        //Debug.Log("�}�X�ڂ̍��v��" + Stage.grid.Length + "Deth�B");
        if (NumSet < DiceNum)
        {
            if (Move == false && playerDetas[Num].NowGridNum < NewStage.GridLength)
            {
                playerDetas[Num].NowGridNum++;
                Move = true;
            }
            else if (Move == false && (playerDetas[Num].NowGridNum > NewStage.GridLength || playerDetas[Num].NowGridNum == NewStage.GridLength))
            {
                SE.AUDIO.PlayOneShot(SE.CRIP[0]);//�S�[�����ۂ����I��ǂ�
                NumSet++;
            }
            if (Move == true)
            {
                MoveTime += Time.deltaTime;
                if (MoveTime >= 0.01f)
                {
                    set += 0.05f;
                    Stage.players[Num].transform.position =
                        Vector3.Lerp(Stage.grid[Stage.masu[Num] - 1].transform.position,
                        Stage.grid[Stage.masu[Num]].transform.position, set);
                    MoveTime = 0;
                    if (set >= 1)
                    {
                        set = 0;
                        Move = false;//�ړ��̏I��
                        NumSet++;
                        SE.AUDIO.PlayOneShot(SE.CRIP[0]);
                        print("�v���C���[ " + Num + " ���R�}�𓮂�����ZOI!");
                    }
                }
            }
        }
        else if (NumSet == DiceNum)
        {
            NumSet = 0;
            print("�v���C���[ " + Num + " �̃}�X�ڂ� " + playerDetas[Num].NowGridNum + " ��ZOI!");
            NewMain.Phase = 7;
        }
    }

    public void PlayerPass()
    {
        if (Num < OPTION.menberLen - 1)
        {
            Num++;
            print("�v���C���[ " + Num + " �ɉ񂵂�ZOI!");
            NewMain.Phase = 1;
        }
        else if (Num >= OPTION.menberLen - 1)
        {
            Num = 0;
            print("�ꏄ����ZOI");
            NewMain.Phase = 1;
        }
    }
}

[System.Serializable]
public class PlayerDeta
{
    public GameObject KOMAOBJ;//��̃I�u�W�F�N�g�����锠
    public GameObject NameTag;//�v���C���[�̖��O�����锠
    public RawImage NameCol;//�v���C���[�̖��O(�F)�����锠
    public Text NameStr;//�v���C���[�̖��O(����)�����锠
    public Vector3 PlayerPos;//�v���C���[�̏ꏊ
    public Color PlayerColor;//player�̐F
    public string PlayerName;//player�̖��O
    public int NowGridNum;//���̃}�X��
    public bool Goal;//�S�[���̔���p
}

