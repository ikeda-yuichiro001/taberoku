using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    bool Gameturn;
    void GridProcessing()
    {
        for (int len = 0; len < 5 * Stage.Menber; len++)//���Q�[���}�X�̃`�F�b�N
        {
            print(Stage.MiniGame[len]);
            if (Stage.masu[Player.Num] == Stage.MiniGame[len])
            {
                Gameturn = true; //�}�X�Ɍ��ʂ���������
                print("�f�f�[���@OUT!");
            }
            else
            {
                Gameturn = false;//�Ȃ�������
                print("�`�b!");
            }
            if (Gameturn == true) Main.Phase = 6;
        }
        if (Gameturn == false) Main.Phase = 7;
        print("���Q�[���̗L�����m�F����ZOI!");
    }
    void MINIGame()
    {
        Stage.textboxs.SetActive(true);
        //Stage.textboxs.transform.position = new Vector3(0, -400, 0);
        /*for(; Stage.textboxs.transform.position.y < 0;)
        {
            Stage.textboxs.transform.position += new Vector3(0, 10, 0);
        }*/
        print("����\������ZOI!");
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Gameturn = false;
            Stage.textboxs.SetActive(false);
            Main.Phase = 7;
        }
    }
}
