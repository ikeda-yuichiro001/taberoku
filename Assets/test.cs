//
// �f�[�^�̓G�f�B�^�̏ꍇ��Assets�����AExe�����o�����exe�Ɠ��K�w��
// $DATA$�Ƃ������O�̃t�@�C�������ꂻ���̒��ɕۑ������B
//

using UnityEngine;

public class test : MonoBehaviour
{
    void Start()
    {
        //�����F��-----------------------------------------
        VoiceRec.INIT(RecvText, new string[] { "�͂�", "������" });
        //VoiceRec.INIT(RecvText, "�͂�", "������"); //���̏������ł�OK!!

        //�ݒ��ʂ̃f�[�^-----------------------------------------------------------------------------------------
        //���l�f�[�^���͈͊O�ɂ������ꍇ����𒴂��������̒l�ɃZ�b�g�����B�����̏ꍇ���R��
        OPTION.Save();//�f�[�^��ۑ�����B
        OPTION.Load();//�f�[�^���t�@�C������ǂݍ��ށB
        OPTION.bgm = 0.1f; //bgm�̃f�[�^(0.0~1.0)
        OPTION.se = 0.1f; //se�̃f�[�^(0.0~1.0)
        OPTION.menberLen = 10; //�l��(0~120)
        OPTION.time = 40;//����(���@10~100)
        OPTION.useDevice = true;//�f�o�C�X�̐ݒ�

        //���f�[�^----------------------------------------------------------------------------------------------
        Question_[] data = DATA_.questionData.data.ToArray(); //���f�[�^�̔z��̎擾
        DATA_.questionData.data.Add(new Question_() { text = "�����ɖ�蕶", answer = ANSWER.NO }); //���̒ǉ�
        DATA_.questionData.data.Remove(new Question_() { text = "�����ɖ�蕶", answer = ANSWER.NO }); //���̍폜
        DATA_.questionData.data.RemoveAt(10); //����z��ԍ��ō폜
        DATA_.questionData.Save(); //���̕ۑ�
        DATA_.questionData.Load(); //���̃f�[�^��ǂݍ���

        //???�ȍ~�͏�̖��f�[�^�Ɠ���-----------------------
        //DATA_.penaltyData.????? //���Q�[���̃f�[�^
        //DATA_.winner.???? //�D���҂̃��X�g
        
    }

    void RecvText(string a)
    {
        Debug.Log("�����F����" + a + "��F�����܂���");
    } 
}


/*
 �����F����

VoiceRec.INIT(RecvText, new string[]{"�͂�", "������"});

�Ə��������B

���L�R�[�h�̂悤�Ɏg����B
����0��void�^�ł�������string���P�̊֐����w��ł���B
�����F���Ō��m����������Ɍ��o�������[�h�����ČĂяo�����B
�܂����̈�����string�^�̔z�񂾂��A����͒P�ꎫ���B
�p�����͌��o�������ɂȂ�ꍇ�������̂ŃJ�^�J�i�ŏ����ق��������B
"Result" >> "���U���g"
�܂��A�Ɠ��̔�����������������ق��������ꍇ������B("������","���[��","����"�Ȃ�)
�������ς��������ĕ��򏈗��œ������������邾���ōςށB

�܂��A�P�ꎫ����ĂԊ֐���ς���Ƃ���VoiceRec.INIT���ēx�ĂׂΏ㏑�������B


public class test : MonoBehaviour
{
    void Start()
    {
        VoiceRec.INIT(RecvText, "�͂�", "������");
    }

    void RecvText(string a)
    {
        Debug.Log("�����F����" + a + "��F�����܂���");
    }
}

 */