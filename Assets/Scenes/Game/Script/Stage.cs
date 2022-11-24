using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
    public Vector3[] Linepos;
    public GameObject[] player = new GameObject[10];
    public static GameObject[] players;
    //public static int[] num;
    public static int[] masu;
    public static bool[] Goal;
    public GameObject stage, CAM, textboxes, textboxes2, textboxes3, evocations,dicenum;
    public static GameObject textboxs, textboxs2, textboxs3, evocation, cam;
    public LineRenderer Line;
    public LineRenderer PreLine;
    int ViewLinePoint;
    public GameObject G;//コピー元
    public GameObject G2;//コピー元2
    public static GameObject[] grid;//コピーしたオブジェクトを入れる箱
    public int A;
    public static int Menber;
    int GameLen;
    public static int[] MiniGame;
    public GameObject Soy;
    public static GameObject[] Soys;
    public RawImage RawImage;
    public Text Text;
    public static RawImage[] rawImages;
    public static Text[] texts;
    public Material red;
    float CT, set;

    public void StageCreate()
    {
        Menber = OPTION.menberLen;
        cam = CAM;
        grid = new GameObject[25 + (5 * Menber)];
        MiniGame = new int[18 + (3 * Menber)];
        players = new GameObject[Menber];
        //num = new int[Menber];
        masu = new int[Menber];
        Goal = new bool[Menber];
        Soys = new GameObject[Menber];
        rawImages = new RawImage[Menber];
        texts = new Text[Menber];
        textboxs = textboxes;
        textboxs.SetActive(false);
        textboxs2 = textboxes2;
        textboxs2.SetActive(false);
        textboxs3 = textboxes3;
        textboxs3.SetActive(false);
        evocation = evocations;
        evocation.SetActive(false);
        dicenum.SetActive(false);
        ViewLinePoint = 0;
        var pos = new Vector3[Line.positionCount];
        int cnt = Line.GetPositions(pos);
        for (int len = 0; len < grid.Length; len++)//マスの生成
        {
            A = (cnt / grid.Length) * len;
            pos[len] = Line.GetPosition(A);
            grid[len] = Instantiate(G, pos[len]+ Vector3.up*0.04f, Quaternion.identity);//Random.Range(-0.3f, 0.3f)
            grid[len].transform.SetParent(stage.transform, false);
            ViewLinePoint++;
            PreLine.positionCount = ViewLinePoint;
            PreLine.SetPosition(ViewLinePoint - 1, pos[len]);
            //print(A);
        }
        for (int len0 = 0; len0 < MiniGame.Length; len0++)//罰ゲームマスの生成
        {
            MiniGame[len0] = GameLen;
            //print(GameLen);
            bool t = true;
            while (t)
            {
                GameLen = Random.Range(1, grid.Length - 1);
                t = false;
                foreach(var i in MiniGame)
                {
                    if(i == GameLen)
                    {
                        t = true;
                        break;
                    }
                }
            } 
        }
        for(int aaa = 0; aaa < MiniGame.Length;aaa++)
        {
            grid[MiniGame[aaa]].GetComponent<MeshRenderer>().material = red;
        }
        for (int len2 = 0; len2 < Menber; len2++)//プレイヤーの生成
        {
            players[len2] = Instantiate(player[DATA_.userData.data[len2].shape]/*[DATA_.userData.data[len2].shape]*/,
                grid[0].transform.position ,
                Quaternion.identity);
            Soys[len2] = Instantiate(Soy,
                new Vector3(0,0,0),
                Quaternion.identity);
            Soys[len2].transform.SetParent(players[len2].transform, false);
            rawImages[len2] = Instantiate(RawImage,
                new Vector3(0, 10, 0),
                Quaternion.identity);
            rawImages[len2].transform.SetParent(Soys[len2].transform, false);
            texts[len2] = Instantiate(Text,
                new Vector3(0, 10, 0),
                Quaternion.identity);
            texts[len2].transform.SetParent(Soys[len2].transform, false);
            rawImages[len2].color = StartManager.PlayerColor[DATA_.userData.data[len2].color];
            texts[len2].text = DATA_.userData.data[len2].name;
            //num[len2] = len2;
            Soys[len2].SetActive(false);
            masu[len2] = 0;
            Goal[len2] = false;
        }
        print("ステージとプレイヤーを生成したZOI!");
        //print("Oops,I did it!");
    }
    public void MoveCam()
    {
        CT += Time.deltaTime;
        if (CT >= 0.01f)
        {
            set += 0.05f;
            cam.transform.position = Vector3.Lerp(new Vector3(0, 36, -15), 
                players[Player.Num].transform.position + new Vector3(0, 4, -5),set);// * Menber;
            CT = 0;
        }
        if(set > 1)
        {
            set = 0;
            Main.Phase = 2;
        }
    }
    public void ChaseCam()
    {

        cam.transform.position = players[Player.Num].transform.position + new Vector3(0, 4, -5);
    }
}
