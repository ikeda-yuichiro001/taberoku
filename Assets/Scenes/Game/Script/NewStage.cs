using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewStage : MonoBehaviour
{
    public GameObject StartGrid, NormalGrid, QuestionGrid, EndGrid;//�}�X�̃R�s�[��
    public GameObject Stage;//�X�e�[�W������I�u�W�F�N�g
    public GridDeta[] GridDetas = new GridDeta[25 + (5 * OPTION.menberLen)];//�}�X�̐���
    public static int GridLength = 0;
    public int[] MiniGame = new int[18 + (3 * OPTION.menberLen)];
    private int R;//���}�X�̏���
    private int SetPoint = 0;
    public LineRenderer Pos;
    public LineRenderer StageLine;

    public void ReserveGrid()
    {
        for(int r = 0;r < MiniGame.Length;r++)//���}�X�̎w��
        {
            do
            {
                R = Random.Range(1, GridDetas.Length - 1);
            } while (GridDetas[R].Question == true);
            GridDetas[R].Question = true;
        }

        GridDetas[0].MASUOBJ = StartGrid;//�ŏ��̃}�X
        for(int g = 1;g < GridDetas.Length - 1;g++)
        {
            if (GridDetas[g].Question == true) GridDetas[g].MASUOBJ = QuestionGrid;//���̃}�X
            else GridDetas[g].MASUOBJ = NormalGrid;//���ʂ̃}�X
        }
        GridDetas[GridDetas.Length - 1].MASUOBJ = EndGrid;//�Ō�̃}�X
    }

    public void CreateStage()
    {
        for(int c = 0;c < GridDetas.Length - 1; c++)
        {
            GridLength++;
            GridDetas[c].MASUOBJ.transform.position =
                Pos.GetPosition(Pos.positionCount / GridDetas.Length * c)//LineRenderer���}�X�Ŋ��������Ƀ}�X�ڂ��|�����l�̃|�W�V�����ɂ��Ă���
                ;//+ Vector3.up*0.04f//����
            GridDetas[c].MASUOBJ.transform.SetParent(Stage.transform, false);//Stage�̎q�K�w�ɓ����
            GridDetas[c].GridPos = GridDetas[c].MASUOBJ.transform.position;//�C���X�y�N�^�[�Ō���p
            SetPoint++;//�X�e�[�W�ɐ�������LineRenderer�̏���
            StageLine.positionCount = SetPoint;//�X�e�[�W�ɐ�������LineRenderer�̏���
            StageLine.SetPosition(SetPoint - 1, Pos.GetPosition(Pos.positionCount / GridDetas.Length * c));//�X�e�[�W�Ƀ��C���𐶐�����
        }
    }
}

[System.Serializable]
public class GridDeta
{
    public GameObject MASUOBJ;//�}�X�̃I�u�W�F�N�g�����锠
    public int GridNum;//�z�u����}�X��
    public Vector3 GridPos;//�}�X�̏ꏊ
    public bool Question;//���̗L��
}
