using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int Num = 0, goal = 0;
    int Len = 0;
    void PlayerPosition()
    {
        print("�v���C���[ " + Num + " �̏ꏊ���m�F����ZOI!");
        if (Stage.Goal[Num] == true) return;
        else
        {
            if (Stage.masu[Num] == Stage.grid.Length)//�S�[������
            {
                Stage.Goal[Num] = true;
                goal++;
                print("�v���C���[ " + Num + " ���S�[������ZOI!");
            }
        }
    }
    void PlayerRoll()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Len = Random.Range(1, 7); ;
            print("�v���C���[ " + Num + " ���T�C�R����U����ZOI!");
            print("�T�C�R���̖ڂ�..." + Len);
            Main.Phase++;
        }
    }
    void PlayerMove()
    {
        for (int l = 0; l < Len; l++)
        {
            if (Stage.masu[Num] < Stage.grid.Length) Stage.masu[Num]++;
            else if (Stage.masu[Num] > Stage.grid.Length) Stage.masu[Num] += 0;
            else if (Stage.masu[Num] == Stage.grid.Length) Stage.masu[Num] += 0;
            Stage.players[Num].transform.position = Stage.grid[Stage.masu[Num]].transform.position + new Vector3(0, 2, 0);
        }
        print("�v���C���[ " + Num + " �̃}�X�ڂ� " + Stage.masu[Num] + " ��ZOI!");
        print("�v���C���[ " + Num + " ���R�}�𓮂�����ZOI!");
        Main.Phase++;
    }
    void PlayerPass()
    {
        if (Num < OPTION.menberLen)
        {
            Num++;
            print("�v���C���[ " + Num + " �ɉ񂵂�ZOI!");
            Main.Phase = 1;
        }
        if (Num >= OPTION.menberLen)
        {
            Num = 0;
            print("�ꏄ����ZOI");
            Main.Phase = 1;
        }
    }
}