using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Player : MonoBehaviour
{
    public static int Num = 0, goal = 0, Len = 0;
    int l = 0;
    void PlayerPosition()
    {
        if (Stage.Goal[Num] == true)
        {
            Main.Phase = 7;
            return;
        }
        else
        {
            if (Stage.masu[Num] == Stage.grid.Length - 1)//�S�[������
            {
                Stage.Goal[Num] = true;
                goal++;
                Main.Phase = 7;
                print("�v���C���[ " + Num + " ���S�[������ZOI!");
            }
            else Main.Phase = 2;
        }
        print("�v���C���[ " + Num + " �̏ꏊ���m�F����ZOI!");
    }

    async void PlayerMove()
    {
        //Debug.Log("�}�X�ڂ̍��v��" + Stage.grid.Length + "Deth�B");

        if(l < Len)
        {
            if (Stage.masu[Num] < Stage.grid.Length - 1) Stage.masu[Num]++;
            else if (Stage.masu[Num] > Stage.grid.Length - 1) Stage.masu[Num] += 0;
            else if (Stage.masu[Num] == Stage.grid.Length - 1) Stage.masu[Num] += 0;
            Stage.players[Num].transform.position = Stage.grid[Stage.masu[Num]].transform.position;
            print("�v���C���[ " + Num + " ���R�}�𓮂�����ZOI!");
            l++;
            SE.AUDIO.PlayOneShot(SE.CRIP[0]);
            await MoveDelay();
        }
        if (l == Len)
        {
            l = 0;
            print("�v���C���[ " + Num + " �̃}�X�ڂ� " + Stage.masu[Num] + " ��ZOI!");
            Main.Phase = 5;
        }
    }
    async Task MoveDelay()
    {
        await Task.Delay(10000000);
    }

   void PlayerPass()
    {
        if (Num < OPTION.menberLen - 1)
        {
            Num++;
            print("�v���C���[ " + Num + " �ɉ񂵂�ZOI!");
            Main.Phase = 1;
        }
        else if (Num >= OPTION.menberLen -1)
        {
            Num = 0;
            print("�ꏄ����ZOI");
            Main.Phase = 1;
        }
    }
}
