using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public GameObject prefab, cam;
    public GameObject dice;
    bool it = false;
    public static bool DiceDelet = false;
    public static bool Wait = true;
    float ddd;
    private int rotateX;
    private int rotateY;
    private int rotateZ;

    public void DiceSetting()
    {
        Destroy(dice);
        Debug.Log("サイコロ消す"); 
        dice = GameObject.Instantiate(prefab) as GameObject;
        dice.transform.position = cam.transform.position + new Vector3(3, -2, 4);
    }
    public void DiceRotate()
    {
        ddd += Time.deltaTime;
        if (ddd > 0.01f)
        {
            dice.transform.Rotate(Random.Range(-50, 50), Random.Range(-50, 50), Random.Range(-50, 50));
            ddd = 0;
        }
    }
    public void DiceThrow()
    {
        Stage.evocation.SetActive(false);
        Wait = false;
        it = false;
        rotateX = Random.Range(0, 360);
        rotateY = Random.Range(0, 360);
        rotateZ = Random.Range(0, 360);
        //dice.transform.localScale *= Stage.Menber;	
        Rigidbody rigidbody = dice.AddComponent<Rigidbody>();
        dice.GetComponent<Rigidbody>().AddForce(-transform.right * 150);
        dice.transform.Rotate(rotateX, rotateY, rotateZ);
        print("プレイヤー " + Player.Num + " がサイコロを振ったZOI!");
        SE.AUDIO.PlayOneShot(SE.CRIP[1]);
        Main.Phase = 3;
    }
}
