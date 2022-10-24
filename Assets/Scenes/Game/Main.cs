using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    float delay;
    public static int Phase;
    bool seflag;
    float cnt,cnt2;
    public RawImage seikai, huseikai;
    public GameObject[] targetObj;
    void Start()
    {
        Phase = 0;
        seikai.color = Color.clear;
        huseikai.color = Color.clear;
    }
    
    void Update()
    {
        targetObj[1].SendMessage("PlayerCircular");
        //print("Phase " + Phase + "ダヨーン");
        switch (Phase)
        {
            case 0://ステージ&プレイヤーの生成
                targetObj[0].SendMessage("StageCreate");
                Phase = 1;
                break;
            case 1://プレイヤーの行動(位置をみる)
                targetObj[0].SendMessage("MoveCam");//視点移動
                targetObj[1].SendMessage("PlayerMove0");//駒の位置調整
                if (Player.goal<OPTION.menberLen)
                {
                    targetObj[1].SendMessage("PlayerPosition");
                    //ゴールしていない人がいたらPhase++;
                }
                else if(Player.goal == OPTION.menberLen)
                {
                    Phase = 8;//全員がゴールしたら
                    print("プレイヤー全員がゴールしたZOI!");
                }
                break;
            case 2://プレイヤーの行動(サイコロを振る)
                targetObj[3].SendMessage("DiceThrow");
                Stage.evocation.SetActive(true);
                targetObj[4].SendMessage("Texts");
                break;
            case 3:
                Stage.evocation.SetActive(false);//サイコロの目の確認
                //print("サイコロの目の確認");
                break;
            case 4: //プレイヤーの行動(コマの移動)
                targetObj[0].SendMessage("MoveCam");//視点移動
                targetObj[1].SendMessage("PlayerMove0");
                targetObj[1].SendMessage("PlayerMove1");
                break;
            case 5://止まったマスの処理
                targetObj[2].SendMessage("GridProcessing");
                //print("Phase 5ダヨーン");
                break;
            case 6://止まったマスの効果の処理
                targetObj[2].SendMessage("Creating");
                //print("Phase 6ダヨーン");
                //Phase++;
                break;
            case 7://次の人に回す
                delay += Time.deltaTime; 
                if(delay > 1.4f)
                {
                    targetObj[1].SendMessage("PlayerPass");
                    delay = 0;
                }

                //print("Phase 7ダヨーン");
                break;
            case 8://ゴールの処理
                targetObj[5].SendMessage("Finish");
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
                        Phase = 7;
                    }
                    
                
                break;
            case 10:
                if (!seflag)
                {
                    SE.AUDIO.PlayOneShot(SE.CRIP[4]);//不正解  
                    seflag = true;
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
                        Phase = 11;
                    }
                }
                break;
            case 11:
                cnt2 += Time.deltaTime;
                break;
            default:
                print("Oops,I did it!");
                break;
        }
    }
}
