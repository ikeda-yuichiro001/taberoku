using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fin : MonoBehaviour
{
    public void Finish()
    {
        SE.AUDIO.PlayOneShot(SE.CRIP[5]);//終了っぽいやつを選んどく
                                         //なんか文字が出てくる
                                         //if (Input.GetKeyDown(KeyCode.Return))
        SceneLoader.Load("Result");//ステージ遷移
    }
}
