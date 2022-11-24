using UnityEngine;

public class NewStage : MonoBehaviour
{
    public GameObject StartGrid, NormalGrid, QuestionGrid, EndGrid;//�}�X�̃R�s�[��
    public GameObject Stage;//�X�e�[�W������I�u�W�F�N�g
    public GridDeta[] GridDetas;//�}�X�̐���
    /*static */public Vector3[] GridPositions;//�}�X�̐���
    public static int GridLength = 0;
    public int[] MiniGame;
    private int R;//���}�X�̏���
    private int SetPoint = 0;
    bool CH;
    public LineRenderer Line;
    public LineRenderer StageLine;
    
    public void ReserveStage()//clear
    {
        GridDetas = new GridDeta[25 + (5 * OPTION.menberLen)];//�}�X�̐���
        GridPositions = new Vector3[25 + (5 * OPTION.menberLen)];//�}�X�̐���
        MiniGame = new int[18 + (3 * OPTION.menberLen)];

        for (int r = 0; r < MiniGame.Length; r++)//���}�X�̎w��
        {
            do
            {
                R = Random.Range(1, GridDetas.Length - 1);
            } while (GridDetas[R].Question);
            GridDetas[R].Question = true;//���̗L���̃`�F�b�N
            MiniGame[r] = R;//���}�X�̏ꏊ
        }

        var Pos = new Vector3[Line.positionCount];
        int cnt = Line.GetPositions(Pos);
        for (int set = 0; set < GridDetas.Length; set++)
        {
            int A = cnt / GridDetas.Length * set;
            Pos[set] = Line.GetPosition(A);
        }

        GridDetas[0].MASUOBJ = Instantiate(StartGrid, Pos[0] + Vector3.up * 0.04f, Quaternion.identity);//�ŏ��̃}�X
        for (int g = 1; g < GridDetas.Length - 1; g++)
        {
            if (GridDetas[g].Question == true) GridDetas[g].MASUOBJ = Instantiate(QuestionGrid, Pos[g] + Vector3.up * 0.04f, Quaternion.identity);//���̃}�X
            else GridDetas[g].MASUOBJ = Instantiate(NormalGrid, Pos[g] + Vector3.up * 0.04f, Quaternion.identity);//���ʂ̃}�X
        }
        GridDetas[GridDetas.Length - 1].MASUOBJ = Instantiate(EndGrid, Pos[GridDetas.Length - 1] + Vector3.up * 0.04f, Quaternion.identity);//�Ō�̃}�X

        for (int c = 0; c < GridDetas.Length; c++)
        {
            GridLength++;
            GridDetas[c].PubGridPos = GridDetas[c].MASUOBJ.transform.position;//�C���X�y�N�^�[�Ō���p
            GridDetas[c].MASUOBJ.transform.SetParent(Stage.transform, false);//Stage�̎q�K�w�ɓ����
            GridDetas[c].GridNum = c;//�}�X�ڂ̐�
            //GridPositions[c] = GridDetas[c].PubGridPos;//���X�N���v�g�Ŏg���p

            ///�}�X�ڂ��Ȃ���
            SetPoint++;//�X�e�[�W�ɐ�������LineRenderer�̏���
            StageLine.positionCount = SetPoint;//�X�e�[�W�ɐ�������LineRenderer�̏���
            StageLine.SetPosition(SetPoint - 1, Line.GetPosition(Line.positionCount / GridDetas.Length * c));//�X�e�[�W�Ƀ��C���𐶐�����
                                                                                                             ///
        }
    }
}

[System.Serializable]
public class GridDeta
{
    public GameObject MASUOBJ;//�}�X�̃I�u�W�F�N�g�����锠
    public int GridNum;//�z�u����}�X��
    public bool Question;//���̗L��
    public Vector3 PubGridPos;//�}�X�̏ꏊ
}
