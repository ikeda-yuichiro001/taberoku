using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewMain : MonoBehaviour
{
    public static int Phase;//switch文で動かす部分を決める
    public GameObject Player_obj, Stage_obj, Dice_obj, Grid_obj;//スクリプトを入れてるオブジェクト
    public GameObject CAM;//メインカメラ
    public RawImage seikai, huseikai;
    float delay, cnt, a;
    bool One, Rot, seflag;
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
            Phase = 9;
        }
        else if (a == "いいえ" || a == "ばつ")
        {
            Phase = 10;
        }
        else if(Phase == 3 && (a == "なげる" || a == "ふる"))//サイコロを投げる処理に飛ばす
        {
            Phase = 4;//Phaseを次に進める
            One = false;
        }
    }
    void Update()
    {
        //Player_obj.GetComponent<NewPlayer>().PlayerCircular();//サークル
        switch (Phase)
        {
            case 0://ゲームの初めに設定を反映させる
                Stage_obj.GetComponent<NewStage>().ReserveStage();//マスとラインの生成
                //Player_obj.GetComponent<NewPlayer>().CreatePlayer();//プレイヤーの生成
                Phase = 1;//Phaseを次に進める
                /*
                if(!One)
                {
                    Player_obj.GetComponent<NewPlayer>().CreatePlayer();//プレイヤーの生成
                    One = true;
                }
                delay += Time.deltaTime;
                if (delay > 1.5f)
                {
                    delay = 0;
                    One = false;
                    Phase = 1;//Phaseを次に進める
                }
                 */
                break;
            case 1://プレイヤーの場所を確認
                Player_obj.GetComponent<NewPlayer>().PlayerPositionCheak();
                break;
            case 2://ターンの開始にUI表示
                break;
            case 3://プレイヤーが待機状態の時
                if (!One)
                {
                    Player_obj.GetComponent<NewPlayer>().OnPlayerName();//名前を表示
                    Dice_obj.GetComponent<Dice>().DiceSetting();//サイコロ待機
                    Player_obj.GetComponent<NewPlayer>().PlayerCircular();
                    One = true;
                }
                break;
            case 4://サイコロを投げる処理
                if (!Rot)
                {
                    Player_obj.GetComponent<NewPlayer>().OffPlayerName();//名前を非表示
                    Dice_obj.GetComponent<Dice>().DiceRotate();
                    Rot = true;
                }
                else delay += Time.deltaTime;
                if (delay > 1.5f)
                {
                    Dice_obj.GetComponent<Dice>().DiceThrow();
                    delay = 0;
                    Rot = false;
                    Main.Phase = 5;//Phaseを次に進める
                }
                break;
            case 5://サイコロの目の確認
                break;
            case 6://プレイヤーの行動(コマの移動)//と残りの進むマスの表示
                Player_obj.GetComponent<NewPlayer>().MoveCam();//視点移動
                Player_obj.GetComponent<NewPlayer>().PlayerMoveAvoid();
                Player_obj.GetComponent<NewPlayer>().PlayerMove();
                break;
            case 7://止まったマスの処理
                Grid_obj.GetComponent<Grid>().GridProcessing();
                break;
            case 8://止まったマスの効果の処理
                Grid_obj.GetComponent<Grid>().Creating();
                break;
            case 9:
                Grid.set = false;
                Grid.se = false;
                Grid.Gameturn = false;
                if (Grid.staticquestions[Grid.rand].Answer == true) //KeyCode.▲ならYESを選択なのでquestions[?].Answerがtrueなら正解となる
                {
                    Phase = 11;
                }
                else
                {
                    Phase = 12;
                }
                break;
            case 10:
                Grid.set = false;
                Grid.se = false;
                Grid.Gameturn = false;
                if (Grid.staticquestions[Grid.rand].Answer == false) //KeyCode.▲ならYESを選択なのでquestions[?].Answerがtrueなら正解となる
                {
                    Phase = 11;
                }
                else
                {
                    Phase = 12;
                }
                break;
            case 11://正解!!
                if (!seflag)
                {
                    SE.AUDIO.PlayOneShot(SE.CRIP[3]);//正解!!
                    seflag = true;
                }
                cnt += Time.deltaTime * 10;
                seikai.color = new Color(1, 1, 1, a + (1 - a) * (1 - ((Mathf.Sin(cnt) + 1) * (Mathf.Sin(cnt) + 1))));
                if (cnt > 35)
                {
                    seikai.color = Color.white;
                }
                if (cnt > 50)
                {
                    cnt = 0;
                    seflag = false;
                    seikai.color = Color.clear;
                    Stage.textboxs.SetActive(false);
                    Phase = 13;
                }
                break;
            case 12://不正解  
                if (!seflag)
                {
                    SE.AUDIO.PlayOneShot(SE.CRIP[4]);
                    seflag = true;
                }
                cnt += Time.deltaTime * 10;
                huseikai.color = new Color(1, 1, 1, a + (1 - a) * (1 - ((Mathf.Sin(cnt) + 1) * (Mathf.Sin(cnt) + 1))));
                if (cnt > 35)
                {
                    huseikai.color = Color.white;
                }
                if (cnt > 50)
                {
                    cnt = 0;
                    seflag = false;
                    huseikai.color = Color.clear;
                    Stage.textboxs.SetActive(false);
                    Phase = 14;
                }
                break;
            case 13://解説ターン
                Stage.textboxs2.SetActive(true);
                //targetObj[2].GetComponent<Grid>().Explanat();
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Stage.textboxs2.SetActive(false);
                    Phase = 16;//targetObj[1].GetComponent<Player>().PlayerPass();
                }
                break;
            case 14://解説&罰ゲームターン(解説ターン)
                Stage.textboxs2.SetActive(true);
                //targetObj[2].GetComponent<Grid>().Explanat();
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Stage.textboxs2.SetActive(false);
                    Phase = 15;
                }
                break;
            case 15://解説&罰ゲームターン(罰ゲームターン)
                Stage.textboxs3.SetActive(true);
                //targetObj[2].GetComponent<Grid>().SinGames();
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Stage.textboxs3.SetActive(false);
                    Phase = 16;//targetObj[1].GetComponent<Player>().PlayerPass();
                }
                break;
            case 16://masuに何もながっだから次の人に回す
                delay += Time.deltaTime;
                if (delay > 1.4f)
                {
                    Player_obj.GetComponent<NewPlayer>().PlayerPass();
                    delay = 0;
                }
                //print("Phase 7ダヨーン");
                break;
            case 17://ゴールの処理
                //targetObj[5].GetComponent<Fin>().Finish();
                print("終了！");
                break;
            default:
                print("Oops,I did it!");
                break;
        }
    }
}
