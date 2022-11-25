using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int Num = 0, goal = 0, Len = 0;
    public float scl;
    int l = 0;
    float set = 0;
    float TT;
    static public int GG;
    bool Moooove = false;
    bool Cheak = false;
    static public bool gg;
    /*
    void Start()
    {
        Debug.Log(CircularLine);
    }*/
    public void PlayerPosition()
    {
        if (Stage.Goal[Num] == true)
        {
            Main.Phase = 7;//次の人に回す
            return;
        }
        else
        {
            if (Stage.masu[Num] == Stage.grid.Length - 1)//ゴール判定
            {
                if(!gg)
                {
                    GG = Num;
                    gg = true;
                }
                Stage.Goal[Num] = true;
                goal++;
                //DATA_.winner.data.Add(new Winner() { name = (string)Stage.texts[Num].text, time = });
                DATA_.winner.Save();
                Main.Phase = 7;
                print("プレイヤー " + Num + " がゴールしたZOI!");
            }
            else Main.Phase = 13;
        }
        print("プレイヤー " + Num + " の場所を確認したZOI!");
    }


    public void PlayerMove0()
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
    public void PlayerMove1()
    {
        //Debug.Log("マス目の合計は" + Stage.grid.Length + "Deth。");
        if(l < Len)
        {
            if (Moooove == false && Stage.masu[Num] < Stage.grid.Length - 1)
            {
                Stage.masu[Num]++;
                print("アムロ行っきまーす!");
                Moooove = true;
            }
            else if (Moooove == false && (Stage.masu[Num] > Stage.grid.Length - 1 || Stage.masu[Num] == Stage.grid.Length - 1))
            {
                l++;
                //SE.AUDIO.PlayOneShot(SE.CRIP[0]);//ゴールっぽいやつを選んどく
                print("アムロ逝っきまーす!");
            }
            if (Moooove == true)
            {
                TT += Time.deltaTime;
                if (TT > 0.01f)
                {
                    set += Time.deltaTime * Vector3.Distance(Stage.grid[Stage.masu[Num] - 1].transform.position,
                        Stage.grid[Stage.masu[Num]].transform.position) / 2;
                    Stage.players[Num].transform.position =
                        Vector3.Lerp(Stage.grid[Stage.masu[Num] - 1].transform.position,
                        Stage.grid[Stage.masu[Num]].transform.position, set);
                    TT = 0;
                    if (set > 1)
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
        else if (l >= Len)
        {
            l = 0;
            print("プレイヤー " + Num + " のマス目は " + Stage.masu[Num] + " だZOI!");
            Main.Phase = 5;
        }
    }

    public void PlayerPass()
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