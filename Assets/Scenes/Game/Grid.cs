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
            if (Gameturn == true) Main.Phase++;
        }
        if (Gameturn == false) Main.Phase = 6;
        print("���Q�[���̗L�����m�F����ZOI!");
    }
    void MINIGame()
    {
        print("�{�{�{�[�E�{�E�{�[�{�{");
        Gameturn = false;
        Main.Phase++;
    }
}
