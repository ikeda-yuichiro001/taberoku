using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    int rand;
    float GT;
    float alf;
    bool set = false;
    bool se = false;
    public RawImage Back;
    public Text h1, bun;
    public static bool Gameturn;
    void GridProcessing()
    {
        for (int len = 0; len < 5 * Stage.Menber; len++)//���Q�[���}�X�̃`�F�b�N
        {
            //print(Stage.MiniGame[len]);
            if (Stage.masu[Player.Num] == Stage.MiniGame[len])
            {
                Gameturn = true; //�}�X�Ɍ��ʂ���������
                print("�f�f�[���@OUT!");
            }
            else
            {//�Ȃ�������
                //print("�`�b!");
            }
            if (Gameturn == true) Main.Phase = 6;
        }
        if (Gameturn == false) Main.Phase = 7;
        print("���Q�[���̗L�����m�F����ZOI!");
    }
    void Creating()
    {
        if (set == false)
        {
            Stage.textboxs.SetActive(true);
            Back.color = new Color(Back.color.r, Back.color.g, Back.color.b, 0);
            h1.color = new Color(0, 0, 0, 0);
            bun.color = new Color(0, 0, 0, 0);
            print("����\������ZOI!");
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
                bun.text = questions[rand].questionText;
                SE.AUDIO.PlayOneShot(SE.CRIP[2]);
                se = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (questions[rand].Answer == true) //KeyCode.���Ȃ�YES��I���Ȃ̂�questions[?].Answer��true�Ȃ琳���ƂȂ�
            {
                SE.AUDIO.PlayOneShot(SE.CRIP[3]);//����!!
                Main.Phase = 9;
            }
            else
            {
                SE.AUDIO.PlayOneShot(SE.CRIP[4]);//�s����  
                Main.Phase = 10;
            }

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (questions[rand].Answer == false) //KeyCode.���Ȃ�No��I���Ȃ̂�questions[?].Answer��false�Ȃ琳���ƂȂ�
            {
                SE.AUDIO.PlayOneShot(SE.CRIP[3]);//����!!
                Main.Phase = 9;
            }
            else
            {
                SE.AUDIO.PlayOneShot(SE.CRIP[4]);//�s���� 
                Main.Phase = 10;
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
    public Question[] questions = new Question[10];
    [System.Serializable]
    public class Question
    {
        public string questionText;
        public bool Answer;//yes => true, no => false;
    }
}
