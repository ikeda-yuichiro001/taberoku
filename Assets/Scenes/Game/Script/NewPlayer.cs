using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer : MonoBehaviour
{
    public static int Num;//���̃v���C���[�̏���
    public static int goal;//�S�[�����Ă�l�̐�
    public GameObject PreNameTag;//�v���C���[�̖��O�̌������锠
    public GameObject[] PlayerOBJ;//�v���C���[�̃I�u�W�F�N�g�����Ƃ���
    public PlayerDeta[] playerDetas = new PlayerDeta[OPTION.menberLen];//�v���C���[
    //public static PlayerDeta[] Serializable_playerDetas = new PlayerDeta[OPTION.menberLen];
    public LineRenderer CircularLine;
    private int CircularPoint;
    private float CircularTime;

    public void CreatePlayer()//��̐���
    {
        for (int C = 0;C < OPTION.menberLen;C++)
        {
            /*
            Serializable_playerDetas[C].KOMAOBJ = playerDetas[C].KOMAOBJ = PlayerOBJ[DATA_.userData.data[C].shape];
            Serializable_playerDetas[C].PlayerColor = playerDetas[C].PlayerColor = StartManager.PlayerColor[DATA_.userData.data[C].color];
            Serializable_playerDetas[C].PlayerName = playerDetas[C].PlayerName = DATA_.userData.data[C].name;
            Serializable_playerDetas[C].NowGridNum = playerDetas[C].NowGridNum = 0;
            Serializable_playerDetas[C].Goal = playerDetas[C].Goal = false;
            */
            playerDetas[C].KOMAOBJ = PlayerOBJ[DATA_.userData.data[C].shape];
            playerDetas[C].NameTag = PreNameTag;
            playerDetas[C].NameTag.SetActive(false);
            playerDetas[C].PlayerColor = StartManager.PlayerColor[DATA_.userData.data[C].color];
            playerDetas[C].PlayerName = DATA_.userData.data[C].name;
            playerDetas[C].NowGridNum = 0;
            playerDetas[C].Goal = false;
        }
        Num = goal = 0;
    }

    public void PlayerCircular()//��̋���
    {
        if (CircularTime < 1) CircularTime += 0.01f;
        else CircularTime = 0;
        for (int c = 0;c < 360;c++)
        {
            CircularPoint++;
            CircularLine.positionCount = CircularPoint;
            CircularLine.SetPosition(CircularPoint - 1,
                playerDetas[c].KOMAOBJ.transform.position
                + new Vector3(Mathf.Sin(CircularTime),0,Mathf.Cos(CircularTime)));
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
            else NewMain.Phase = 2;
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
}

[System.Serializable]
public class PlayerDeta
{
    public GameObject KOMAOBJ;//��̃I�u�W�F�N�g�����锠
    public GameObject NameTag;//�v���C���[�̖��O�����锠
    public Color PlayerColor;//player�̐F
    public string PlayerName;//player�̖��O
    public int NowGridNum;//���̃}�X��
    public bool Goal;//�S�[���̔���p
}

