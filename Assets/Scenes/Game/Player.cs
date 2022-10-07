using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int Num = 0, goal = 0;
    int Len = 0;
    void PlayerPosition()
    {
        if (Stage.Goal[Num] == true)
        {
            Main.Phase++;
            return;
        }
        else
        {
            if (Stage.masu[Num] == Stage.grid.Length - 1)//ゴール判定
            {
                Stage.Goal[Num] = true;
                goal++;
                Main.Phase = 6;
                print("プレイヤー " + Num + " がゴールしたZOI!");
            }
            else Main.Phase++;
        }
        print("プレイヤー " + Num + " の場所を確認したZOI!");
    }
    void PlayerRoll()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Len = Random.Range(1, 7); ;
            print("プレイヤー " + Num + " がサイコロを振ったZOI!");
            //print("サイコロの目は..." + Len);
            Main.Phase++;
        }
    }
    void PlayerMove()
    {
        //Debug.Log("マス目の合計は" + Stage.grid.Length + "Deth。");
        for (int l = 0; l < Len; l++)
        {
            if (Stage.masu[Num] < Stage.grid.Length - 1) Stage.masu[Num]++;
            else if (Stage.masu[Num] > Stage.grid.Length - 1) Stage.masu[Num] += 0;
            else if (Stage.masu[Num] == Stage.grid.Length - 1) Stage.masu[Num] += 0;
            print("プレイヤー " + Num + " のマス目は " + Stage.masu[Num] + " だZOI!");
            Stage.players[Num].transform.position = Stage.grid[Stage.masu[Num]].transform.position + new Vector3(0, 2, 0);
        }
        //print("プレイヤー " + Num + " がコマを動かしたZOI!");
        Main.Phase++;
    }
    void PlayerPass()
    {
        if (Num < OPTION.menberLen)
        {
            Num++;
            //print("プレイヤー " + Num + " に回したZOI!");
            Main.Phase = 1;
        }
        if (Num >= OPTION.menberLen)
        {
            Num = 0;
            //print("一巡したZOI");
            Main.Phase = 1;
        }
    }
}
