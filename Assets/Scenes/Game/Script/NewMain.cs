using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMain : MonoBehaviour
{
    public static int Phase;//switch���œ��������������߂�
    public GameObject Player_obj,Stage_obj;//�X�N���v�g�����Ă�I�u�W�F�N�g
    public GameObject CAM;//���C���J����
    void Start()
    {
        OPTION.Load();
        DATA_.userData.Load();
        Phase = 0;
        NewStage.GridLength = 0;
    }
    void Recv(string a)
    {
        if (SceneLoader.IsFade) return;
    }
    void Update()
    {
        Player_obj.GetComponent<NewPlayer>().PlayerCircular();
        switch (Phase)
        {
            case 0://�Q�[���̏��߂ɐݒ�𔽉f������
                Stage_obj.GetComponent<NewStage>().ReserveGrid();//�}�X�̐�������
                Stage_obj.GetComponent<NewStage>().CreateStage();//�}�X�ƃ��C���̐���
                Player_obj.GetComponent<NewPlayer>().CreatePlayer();//�v���C���[�̐���
                Phase = 1;//Phase�����ɐi�߂�
                break;
            case 1://�v���C���[�̏ꏊ���m�F
                Player_obj.GetComponent<NewPlayer>().PlayerPositionCheak();
                break;
            case 2://�v���C���[�ҋ@���
                Player_obj.GetComponent<NewPlayer>().OnPlayerName();//���O��\��
                Player_obj.GetComponent<NewPlayer>().PlayerCircular();//�T�[�N��
                break;
        }
    }
}
