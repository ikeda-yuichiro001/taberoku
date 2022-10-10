using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public GameObject prefab, cam;
    private int rotateX;
    private int rotateY;
    private int rotateZ;

    void DiceThrow()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            rotateX = Random.Range(0, 360);
            rotateY = Random.Range(0, 360);
            rotateZ = Random.Range(0, 360);
            GameObject dice = GameObject.Instantiate(prefab) as GameObject;
            dice.transform.localScale *= Stage.Menber;
            dice.transform.position = cam.transform.position + new Vector3(8, -4, 8);// * Stage.Menber;
            dice.GetComponent<Rigidbody>().AddForce(-transform.right * 300);
            dice.transform.Rotate(rotateX, rotateY, rotateZ);
            print("プレイヤー " + Player.Num + " がサイコロを振ったZOI!");
            Main.Phase++;
        }
    }
}
