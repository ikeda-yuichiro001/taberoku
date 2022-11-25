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
    bool set2, set3;
    public static bool se = false;
    public RawImage Irasuto,Back, Back2, Back3;
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
        if (!set)
        {
            for (int q = 0; q < 10;q++)
            {
                staticquestions[q] = questions[q];
            }
            Stage.textboxs.SetActive(true);
            Stage.IRASUTOs.SetActive(true);
            Back.color = new Color(Back.color.r, Back.color.g, Back.color.b, 0);
            h1.color = Color.clear;
            bun.color = Color.clear;
            Irasuto.color = Color.clear;
            rand = Random.Range(0, 10);
            h1.text = "問題";
            bun.text = questions[rand].questionText;
            Irasuto.texture = equestions[rand].E;
            GT = 0;
            print("問題を表示するZOI!");
            set = true;
        }
        GT += Time.deltaTime;
        if (GT < 2)
        {
            Back.color += new Color(0, 0, 0, Time.deltaTime);
            Irasuto.color += Color.white * Time.deltaTime;
            h1.color += Color.black * Time.deltaTime;
            bun.color += Color.black * Time.deltaTime;
        }
        else if (GT < 2.5f)
        {
            Back.color = new Color(Back.color.r, Back.color.g, Back.color.b, 1.0f);
            Irasuto.color = Color.white;
            h1.color = Color.black;
            bun.color = Color.black;
        }
        if(Back.color.a > 1)
        {
            if (se == false)
            {
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
    }
    public void Explanat()
    {
        if (!set2)
        {
            Stage.textboxs2.SetActive(true);
            Back2.color = new Color(Back2.color.r, Back2.color.g, Back2.color.b, 0);
            h2.color = Color.clear;
            bun2.color = Color.clear;
            GT = 0;
            print("解説を表示するZOI!");
            set2 = true;
            h2.text = "解説";
            bun2.text = explanations[rand].explanationText;
            GT = 0;
        }
        GT += Time.deltaTime;
        if (GT < 2)
        {
            Back2.color += new Color(0, 0, 0, Time.deltaTime);
            h2.color += Color.black * Time.deltaTime;
            bun2.color += Color.black * Time.deltaTime;
        }
        else if (GT < 2.5f)
        {
            Back2.color = new Color(Back2.color.r, Back2.color.g, Back2.color.b, 1.0f);
            h2.color = Color.black;
            bun2.color = Color.black;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            set2 = false;
        }
    }
    public void SinGames()
    {
        if (!set3)
        {
            Stage.textboxs3.SetActive(true);
            Back3.color = new Color(Back3.color.r, Back3.color.g, Back3.color.b, 0);
            h3.color = Color.clear;
            bun3.color = Color.clear;
            GT = 0;
            print("罰ゲームを表示するZOI!");
            set3 = true;
            h3.text = "罰ゲーム";
            bun3.text = singames[rand].singameText;
        }
        GT += Time.deltaTime;
        if (GT < 2)
        {
            Back3.color += new Color(0, 0, 0, Time.deltaTime);
            h3.color += Color.white * Time.deltaTime;
            bun3.color += Color.white * Time.deltaTime;
        }
        else if (GT < 2.5f)
        {
            Back3.color = new Color(Back3.color.r, Back3.color.g, Back3.color.b, 1.0f);
            h3.color = Color.white;
            bun3.color = Color.white;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            set3 = false;
        }
    }

    public static Question[] staticquestions = new Question[10];
    public Question[] questions = new Question[10];


    public EQuestion[] equestions = new EQuestion[10];
    

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
public class EQuestion
{
    public Texture E;
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
