//
// データはエディタの場合はAssets直下、Exe書き出し後はexeと同階層に
// $DATA$という名前のファイルが作られそこの中に保存される。
//

using UnityEngine;

public class test : MonoBehaviour
{
    void Start()
    {
        //音声認識-----------------------------------------
        VoiceRec.INIT(RecvText, new string[] { "はい", "いいえ" });
        //VoiceRec.INIT(RecvText, "はい", "いいえ"); //この書き方でもOK!!

        //設定画面のデータ-----------------------------------------------------------------------------------------
        //数値データが範囲外にいった場合上限を超えたら上限の値にセットされる。下限の場合も然り
        OPTION.Save();//データを保存する。
        OPTION.Load();//データをファイルから読み込む。
        OPTION.bgm = 0.1f; //bgmのデータ(0.0~1.0)
        OPTION.se = 0.1f; //seのデータ(0.0~1.0)
        OPTION.menberLen = 10; //人数(0~120)
        OPTION.time = 40;//時間(分　10~100)
        OPTION.useDevice = true;//デバイスの設定

        //問題データ----------------------------------------------------------------------------------------------
        Question_[] data = DATA_.questionData.data.ToArray(); //問題データの配列の取得
        DATA_.questionData.data.Add(new Question_() { text = "ここに問題文", answer = ANSWER.NO }); //問題の追加
        DATA_.questionData.data.Remove(new Question_() { text = "ここに問題文", answer = ANSWER.NO }); //問題の削除
        DATA_.questionData.data.RemoveAt(10); //問題を配列番号で削除
        DATA_.questionData.Save(); //問題の保存
        DATA_.questionData.Load(); //問題のデータを読み込み

        //???以降は上の問題データと同じ-----------------------
        //DATA_.penaltyData.????? //罰ゲームのデータ
        //DATA_.winner.???? //優勝者のリスト
        
    }

    void RecvText(string a)
    {
        Debug.Log("音声認識で" + a + "を認識しました");
    } 
}


/*
 音声認識は

VoiceRec.INIT(RecvText, new string[]{"はい", "いいえ"});

と書くだけ。

下記コードのように使える。
引数0はvoid型でかつ引数がstringが１つの関数を指定できる。
音声認識で検知したら引数に検出したワードを入れて呼び出される。
また次の引数はstring型の配列だが、これは単語辞書。
英文字は検出が微妙になる場合が多いのでカタカナで書くほうがいい。
"Result" >> "リザルト"
また、独特の発音や方言もあったほうがいい場合もある。("いいえ","いーえ","いえ"など)
かたっぱしから入れて分岐処理で同じ処理をするだけで済む。

また、単語辞書や呼ぶ関数を変えるときはVoiceRec.INITを再度呼べば上書きされる。


public class test : MonoBehaviour
{
    void Start()
    {
        VoiceRec.INIT(RecvText, "はい", "いいえ");
    }

    void RecvText(string a)
    {
        Debug.Log("音声認識で" + a + "を認識しました");
    }
}

 */