using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMain : MonoBehaviour
{
    public static int Phase;//switch���œ��������������߂�
    public GameObject Player_obj,Stage_obj,Dice_obj;//�X�N���v�g�����Ă�I�u�W�F�N�g
    public GameObject CAM;//���C���J����
    float delay;
    void Start()
    {
        OPTION.Load();
        DATA_.userData.Load();
        Phase = 0;
        //NewStage.GridLength = 0;
        VoiceRec.INIT(Recv, new string[]
        { "���[�ނ����イ��傤", "�Ȃ���", "�ӂ�","�͂�","�܂�","������","�΂�"});
    }
    void Recv(string a)
    {
        if (SceneLoader.IsFade) return;
        if (a == "���[�ނ����イ��傤")
        {
            //�S�[�����Ă�l������Ȃ炻�̂܂܃��U���g��ʂ�
            //���Ȃ��ꍇ�͂����Ƃ��S�[���ɋ߂��l��D���ɂ���
            //���������������Ɏ��͔�΂�����
            //BGM.mute = true;
            SE.AUDIO.PlayOneShot(SE.CRIP[5]);
            SceneLoader.Load("Result");
        }
        else if (a == "�͂�" || a == "�܂�")
        {
            //Phase = 15;
        }
        else if (a == "������" || a == "�΂�")
        {
            //Phase = 16;
        }
        else if(Phase == 2 && (a == "�Ȃ���" || a == "�ӂ�"))//�T�C�R���𓊂��鏈���ɔ�΂�
        {
            Phase = 4;//Phase�����ɐi�߂�
        }
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
                delay += Time.deltaTime;
                if (delay > 1.5f)
                {
                    delay = 0;
                    Phase = 1;//Phase�����ɐi�߂�
                }
                break;
            case 1://�v���C���[�̏ꏊ���m�F
                Player_obj.GetComponent<NewPlayer>().PlayerPositionCheak();
                break;
            case 2://�^�[���̊J�n��UI�\��
                break;
            case 3://�v���C���[���ҋ@��Ԃ̎�
                Player_obj.GetComponent<NewPlayer>().OnPlayerName();//���O��\��
                Player_obj.GetComponent<NewPlayer>().PlayerCircular();//�T�[�N��
                Dice_obj.GetComponent<Dice>().DiceSetting();//�T�C�R���ҋ@
                break;
            case 4://�T�C�R���𓊂��鏈��
                Player_obj.GetComponent<NewPlayer>().OffPlayerName();//���O���\��
                Dice_obj.GetComponent<Dice>().DiceRotate();
                delay += Time.deltaTime;
                if (delay > 1.5f)
                {
                    Dice_obj.GetComponent<Dice>().DiceThrow();
                    delay = 0;
                    Main.Phase = 5;//Phase�����ɐi�߂�
                }
                break;
            case 5:
                break;
            default:
                print("Oops,I did it!");
                break;
        }
    }
}
