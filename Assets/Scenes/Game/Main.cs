using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static int Phase;
    public GameObject[] targetObj;
    void Start()
    {
        Phase = 0;
    }
    
    void Update()
    {
        switch (Phase)
        {
            case 0://ステージ&プレイヤーの生成
                targetObj[0].SendMessage("StageCreate");
                Phase++;
                break;
            case 1://プレイヤーの行動(位置をみる)
                targetObj[0].SendMessage("MoveCam");
                //targetObj[3].SendMessage("DiceDestroy");
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
                break;
            case 3: //サイコロの目の確認
                print("サイコロの目の確認");
                break;
            case 4: //プレイヤーの行動(コマの移動)
                targetObj[1].SendMessage("PlayerMove");
                break;
            case 5://止まったマスの処理
                targetObj[2].SendMessage("GridProcessing");
                //print("Phase 5ダヨーン");
                break;
            case 6://止まったマスの効果の処理
                targetObj[2].SendMessage("MINIGame");
                //print("Phase 6ダヨーン");
                //Phase++;
                break;
            case 7://次の人に回す
                targetObj[1].SendMessage("PlayerPass");
                //print("Phase 7ダヨーン");
                break;
            case 8:
                //ゴールの処理
                print("終了！");
                break;
            default:
                print("Oops,I did it!");
                break;
        }
    }
}
