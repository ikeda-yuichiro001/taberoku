using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    bool Gameturn;
    void GridProcessing()
    {
        for (int len = 0; len < 5 * Stage.Menber; len++)//罰ゲームマスのチェック
        {
            print(Stage.MiniGame[len]);
            if (Stage.masu[Player.Num] == Stage.MiniGame[len])
            {
                Gameturn = true; //マスに効果があったら
                print("デデーン　OUT!");
            }
            else
            {
                Gameturn = false;//なかったら
                print("チッ!");
            }
            if (Gameturn == true) Main.Phase++;
        }
        if (Gameturn == false) Main.Phase = 6;
        print("罰ゲームの有無を確認したZOI!");
    }
    void MINIGame()
    {
        print("ボボボー・ボ・ボーボボ");
        Gameturn = false;
        Main.Phase++;
    }
}
