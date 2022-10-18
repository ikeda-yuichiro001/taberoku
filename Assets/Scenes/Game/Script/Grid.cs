using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    float GT;
    float alf;
    bool set = false;
    bool se = false;
    public RawImage Back;
    public Text h1, bun;
    public static bool Gameturn;
    void GridProcessing()
    {
        for (int len = 0; len < 5 * Stage.Menber; len++)//罰ゲームマスのチェック
        {
            //print(Stage.MiniGame[len]);
            if (Stage.masu[Player.Num] == Stage.MiniGame[len])
            {
                Gameturn = true; //マスに効果があったら
                print("デデーン　OUT!");
            }
            else
            {//なかったら
                //print("チッ!");
            }
            if (Gameturn == true) Main.Phase = 6;
        }
        if (Gameturn == false) Main.Phase = 7;
        print("罰ゲームの有無を確認したZOI!");
    }
    void Creating()
    {
        if (set == false)
        {
            Stage.textboxs.SetActive(true);
            Back.color = new Color(Back.color.r, Back.color.g, Back.color.b, 0);
            h1.color = new Color(0, 0, 0, 0);
            bun.color = new Color(0, 0, 0, 0);
            print("問題を表示するZOI!");
            set = true;
        }
        GT += Time.deltaTime;
        if (GT >= 0.01f)
        {
            if (Back.color.a < 1.0f)
            {
                alf += Time.deltaTime;
                GT = 0;
            }
        }
        Back.color = new Color(Back.color.r, Back.color.g, Back.color.b, alf);
        if (Back.color.a >= 1.0f)
        {
            h1.color = new Color(0, 0, 0, 1.0f);
            bun.color = new Color(0, 0, 0, 1.0f);
            if (se == false)
            {
                SE.AUDIO.PlayOneShot(SE.CRIP[2]);
                se = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            set = false;
            se = false;
            Gameturn = false;
            Stage.textboxs.SetActive(false);
            Main.Phase = 7;
        }
    }
}
