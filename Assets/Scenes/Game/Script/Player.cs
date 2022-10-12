using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

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
            else Main.Phase = 2;
        }
        print("プレイヤー " + Num + " の場所を確認したZOI!");
    }

    async void PlayerMove()
    {
        //Debug.Log("マス目の合計は" + Stage.grid.Length + "Deth。");

        if(l < Len)
        {
            if (Stage.masu[Num] < Stage.grid.Length - 1) Stage.masu[Num]++;
            else if (Stage.masu[Num] > Stage.grid.Length - 1) Stage.masu[Num] += 0;
            else if (Stage.masu[Num] == Stage.grid.Length - 1) Stage.masu[Num] += 0;
            Stage.players[Num].transform.position = Stage.grid[Stage.masu[Num]].transform.position;
            print("プレイヤー " + Num + " がコマを動かしたZOI!");
            l++;
            SE.AUDIO.PlayOneShot(SE.CRIP[0]);
            await MoveDelay();
        }
        if (l == Len)
        {
            l = 0;
            print("プレイヤー " + Num + " のマス目は " + Stage.masu[Num] + " だZOI!");
            Main.Phase = 5;
        }
    }
    async Task MoveDelay()
    {
        await Task.Delay(10000000);
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
