using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public LineRenderer CircularLine;
    private int Wave;
    private float e;  //���k��
    public static int Num = 0, goal = 0, Len = 0;
    public float scl;
    int l = 0;
    float set = 0;
    float TT;
    float eTime;
    float ttt;
    bool Moooove = false;
    bool Cheak = false;
    void PlayerPosition()
    {
        if (Stage.Goal[Num] == true)
        {
            Main.Phase = 7;
            return;
        }
        else
        {
            if (Stage.masu[Num] == Stage.grid.Length - 1)//�S�[������
            {
                Stage.Goal[Num] = true;
                goal++;
                Main.Phase = 7;
                print("�v���C���[ " + Num + " ���S�[������ZOI!");
            }
            else Main.Phase = 2;
        }
        print("�v���C���[ " + Num + " �̏ꏊ���m�F����ZOI!");
    }


    void PlayerMove0()//���̈ʒu�ɂ͂ǂ����Ė߂�������
    {
        for (int leep = 0; leep < Stage.Menber; leep++)
        {
            Stage.players[Num].transform.position = Stage.grid[Stage.masu[Num]].transform.position;
            if (Num != leep)
            {
                Cheak = false;
                if (Stage.masu[Num] == Stage.masu[leep])
                {
                    if (Cheak == false)
                    {
                        Vector3 Newpos = Stage.players[Num].transform.position
                                             + new Vector3(Mathf.Sin(leep), 0, Mathf.Cos(leep)) * scl;
                        Stage.players[leep].transform.position = Newpos;//�ړ��I�ȓz
                        Cheak = true;
                        //print("�v���C���[" + Num + "�ƃv���C���[" + leep + "���ׂĂ郓�S");
                    }
                }
            }
        }
    }
    void PlayerMove1()
    {
        //Debug.Log("�}�X�ڂ̍��v��" + Stage.grid.Length + "Deth�B");
        if(l < Len)
        {
            if (Moooove == false && Stage.masu[Num] < Stage.grid.Length - 1)
            {
                Stage.masu[Num]++;
                //print("�A�����s�����܁[��!");
                Moooove = true;
            }
            else if (Moooove == false && (Stage.masu[Num] > Stage.grid.Length - 1 || Stage.masu[Num] == Stage.grid.Length - 1))
            {
                l++;
                SE.AUDIO.PlayOneShot(SE.CRIP[0]);//�S�[�����ۂ����I��ǂ�
            }
            if (Moooove == true)
            {
                TT += Time.deltaTime;
                if (TT >= 0.01f)
                {
                    set += 0.1f;
                    Stage.players[Num].transform.position =
                        Vector3.Lerp(Stage.grid[Stage.masu[Num] - 1].transform.position,
                        Stage.grid[Stage.masu[Num]].transform.position, set);
                    TT = 0;
                    if (set >= 1)
                    {
                        set = 0;
                        Moooove = false;//�ړ��̏I��
                        l++;
                        SE.AUDIO.PlayOneShot(SE.CRIP[0]);
                        print("�v���C���[ " + Num + " ���R�}�𓮂�����ZOI!");
                    }
                }
            }
        }
        else if (l == Len)
        {
            l = 0;
            print("�v���C���[ " + Num + " �̃}�X�ڂ� " + Stage.masu[Num] + " ��ZOI!");
            Main.Phase = 5;
        }
    }

    void PlayerCircular()
    {
        ttt += Time.deltaTime;
        if(ttt > 0.01f)
        {
            eTime += Time.deltaTime;
            e = Mathf.Sin(eTime) * 1.0f;
            ttt = 0;
        }
        for (Wave = 0; Wave < 360 ;)
        {
            Wave++;
            CircularLine.positionCount = Wave;
            CircularLine.SetPosition(Wave - 1,
                Stage.players[Num].transform.position
                + new Vector3(Mathf.Sin(Wave), 0, Mathf.Cos(Wave)) * e);
        }
    }

    void PlayerPass()
    {
        if (Num < OPTION.menberLen - 1)
        {
            Num++;
            print("�v���C���[ " + Num + " �ɉ񂵂�ZOI!");
            Main.Phase = 1;
        }
        else if (Num >= OPTION.menberLen -1)
        {
            Num = 0;
            print("�ꏄ����ZOI");
            Main.Phase = 1;
        }
    }
}