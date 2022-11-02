using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer : MonoBehaviour
{
    public static int Num;
    public GameObject[] PlayerOBJ;
    public PlayerDeta[] playerDetas = new PlayerDeta[OPTION.menberLen];
    //public static PlayerDeta[] Serializable_playerDetas = new PlayerDeta[OPTION.menberLen];
    public LineRenderer CircularLine;
    private int CircularPoint;
    private float CircularTime;

    public void CreatePlayer()
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
            playerDetas[C].KOMAOBJ = PlayerOBJ[DATA_.userData.data[C].shape];
            playerDetas[C].PlayerColor = StartManager.PlayerColor[DATA_.userData.data[C].color];
            playerDetas[C].PlayerName = DATA_.userData.data[C].name;
            playerDetas[C].NowGridNum = 0;
            playerDetas[C].Goal = false;
        }
    }

    public void PlayerCircular()
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

    public void PlayerPositionCheak()
    {
        if (Stage.Goal[Num] == true)//ゴールしてたら
        {
            //Main.Phase = ??;//次の人に回す処理に飛ばす
            return;
        }
        else//ゴールしてなかったら
        {
            if (Stage.masu[Num] == Stage.grid.Length - 1)//止まったマスがゴールか判別する
            {
                Stage.Goal[Num] = true;//playerの情報としてゴール判定をtrueにする
                //goal++;
                //DATA_.winner.data.Add(new Winner() { name = (string)Stage.texts[Num].text, time = });
                DATA_.winner.Save();
                Main.Phase = 7;
                print("プレイヤー " + Num + " がゴールしたZOI!");
            }
            else Main.Phase = 13;
        }
    }
}

[System.Serializable]
public class PlayerDeta
{
    public GameObject KOMAOBJ;//駒のオブジェクトを入れる箱
    public Color PlayerColor;//playerの色
    public string PlayerName;//playerの名前
    public int NowGridNum;//今のマス目
    public bool Goal;//ゴールの判定用
}

