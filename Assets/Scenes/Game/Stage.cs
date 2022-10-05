using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    Vector3 tempoPpos, tempoPsca, tempoTpos, tempoTsca;//一次的な情報
    public Vector3[] Linepos;
    public GameObject player;
    GameObject[] players;
    int[] masu, Skip;
    public GameObject stage;
    public GameObject table;
    public GameObject cam;
    public LineRenderer Line;
    public GameObject G;//コピー元
    GameObject[] grid;//コピーしたオブジェクトを入れる箱
    public int A;
    public static int Menber;
    int Num = 0, Len = 0;
    bool gool;

    void Start()
    {
        OPTION.Load();
        Menber = OPTION.menberLen;
        stage.transform.localScale *= Menber;
        cam.transform.position *= Menber;
        //G.transform.localScale *= Menber;
        grid = new GameObject[20 * Menber];
        players = new GameObject[Menber];
        masu = new int[Menber];
        Skip = new int[Menber];
        //tempoTpos = table.transform.position * Menber;
        //tempoTsca = table.transform.localScale * Menber;
        //tempoPpos = player.transform.position * Menber;
        //tempoPsca = player.transform.localScale * Menber;
        GridFormat();
    }
    void GridFormat()
    { 
        var pos = new Vector3[Line.positionCount];
        int cnt = Line.GetPositions(pos);
        for (int len = 0; len < grid.Length; len++)//マスの生成
        {
            A = (cnt / Menber * len + len)/10;
            pos[len] = Line.GetPosition(A);
            grid[len] = Instantiate(G, pos[len] + table.transform.position, Quaternion.identity);//Random.Range(-0.3f, 0.3f)
            //grid[len].transform.SetParent(stage.transform, false);
            print(A);
        }
        for (int len2 = 0; len2 < Menber; len2++)
        {
            players[len2] = Instantiate(player,
                grid[0].transform.position,
                Quaternion.identity);
            masu[len2] = 0;
            Skip[len2] = 0;
        }
        return;
    }
    void Update()
    {
        //print(grid.Length);
        for (Num = 0; Num < Menber;)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                Len = SAIKORO.M;
                for (int l = 0; l < Len; l++)
                {
                    masu[Num]++;
                    players[Num].transform.position = grid[masu[Num]].transform.position;
                    if (masu[Num] > grid.Length) masu[Num]--;
                }
                Num++;
            }
            if (masu[Num] == grid.Length)// && Skip[Num] == 0
            {
                Skip[Num]++;
                Num++;
            }
            if (Skip[Num] == 1) Num++;
            if (Skip[Num] == 0) Num -= Menber;
        }
    }
}
