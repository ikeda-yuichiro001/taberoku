using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    int Phase;
    void Start()
    {
        Phase = 0;
    }
    
    void Update()
    {
        switch(Phase)
        {
            case 0:
                //ステージ&プレイヤーの生成
                Phase++;
                break;
            case 1:
                //プレイヤーの行動(サイコロを振る)
                //ゴールしていない人がいたらPhese++;
                //いなかったらPhese = 5;
                Phase++;
                break;
            case 2:
                //プレイヤーの行動(コマの移動)
                break;
            case 3:
                //止まったマスの処理
                //if()(マスに効果がなかったら)Phese--;
                //else(なかったら)Phese++;
                break;
            case 4:
                //止まったマスの効果の処理
                Phase = 2;
                break;
            case 5:
                //ゴールの処理
                break;
            default:
                print("Oops,I did it!");
                break;
        }
    }
}
