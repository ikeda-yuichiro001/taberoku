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
        switch(Phase)
        {
            case 0://ステージ&プレイヤーの生成
                targetObj[0].SendMessage("StageCreate");
                Phase++;
                break;
            case 1://プレイヤーの行動(位置をみる)
                if (Player.goal<OPTION.menberLen)
                {
                    targetObj[1].SendMessage("PlayerPosition");
                    Phase++;//ゴールしていない人がいたら
                }
                else if(Player.goal == OPTION.menberLen) Phase = 6;//全員がゴールしたら
                break;
            case 2://プレイヤーの行動(サイコロを振る)
                targetObj[1].SendMessage("PlayerRoll");
                break;
            case 3: //プレイヤーの行動(コマの移動)
                targetObj[1].SendMessage("PlayerMove");
                break;
            case 4://止まったマスの処理
                //if()(マスに効果があったら)Phase++; 
                Phase = 6;//else(なかったら)
                print("Phase 4ダヨーン");
                break;
            case 5:
                //止まったマスの効果の処理
                print("Phase 5ダヨーン");
                Phase++;
                break;
            case 6://次の人に回す
                targetObj[1].SendMessage("PlayerPass");
                print("Phase 6ダヨーン");
                break;
            case 7:
                //ゴールの処理
                break;
            default:
                print("Oops,I did it!");
                break;
        }
    }
}
