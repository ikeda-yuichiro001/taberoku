using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewStage : MonoBehaviour
{
    public GameObject StartGrid, NormalGrid, QuestionGrid, EndGrid;//マスのコピー元
    public GameObject Stage;//ステージを入れるオブジェクト
    public GridDeta[] GridDetas = new GridDeta[25 + (5 * OPTION.menberLen)];//マスの生成
    public static int GridLength = 0;
    public int[] MiniGame = new int[18 + (3 * OPTION.menberLen)];
    private int R;//問題マスの順番
    private int SetPoint = 0;
    public LineRenderer Pos;
    public LineRenderer StageLine;

    public void ReserveGrid()
    {
        for(int r = 0;r < MiniGame.Length;r++)//問題マスの指定
        {
            do
            {
                R = Random.Range(1, GridDetas.Length - 1);
            } while (GridDetas[R].Question == true);
            GridDetas[R].Question = true;
        }

        GridDetas[0].MASUOBJ = StartGrid;//最初のマス
        for(int g = 1;g < GridDetas.Length - 1;g++)
        {
            if (GridDetas[g].Question == true) GridDetas[g].MASUOBJ = QuestionGrid;//問題のマス
            else GridDetas[g].MASUOBJ = NormalGrid;//普通のマス
        }
        GridDetas[GridDetas.Length - 1].MASUOBJ = EndGrid;//最後のマス
    }

    public void CreateStage()
    {
        for(int c = 0;c < GridDetas.Length - 1; c++)
        {
            GridLength++;
            GridDetas[c].MASUOBJ.transform.position =
                Pos.GetPosition(Pos.positionCount / GridDetas.Length * c)//LineRendererをマスで割った数にマス目を掛けた値のポジションにしている
                ;//+ Vector3.up*0.04f//調整
            GridDetas[c].MASUOBJ.transform.SetParent(Stage.transform, false);//Stageの子階層に入れる
            GridDetas[c].GridPos = GridDetas[c].MASUOBJ.transform.position;//インスペクターで見る用
            SetPoint++;//ステージに生成するLineRendererの順番
            StageLine.positionCount = SetPoint;//ステージに生成するLineRendererの順番
            StageLine.SetPosition(SetPoint - 1, Pos.GetPosition(Pos.positionCount / GridDetas.Length * c));//ステージにラインを生成する
        }
    }
}

[System.Serializable]
public class GridDeta
{
    public GameObject MASUOBJ;//マスのオブジェクトを入れる箱
    public int GridNum;//配置するマス目
    public Vector3 GridPos;//マスの場所
    public bool Question;//問題の有無
}
