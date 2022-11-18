using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPlayer : MonoBehaviour
{
    public static int DiceNum;//サイコロの出た目
    public static int Num;//今のプレイヤーの順番
    public static int goal;//ゴールしてる人の数
    public GameObject Camera;//カメラを入れる箱
    public GameObject PreNameTag;//プレイヤーの名前の元を入れる箱
    public RawImage PreNameCol;//プレイヤーの名前(色)の元を入れる箱
    public Text PreNameStr;//プレイヤーの名前(文字)の元を入れる箱
    public GameObject[] PlayerOBJ;//プレイヤーのオブジェクトを入れとく箱
    public PlayerDeta[] playerDetas = new PlayerDeta[OPTION.menberLen];//プレイヤーのデータ
    //public static PlayerDeta[] Serializable_playerDetas = new PlayerDeta[OPTION.menberLen];
    public LineRenderer CircularLine;//プレイヤーの強調
    private int CircularPoint;
    private float CircularTime;
    float MoveTime, set;
    int NumSet;
    bool Cheak, Move;

    public void CreatePlayer()//駒の生成
    {
        for (int C = 0;C < OPTION.menberLen;C++)
        {
            /*
            Serializable_playerDetas[C].KOMAOBJ = playerDetas[C].KOMAOBJ = PlayerOBJ[DATA_.userData.data[C].shape];
            Serializable_playerDetas[C].PlayerColor = playerDetas[C].PlayerColor = StartManager.PlayerColor[DATA_.userData.data[C].color];
            Serializable_playerDetas[C].PlayerName = playerDetas[C].PlayerName = DATA_.userData.data[C].name;
            Serializable_playerDetas[C].NowGridNum = playerDetas[C].NowGridNum = 0;
            Serializable_playerDetas[C].Goal = playerDetas[C].Goal = false;
            */
            playerDetas[C].KOMAOBJ = PlayerOBJ[DATA_.userData.data[C].shape];//駒の指定
            playerDetas[C].KOMAOBJ.transform.position = NewStage.GridPositions[C].GridPos;//駒の生成位置
            playerDetas[C].PlayerPos = NewStage.GridPositions[C].GridPos;//インスペクターで見る用
            playerDetas[C].PlayerColor = StartManager.PlayerColor[DATA_.userData.data[C].color];//色の指定
            playerDetas[C].PlayerName = DATA_.userData.data[C].name;//名前の指定
            playerDetas[C].NowGridNum = 0;//今のマス目
            playerDetas[C].Goal = false;//ゴール判定
            playerDetas[C].NameTag = PreNameTag;//キャンバスの指定
            //生成位置の指定
            //KOMAOBJの子オブジェクト化
            playerDetas[C].NameCol = PreNameCol;//色の指定
            playerDetas[C].NameCol.color = playerDetas[C].PlayerColor;
            //NameTagの子オブジェクト化
            playerDetas[C].NameStr = PreNameStr;//名前の指定
            playerDetas[C].NameStr.text = playerDetas[C].PlayerName;
            //NameTagの子オブジェクト化
            playerDetas[C].NameTag.SetActive(false);//キャンバスの非アクティブ化
        }
        Num = goal = 0;//初期化
    }

    public void PlayerCircular()//駒の強調
    {
        if (CircularTime < 1) CircularTime += 0.01f;
        else CircularTime = 0;
        for (int c = 0;c < 360;c++)
        {
            CircularPoint++;
            CircularLine.positionCount = CircularPoint;
            CircularLine.SetPosition(CircularPoint - 1,
                playerDetas[c].KOMAOBJ.transform.position
                + new Vector3(Mathf.Sin(CircularTime),0,Mathf.Cos(CircularTime)));
        }
    }

    public void PlayerPositionCheak()//駒の場所の確認
    {
        if (playerDetas[Num].Goal == true)//ゴールしてたら
        {
            //NewMain.Phase = ??;//次の人に回す処理に飛ばす
            return;
        }
        else//ゴールしてなかったら
        {
            if (playerDetas[Num].NowGridNum == NewStage.GridLength)//止まったマスがゴールか判別する
            {
                playerDetas[Num].Goal = true;//playerの情報としてゴール判定をtrueにする
                goal++;
                //DATA_.winner.data.Add(new Winner() { name = (string)Stage.texts[Num].text, time = });
                DATA_.winner.Save();
                //Main.Phase = 7;//次の人に回す処理に飛ばす
                print("プレイヤー " + Num + " がゴールしたZOI!");
                if(goal >= OPTION.menberLen)//ゴールした人の数がプレイ人数をこえたら終了Phaseにとばす
                {

                }
            }
            else NewMain.Phase = 2;//Phaseを次に進める
        }
    }
    
    public void OnPlayerName()//Standby()
    {
        playerDetas[Num].NameTag.SetActive(true);
    }
    public void OffPlayerName()
    {
        playerDetas[Num].NameTag.SetActive(false);
    }

    public void MoveCam()//カメラの移動
    {
        Camera.transform.position =
            playerDetas[Num].PlayerPos
            + new Vector3(0, 4, -5);
    }

    public void PlayerMoveAvoid()//駒が被ったときによける処理
    {
        for (int leep = 0; leep < Stage.Menber; leep++)
        {
            //playerDetas[Num].KOMAOBJ.transform.position = NewStage.GridPositions[Num];
            if (Num != leep)
            {
                Cheak = false;
                if (Stage.masu[Num] == Stage.masu[leep])
                {
                    if (Cheak == false)
                    {
                        Vector3 Newpos = Stage.players[Num].transform.position
                                             + new Vector3(Mathf.Sin(leep), 0, Mathf.Cos(leep));// * scl;
                        Stage.players[leep].transform.position = Newpos;//移動的な奴
                        Cheak = true;
                        //print("プレイヤー" + Num + "とプレイヤー" + leep + "を比べてるンゴ");
                    }
                }
            }
        }
    }
    public void PlayerMove()//コマの移動
    {
        //Debug.Log("マス目の合計は" + Stage.grid.Length + "Deth。");
        if (NumSet < DiceNum)
        {
            if (Move == false && playerDetas[Num].NowGridNum < NewStage.GridPositions.Length - 1)
            {
                playerDetas[Num].NowGridNum++;
                Move = true;
            }
            else if (Move == false && (playerDetas[Num].NowGridNum > NewStage.GridPositions.Length - 1 || playerDetas[Num].NowGridNum == NewStage.GridPositions.Length - 1))
            {
                SE.AUDIO.PlayOneShot(SE.CRIP[0]);//ゴールっぽいやつを選んどく
                NumSet++;
            }
            if (Move == true)
            {
                MoveTime += Time.deltaTime;
                if (MoveTime >= 0.01f)
                {
                    set += 0.05f;
                    Stage.players[Num].transform.position =
                        Vector3.Lerp(Stage.grid[Stage.masu[Num] - 1].transform.position,
                        Stage.grid[Stage.masu[Num]].transform.position, set);
                    MoveTime = 0;
                    if (set >= 1)
                    {
                        set = 0;
                        Move = false;//移動の終了
                        NumSet++;
                        SE.AUDIO.PlayOneShot(SE.CRIP[0]);
                        print("プレイヤー " + Num + " がコマを動かしたZOI!");
                    }
                }
            }
        }
        else if (NumSet == DiceNum)
        {
            NumSet = 0;
            print("プレイヤー " + Num + " のマス目は " + playerDetas[Num].NowGridNum + " だZOI!");
            NewMain.Phase = 7;
        }
    }
    public void PlayerPass()
    {
        if (Num < OPTION.menberLen - 1)
        {
            Num++;
            print("プレイヤー " + Num + " に回したZOI!");
            NewMain.Phase = 1;
        }
        else if (Num >= OPTION.menberLen - 1)
        {
            Num = 0;
            print("一巡したZOI");
            NewMain.Phase = 1;
        }
    }
}

[System.Serializable]
public class PlayerDeta
{
    public GameObject KOMAOBJ;//駒のオブジェクトを入れる箱
    public GameObject NameTag;//プレイヤーの名前を入れる箱
    public RawImage NameCol;//プレイヤーの名前(色)を入れる箱
    public Text NameStr;//プレイヤーの名前(文字)を入れる箱
    public Vector3 PlayerPos;//プレイヤーの場所
    public Color PlayerColor;//playerの色
    public string PlayerName;//playerの名前
    public int NowGridNum;//今のマス目
    public bool Goal;//ゴールの判定用
}

