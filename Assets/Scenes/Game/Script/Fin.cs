using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fin : MonoBehaviour
{
    void Finish()
    {
        SE.AUDIO.PlayOneShot(SE.CRIP[0]);//終了っぽいやつを選んどく
        //なんか文字が出てくる
        //if (Input.GetKeyDown(KeyCode.Return))
            SceneManager.LoadScene("Result");//ステージ遷移
    }
}
