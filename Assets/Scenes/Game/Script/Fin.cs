using UnityEngine;
using UnityEngine.UI;

public class Fin : MonoBehaviour
{
    bool F,C;
    float count;
    public GameObject Owari;

    public void Finish()
    {
        if(!F)
        {
            SE.AUDIO.PlayOneShot(SE.CRIP[5]);//終了っぽいやつを選んどく
            Owari.SetActive(true);//文字出す
            Owari.transform.localScale = new Vector3(1, 1, 1);
            F = true;
        }
        count += Time.deltaTime;
        if(count < 1.0f)
        {
            Owari.transform.localScale += new Vector3(10,10,10) * Time.deltaTime;
        }
        else if(count < 1.6f)
        {
            Owari.transform.localScale = new Vector3(8.5f, 8.5f, 8.5f);
            if (!C)
            {
                SceneLoader.Load("Result");//ステージ遷移
                C = true;
            }
        }
    }
}
