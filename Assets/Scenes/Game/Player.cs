using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int Num = 0, goal = 0, Len = 0;
    int l = 0;
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
            else Main.Phase++;
        }
        print("�v���C���[ " + Num + " �̏ꏊ���m�F����ZOI!");
    }

    void PlayerMove()
    {
        //Debug.Log("�}�X�ڂ̍��v��" + Stage.grid.Length + "Deth�B");
        for (l = 0; l < Len; l++)
        {
            Invoke("Move", 0.5f);
        }
        if(l == Len)
        {
            print("�v���C���[ " + Num + " �̃}�X�ڂ� " + Stage.masu[Num] + " ��ZOI!");
            Main.Phase++;
        }
    }
    void Move()
    {
        if (Stage.masu[Num] < Stage.grid.Length - 1) Stage.masu[Num]++;
        else if (Stage.masu[Num] > Stage.grid.Length - 1) Stage.masu[Num] += 0;
        else if (Stage.masu[Num] == Stage.grid.Length - 1) Stage.masu[Num] += 0;
        Stage.players[Num].transform.position = Stage.grid[Stage.masu[Num]].transform.position + new Vector3(0, 2, 0);
        //l++;
        print("�v���C���[ " + Num + " ���R�}�𓮂�����ZOI!");
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
