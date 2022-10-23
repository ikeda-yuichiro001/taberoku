using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
    public Vector3[] Linepos;
    public GameObject player;
    public static GameObject[] players;
    //public static int[] num;
    public static int[] masu;
    public static bool[] Goal;
    public GameObject stage, CAM, textboxes, evocations;
    public static GameObject textboxs, evocation, cam;
    public LineRenderer Line;
    public LineRenderer PreLine;
    int ViewLinePoint;
    public GameObject G;//コピー元
    public static GameObject[] grid;//コピーしたオブジェクトを入れる箱
    public int A;
    public static int Menber;
    int GameLen;
    public static int[] MiniGame;
    public GameObject Soy;
    public GameObject[] Soys;
    public RawImage RawImage;
    public Text Text;
    public RawImage[] rawImages;
    public Text[] texts;

    void StageCreate()
    {
        Menber = OPTION.menberLen;
        //stage.transform.localScale *= Menber;
        cam= CAM;
        grid = new GameObject[25 + (5 * Menber)];
        MiniGame = new int[5 * Menber];
        players = new GameObject[Menber];
        //num = new int[Menber];
        masu = new int[Menber];
        Goal = new bool[Menber];
        Soys = new GameObject[Menber];
        rawImages = new RawImage[Menber];
        texts = new Text[Menber];
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
            //print(GameLen);
        }
        for (int len2 = 0; len2 < Menber; len2++)//プレイヤーの生成
        {
            players[len2] = Instantiate(player,
                grid[0].transform.position ,
                Quaternion.identity);
            Soys[len2] = Instantiate(Soy,
                new Vector3(0,0,0),
                Quaternion.identity);
            Soys[len2].transform.SetParent(players[len2].transform, false);
            rawImages[len2] = Instantiate(RawImage,
                new Vector3(0, 1, 0),
                Quaternion.identity);
            rawImages[len2].transform.SetParent(Soys[len2].transform, false);
            texts[len2] = Instantiate(Text,
                new Vector3(0, 1, 0),
                Quaternion.identity);
            texts[len2].transform.SetParent(Soys[len2].transform, false);
            switch (DATA_.userData.data[len2].color)
            {
                case 0:
                    rawImages[len2].color = new Color(1.0f, 0.0f, 0.0f, 0.4f);
                    break;
                case 1:
                    rawImages[len2].color = new Color(0.0f, 1.0f, 0.0f, 0.4f);
                    break;
                case 2:
                    rawImages[len2].color = new Color(0.0f, 0.0f, 1.0f, 0.4f);
                    break;
                case 3:
                    rawImages[len2].color = new Color(1.0f, 1.0f, 0.0f, 0.4f);
                    break;
                case 4:
                    rawImages[len2].color = new Color(1.0f, 0.0f, 1.0f, 0.4f);
                    break;
                case 5:
                    rawImages[len2].color = new Color(0.0f, 1.0f, 1.0f, 0.4f);
                    break;
                case 6:
                    rawImages[len2].color = new Color(1.0f, 1.0f, 1.0f, 0.4f);
                    break;
                case 7:
                    rawImages[len2].color = new Color(1.0f, 0.65f, 0.0f, 0.4f);
                    break;
                case 8:
                    rawImages[len2].color = new Color(0.5f, 0.0f, 0.5f, 0.4f);
                    break;
                case 9:
                    rawImages[len2].color = new Color(0.65f, 0.16f, 0.16f, 0.4f);
                    break;
            }
            texts[len2].text = DATA_.userData.data[len2].name;
            //num[len2] = len2;
            masu[len2] = 0;
            Goal[len2] = false;
        }
        print("ステージとプレイヤーを生成したZOI!");
        //print("Oops,I did it!");
    }
    void MoveCam()
    {
        cam.transform.position =
            players[Player.Num].transform.position + new Vector3(0, 4, -5);// * Menber;
    }
}
