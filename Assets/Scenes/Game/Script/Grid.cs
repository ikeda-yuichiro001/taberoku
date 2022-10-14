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
            if (Gameturn == true) Main.Phase = 6;
        }
        if (Gameturn == false) Main.Phase = 7;
        print("罰ゲームの有無を確認したZOI!");
    }
    void MINIGame()
    {
        Stage.textboxs.SetActive(true);
        //Stage.textboxs.transform.position = new Vector3(0, -400, 0);
        /*for(; Stage.textboxs.transform.position.y < 0;)
        {
            Stage.textboxs.transform.position += new Vector3(0, 10, 0);
        }*/
        print("問題を表示するZOI!");
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Gameturn = false;
            Stage.textboxs.SetActive(false);
            Main.Phase = 7;
        }
    }
}
