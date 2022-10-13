using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public Vector3[] Linepos;
    public GameObject player;
    public static GameObject[] players;
    public static int[] masu;
    public static bool[] Goal;
    public GameObject stage, cam, textboxes, evocations;
    public static GameObject textboxs, evocation;
    public LineRenderer Line;
    public LineRenderer PreLine;
    int ViewLinePoint;
    public GameObject G;//コピー元
    public static GameObject[] grid;//コピーしたオブジェクトを入れる箱
    public int A;
    public static int Menber;
    int GameLen;
    public static int[] MiniGame;

    void StageCreate()
    {
        Menber = OPTION.menberLen;
        stage.transform.localScale *= Menber;
        grid = new GameObject[25 + (5 * Menber)];
        MiniGame = new int[5 * Menber];
        players = new GameObject[Menber];
        masu = new int[Menber];
        Goal = new bool[Menber];
        textboxs = textboxes;
        textboxs.SetActive(false);
        evocation = evocations;
        evocation.SetActive(false);
        ViewLinePoint = 0;
        var pos = new Vector3[Line.positionCount];
        int cnt = Line.GetPositions(pos);
        for (int len = 0; len < grid.Length; len++)//マスの生成
        {
            A = (cnt / grid.Length) * len;
            pos[len] = Line.GetPosition(A);
            grid[len] = Instantiate(G, pos[len], Quaternion.identity);//Random.Range(-0.3f, 0.3f)
            grid[len].transform.SetParent(stage.transform, false);
            ViewLinePoint++;
            PreLine.positionCount = ViewLinePoint;
            PreLine.SetPosition(ViewLinePoint - 1, pos[len]);
            //print(A);
        }
        for (int len0 = 0; len0 < 5 * Menber; len0++)//罰ゲームマスの生成
        {
            GameLen = Random.Range(1, grid.Length - 1);
            MiniGame[len0] = GameLen;
            print(GameLen);
        }
        for (int len2 = 0; len2 < Menber; len2++)//プレイヤーの生成
        {
            players[len2] = Instantiate(player,
                grid[0].transform.position ,
                Quaternion.identity);
            masu[len2] = 0;
            Goal[len2] = false;
        }
        print("ステージとプレイヤーを生成したZOI!");
        //print("Oops,I did it!");
    }
    void MoveCam()
    {
        cam.transform.position = 
            players[Player.Num].transform.position + new Vector3(0,4,-5) * Menber;
    }
}
