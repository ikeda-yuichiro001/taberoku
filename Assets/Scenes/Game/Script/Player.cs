using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public LineRenderer CircularLine;
    private int Wave;
    private float e;  //収縮率
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


    void PlayerMove0()//元の位置にはどげして戻そうかや
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
                        Stage.players[leep].transform.position = Newpos;//移動的な奴
                        Cheak = true;
                        //print("プレイヤー" + Num + "とプレイヤー" + leep + "を比べてるンゴ");
                    }
                }
            }
        }
    }
    void PlayerMove1()
    {
        //Debug.Log("マス目の合計は" + Stage.grid.Length + "Deth。");
        if(l < Len)
        {
            if (Moooove == false && Stage.masu[Num] < Stage.grid.Length - 1)
            {
                Stage.masu[Num]++;
                //print("アムロ行っきまーす!");
                Moooove = true;
            }
            else if (Moooove == false && (Stage.masu[Num] > Stage.grid.Length - 1 || Stage.masu[Num] == Stage.grid.Length - 1))
            {
                l++;
                SE.AUDIO.PlayOneShot(SE.CRIP[0]);//ゴールっぽいやつを選んどく
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
                        Moooove = false;//移動の終了
                        l++;
                        SE.AUDIO.PlayOneShot(SE.CRIP[0]);
                        print("プレイヤー " + Num + " がコマを動かしたZOI!");
                    }
                }
            }
        }
        else if (l == Len)
        {
            l = 0;
            print("プレイヤー " + Num + " のマス目は " + Stage.masu[Num] + " だZOI!");
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