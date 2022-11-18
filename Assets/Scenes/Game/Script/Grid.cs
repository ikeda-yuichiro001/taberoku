using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    public static int rand;
    float GT;
    float alf;
    private float pass;
    public static bool set = false;
    public static bool se = false;
    public RawImage Back;
    public Text h1, bun, h2, bun2, h3, bun3;
    public static bool Gameturn;
    public void GridProcessing()
    {
        for (int len = 0; len < 5 * Stage.Menber; len++)//罰ゲームマスのチェック
        {
            //print(Stage.MiniGame[len]);
            if (Stage.masu[Player.Num] == Stage.MiniGame[len])
            {
                Gameturn = true; //マスに効果があったら
                print("デデーン　OUT!");
            }
            if (Gameturn == true) Main.Phase = 6;//NewMain.Phase = 8;
        }
        if (Gameturn == false)
        {
            Main.Phase = 7;//NewMain.Phase = 16;
        }
        print("罰ゲームの有無を確認したZOI!");
    }
    public void Creating()
    {
        if (set == false)
        {
            for(int q = 0; q < 10;q++)
            {
                staticquestions[q] = questions[q];
            }
            Stage.textboxs.SetActive(true);
            Back.color = new Color(Back.color.r, Back.color.g, Back.color.b, 0);
            h1.color = new Color(0, 0, 0, 0);
            bun.color = new Color(0, 0, 0, 0);
            print("問題を表示するZOI!");
            rand = Random.Range(0, 10);
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
                h1.text = "問題";
                bun.text = questions[rand].questionText;
                SE.AUDIO.PlayOneShot(SE.CRIP[2]);
                se = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            set = false;
            se = false;
            Gameturn = false;
            if (questions[rand].Answer == true) //KeyCode.▲ならYESを選択なのでquestions[?].Answerがtrueなら正解となる
            {
                Main.Phase = 9;//NewMain.Phase = 11;
            }
            else
            {
                Main.Phase = 10;//NewMain.Phase = 12;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            set = false;
            se = false;
            Gameturn = false;
            if (questions[rand].Answer == false) //KeyCode.▽ならNoを選択なのでquestions[?].Answerがfalseなら正解となる
            {
                Main.Phase = 9;//NewMain.Phase = 11;
            }
            else
            {
                Main.Phase = 10;//NewMain.Phase = 12;
            }
        }
        /*if (Input.GetKeyDown(KeyCode.Return))
        {
            set = false;
            se = false;
            Gameturn = false;
            Stage.textboxs.SetActive(false);
            Main.Phase = 7;
        }*/
    }
    public void Explanat()
    {
        h2.text = "解説";
        bun2.text = explanations[rand].explanationText;
    }
    public void SinGames()
    {
        h3.text = "罰ゲーム";
        bun3.text = singames[rand].singameText;
    }

    public static Question[] staticquestions = new Question[10];
    public Question[] questions = new Question[10];
    

    public Explanation[] explanations = new Explanation[10];
    

    public SinGame[] singames = new SinGame[10];
    
}

[System.Serializable]
public class Question
{
    [Multiline]
    public string questionText;
    public bool Answer;//yes => true, no => false;
}

[System.Serializable]
public class Explanation
{
    [Multiline]
    public string explanationText;
    //public bool Answer;//yes => true, no => false;
}

[System.Serializable]
public class SinGame
{
    [Multiline]
    public string singameText;
    //public bool Answer;//yes => true, no => false;
}
