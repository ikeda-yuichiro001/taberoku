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
    public RawImage Back;
    public Text h1, bun, h2, bun2, h3, bun3;
    public static bool Gameturn;
    public void GridProcessing()
    {
        for (int len = 0; len < 5 * Stage.Menber; len++)//���Q�[���}�X�̃`�F�b�N
        {
            //print(Stage.MiniGame[len]);
            if (Stage.masu[Player.Num] == Stage.MiniGame[len])
            {
                Gameturn = true; //�}�X�Ɍ��ʂ���������
                print("�f�f�[���@OUT!");
            }
            if (Gameturn == true) Main.Phase = 6;//NewMain.Phase = 8;
        }
        if (Gameturn == false)
        {
            Main.Phase = 7;//NewMain.Phase = 16;
        }
        print("���Q�[���̗L�����m�F����ZOI!");
    }
    public void Creating()
    {
        if (!set)
        {
            /*for(int q = 0; q < 10;q++)
            {
                staticquestions[q] = questions[q];
            }*/
            Stage.textboxs.SetActive(true);
            Back.color = new Color(Back.color.r, Back.color.g, Back.color.b, 0);
            h1.color = Color.clear;
            bun.color = Color.clear;
            rand = Random.Range(0, 10);
            h1.text = "���";
            bun.text = questions[rand].questionText;
            GT = 0;
            print("����\������ZOI!");
            set = true;
        }
        GT += Time.deltaTime;
        if (GT < 2)
        {
            Back.color += new Color(0, 0, 0, Time.deltaTime);
            h1.color += Color.black * Time.deltaTime;
            bun.color += Color.black * Time.deltaTime;
        }
        else if (GT < 2.5f)
        {
            Back.color = new Color(Back.color.r, Back.color.g, Back.color.b, 1.0f);
            h1.color = new Color(0, 0, 0, 1.0f);
            bun.color = new Color(0, 0, 0, 1.0f);
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
            if (questions[rand].Answer == true) //KeyCode.���Ȃ�YES��I���Ȃ̂�questions[?].Answer��true�Ȃ琳���ƂȂ�
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
            if (questions[rand].Answer == false) //KeyCode.���Ȃ�No��I���Ȃ̂�questions[?].Answer��false�Ȃ琳���ƂȂ�
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
            h2.color = Color.clear;
            bun2.color = Color.clear;
            GT = 0;
            print("�����\������ZOI!");
            set2 = true;
        }
        GT += Time.deltaTime;
        if (GT < 2)
        {
            h1.color += Color.clear * Time.deltaTime;
            bun.color += Color.clear * Time.deltaTime;
        }
        if (GT < 5)
        {
            h1.color = Color.clear * Time.deltaTime;
            bun.color = Color.clear * Time.deltaTime;
            h2.color -= Color.black * Time.deltaTime;
            bun2.color -= Color.black * Time.deltaTime;
        }
        if (GT < 9)
        {
            h2.color = Color.black * Time.deltaTime;
            bun2.color = Color.black * Time.deltaTime;
        }
        if (h2.color.a >= 1.0f)
        {
            h2.color = new Color(0, 0, 0, 1.0f);
            bun2.color = new Color(0, 0, 0, 1.0f);
            h2.text = "���";
            bun2.text = explanations[rand].explanationText;
            set2 = false;
        }
    }
    public void SinGames()
    {
        if (!set3)
        {
            Stage.textboxs3.SetActive(true);
            h3.color = Color.clear;
            bun3.color = Color.clear;
            print("���Q�[����\������ZOI!");
            set3 = true;
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
            h3.color = new Color(0, 0, 0, 1.0f);
            bun3.color = new Color(0, 0, 0, 1.0f);
            h3.text = "���Q�[��";
            bun3.text = singames[rand].singameText;
        }
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
