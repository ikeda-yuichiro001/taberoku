using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMain : MonoBehaviour
{
    public static int Phase;//switch文で動かす部分を決める
    public GameObject Player_obj,Stage_obj,Dice_obj;//スクリプトを入れてるオブジェクト
    public GameObject CAM;//メインカメラ
    float delay;
    void Start()
    {
        OPTION.Load();
        DATA_.userData.Load();
        Phase = 0;
        //NewStage.GridLength = 0;
        VoiceRec.INIT(Recv, new string[]
        { "げーむをしゅうりょう", "なげる", "ふる","はい","まる","いいえ","ばつ"});
    }
    void Recv(string a)
    {
        if (SceneLoader.IsFade) return;
        if (a == "げーむをしゅうりょう")
        {
            //ゴールしてる人がいるならそのままリザルト画面へ
            //いない場合はもっともゴールに近い人を優勝にする
            //そういった処理に私は飛ばしたい
            //BGM.mute = true;
            SE.AUDIO.PlayOneShot(SE.CRIP[5]);
            SceneLoader.Load("Result");
        }
        else if (a == "はい" || a == "まる")
        {
            //Phase = 15;
        }
        else if (a == "いいえ" || a == "ばつ")
        {
            //Phase = 16;
        }
        else if(Phase == 2 && (a == "なげる" || a == "ふる"))//サイコロを投げる処理に飛ばす
        {
            Phase = 4;//Phaseを次に進める
        }
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
                delay += Time.deltaTime;
                if (delay > 1.5f)
                {
                    delay = 0;
                    Phase = 1;//Phaseを次に進める
                }
                break;
            case 1://プレイヤーの場所を確認
                Player_obj.GetComponent<NewPlayer>().PlayerPositionCheak();
                break;
            case 2://ターンの開始にUI表示
                break;
            case 3://プレイヤーが待機状態の時
                Player_obj.GetComponent<NewPlayer>().OnPlayerName();//名前を表示
                Player_obj.GetComponent<NewPlayer>().PlayerCircular();//サークル
                Dice_obj.GetComponent<Dice>().DiceSetting();//サイコロ待機
                break;
            case 4://サイコロを投げる処理
                Player_obj.GetComponent<NewPlayer>().OffPlayerName();//名前を非表示
                Dice_obj.GetComponent<Dice>().DiceRotate();
                delay += Time.deltaTime;
                if (delay > 1.5f)
                {
                    Dice_obj.GetComponent<Dice>().DiceThrow();
                    delay = 0;
                    Main.Phase = 5;//Phaseを次に進める
                }
                break;
            case 5:
                break;
            default:
                print("Oops,I did it!");
                break;
        }
    }
}
