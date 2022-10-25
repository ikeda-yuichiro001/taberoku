using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public int Minutes, Seconds;//ゆくゆくはprivateにする
    private float S;
    float delay;
    public static int Phase;
    bool seflag , dSet, Rot;
    float cnt,cnt2;
    public Text Timer;
    public RawImage seikai, huseikai;
    public GameObject[] targetObj;
    void Start()
    {
        OPTION.Load();
        Minutes = OPTION.time;
        Seconds = 0;
        S = 0;
        Phase = 0;
        seikai.color = Color.clear;
        huseikai.color = Color.clear;
    }
    
    void Update()
    {
        S += Time.deltaTime;
        if(S >= 1.0f)
        {
            Seconds--;
            if (Seconds < 0)
            {
                Seconds = 59;
                Minutes--; 
                if(Minutes < 0)
                {
                    Phase = 8;//どっかでゴールしてるかしてないかをみて一位の人を決める
                }
            }
            S = 0;
        }
        Timer.text = "残り時間 " + Minutes.ToString() + "分"　+ Seconds.ToString() + "秒";
        //targetObj[1].GetComponent<Player>().PlayerCircular();
        //print("Phase " + Phase + "ダヨーン");
        switch (Phase)
        {
            case 0://ステージ&プレイヤーの生成
                targetObj[0].GetComponent<Stage>().StageCreate();
                Phase = 1;
                break;
            case 1://プレイヤーの行動(位置をみる)
                targetObj[0].GetComponent<Stage>().MoveCam();//視点移動
                targetObj[1].GetComponent<Player>().PlayerMove0();//駒の位置調整
                if (Player.goal<OPTION.menberLen)
                {
                    targetObj[1].GetComponent<Player>().PlayerPosition();
                    //ゴールしていない人がいたらPhase++;
                }
                else if(Player.goal == OPTION.menberLen)
                {
                    Phase = 8;//全員がゴールしたら
                    print("プレイヤー全員がゴールしたZOI!");
                }
                break;
            case 2://プレイヤーの行動(サイコロを振る)
                if (!dSet)
                {
                    targetObj[3].GetComponent<Dice>().DiceSetting();
                    dSet = true;
                }
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Rot = true;
                }
                if (Rot)
                {
                    targetObj[3].GetComponent<Dice>().DiceRotate();
                    delay += Time.deltaTime;
                    if (delay > 1.5f)
                    {
                        targetObj[3].GetComponent<Dice>().DiceThrow();
                        delay = 0;
                        dSet = false;
                        Rot = false;
                    }
                }
                Stage.evocation.SetActive(true);
                targetObj[4].GetComponent<Evocat>().Texts();
                break;
            case 3:
                Stage.evocation.SetActive(false);//サイコロの目の確認
                //print("サイコロの目の確認");
                break;
            case 4: //プレイヤーの行動(コマの移動)
                targetObj[0].GetComponent<Stage>().MoveCam();//視点移動
                targetObj[1].GetComponent<Player>().PlayerMove0();
                targetObj[1].GetComponent<Player>().PlayerMove1();
                break;
            case 5://止まったマスの処理
                targetObj[2].GetComponent<Grid>().GridProcessing();
                //print("Phase 5ダヨーン");
                break;
            case 6://止まったマスの効果の処理
                targetObj[2].GetComponent<Grid>().Creating();
                //print("Phase 6ダヨーン");
                //Phase++;
                break;
            case 7://次の人に回す
                delay += Time.deltaTime; 
                if(delay > 1.4f)
                {
                    targetObj[1].GetComponent<Player>().PlayerPass();
                    delay = 0;
                }
                //print("Phase 7ダヨーン");
                break;
            case 8://ゴールの処理
                targetObj[5].GetComponent<Fin>().Finish();
                print("終了！");
                break;
            case 9:
                if (!seflag)
                {
                    SE.AUDIO.PlayOneShot(SE.CRIP[3]);//正解!!
                    seflag = true;
                }
                cnt += Time.deltaTime * 10;
                if (Mathf.Sin(cnt) > 0)
                {
                    seikai.color = Color.red;
                }
                else
                {
                    seikai.color = Color.clear;
                }
                if (cnt > 50)
                {
                    cnt = 0;
                    seflag = false;
                    seikai.color = Color.clear;
                    Stage.textboxs.SetActive(false);
                    Phase = 11;
                }
                break;
            case 10:
                if (!seflag)
                {
                    SE.AUDIO.PlayOneShot(SE.CRIP[4]);//不正解  
                    seflag = true;
                }
                cnt += Time.deltaTime * 10;
                if (Mathf.Sin(cnt) > 0)
                {
                    seikai.color = Color.blue;
                }
                else
                {
                    seikai.color = Color.clear;
                }
                if (cnt > 50)
                {
                    cnt = 0;
                    seflag = false;
                    seikai.color = Color.clear;
                    Stage.textboxs.SetActive(false);
                    Phase = 11;
                }
                break;
            case 11://解説ターン
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    targetObj[1].GetComponent<Player>().PlayerPass();
                }
                break;
            default:
                print("Oops,I did it!");
                break;
        }
    }
}
