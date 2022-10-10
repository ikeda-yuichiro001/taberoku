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
            if (Stage.masu[Num] == Stage.grid.Length - 1)//ゴール判定
            {
                Stage.Goal[Num] = true;
                goal++;
                Main.Phase = 7;
                print("プレイヤー " + Num + " がゴールしたZOI!");
            }
            else Main.Phase++;
        }
        print("プレイヤー " + Num + " の場所を確認したZOI!");
    }

    void PlayerMove()
    {
        //Debug.Log("マス目の合計は" + Stage.grid.Length + "Deth。");
        for (l = 0; l < Len; l++)
        {
            Invoke("Move", 0.5f);
        }
        if(l == Len)
        {
            print("プレイヤー " + Num + " のマス目は " + Stage.masu[Num] + " だZOI!");
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
        print("プレイヤー " + Num + " がコマを動かしたZOI!");
    }

    void PlayerPass()
    {
        if (Num < OPTION.menberLen - 1)
        {
            Num++;
            print("プレイヤー " + Num + " に回したZOI!");
            Main.Phase = 1;
        }
        else if (Num >= OPTION.menberLen -1)
        {
            Num = 0;
            print("一巡したZOI");
            Main.Phase = 1;
        }
    }
}
