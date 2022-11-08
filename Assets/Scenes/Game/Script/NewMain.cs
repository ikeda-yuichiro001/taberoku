using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMain : MonoBehaviour
{
    public static int Phase;//switch文で動かす部分を決める
    public GameObject Player_obj,Stage_obj;//スクリプトを入れてるオブジェクト
    public GameObject CAM;//メインカメラ
    void Start()
    {
        OPTION.Load();
        DATA_.userData.Load();
        Phase = 0;
        NewStage.GridLength = 0;
    }
    void Recv(string a)
    {
        if (SceneLoader.IsFade) return;
    }
    void Update()
    {
        Player_obj.GetComponent<NewPlayer>().PlayerCircular();
        switch (Phase)
        {
            case 0://ゲームの初めに設定を反映させる
                Stage_obj.GetComponent<NewStage>().ReserveGrid();//マスの生成準備
                Stage_obj.GetComponent<NewStage>().CreateStage();//マスとラインの生成
                Player_obj.GetComponent<NewPlayer>().CreatePlayer();//プレイヤーの生成
                Phase = 1;//Phaseを次に進める
                break;
            case 1://プレイヤーの場所を確認
                Player_obj.GetComponent<NewPlayer>().PlayerPositionCheak();
                break;
            case 2://プレイヤー待機状態
                Player_obj.GetComponent<NewPlayer>().OnPlayerName();//名前を表示
                Player_obj.GetComponent<NewPlayer>().PlayerCircular();//サークル
                break;
        }
    }
}
