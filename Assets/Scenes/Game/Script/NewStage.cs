using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewStage : MonoBehaviour
{
    public GameObject StartGrid, NormalGrid, QuestionGrid, EndGrid;//マスのコピー元
    public GameObject Stage;//ステージを入れるオブジェクト
    public GridDeta[] GridDetas = new GridDeta[25 + (5 * OPTION.menberLen)];//マスの生成
    public static GridPositionDeta[] GridPositions = new GridPositionDeta[25 + (5 * OPTION.menberLen)];//マスの生成
    public static int GridLength = 0;
    public int[] MiniGame = new int[18 + (3 * OPTION.menberLen)];
    private int R;//問題マスの順番
    private int SetPoint = 0;
    public LineRenderer Line;
    public LineRenderer StageLine;

    public void ReserveStage()//clear
    {
        for(int r = 0;r < MiniGame.Length;r++)//問題マスの指定
        {
            do
            {
                R = Random.Range(1, GridDetas.Length - 1);
            } while (GridDetas[R].Question == true);
            GridDetas[R].Question = true;//問題の有無のチェック
            MiniGame[r] = R;//問題マスの場所
        }

        var Pos = new Vector3[Line.positionCount];
        ///省略int cnt = Line.GetPositions(Pos);省略///
        for (int set = 0; set < GridDetas.Length; set++)
        {
            Pos[set] = Line.GetPosition(Line.GetPositions(Pos) / GridDetas.Length * set);
        }

        GridDetas[0].MASUOBJ = Instantiate(StartGrid, Pos[0] + Vector3.up * 0.04f, Quaternion.identity);//最初のマス
        for (int g = 1;g < GridDetas.Length - 1;g++)
        {
            if (GridDetas[g].Question == true) GridDetas[g].MASUOBJ = Instantiate(QuestionGrid, Pos[g] + Vector3.up * 0.04f, Quaternion.identity);//問題のマス
            else GridDetas[g].MASUOBJ = Instantiate(NormalGrid, Pos[g] + Vector3.up * 0.04f, Quaternion.identity);//普通のマス
        }
        GridDetas[GridDetas.Length - 1].MASUOBJ = Instantiate(EndGrid, Pos[GridDetas.Length - 1] + Vector3.up * 0.04f, Quaternion.identity);//最後のマス

        for(int c = 0; c < GridDetas.Length; c++)
        {
            GridLength++;
            GridDetas[c].PubGridPos = GridDetas[c].MASUOBJ.transform.position;//インスペクターで見る用
            GridDetas[c].MASUOBJ.transform.SetParent(Stage.transform, false);//Stageの子階層に入れる
            GridDetas[c].GridNum = c;//マス目の数

            ///マス目をつなぐ線
            SetPoint++;//ステージに生成するLineRendererの順番
            StageLine.positionCount = SetPoint;//ステージに生成するLineRendererの順番
            StageLine.SetPosition(SetPoint - 1, Line.GetPosition(Line.positionCount / GridDetas.Length * c));//ステージにラインを生成する
            ///
        }
    }
}

[System.Serializable]
public class GridDeta
{
    public GameObject MASUOBJ;//マスのオブジェクトを入れる箱
    public int GridNum;//配置するマス目
    public bool Question;//問題の有無
    public Vector3 PubGridPos;//マスの場所
}

[System.Serializable]
public class GridPositionDeta
{
    public Vector3 GridPos;//マスの場所
}
