using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SAIKORO : MonoBehaviour
{
    public static int Me;
    float X, Y, Z;
    public static bool D;
    public GameObject Saikoro;
    void Start()
    {
        Saikoro.transform.localScale *= Stage.Menber;
        Saikoro.transform.position *= Stage.Menber;
        X = Y = Z = 0;
        D = true;
    }
    void Update()
    {
        if (D == true)
        {
            X = Random.Range(0, 360) * Time.deltaTime;
            Y = Random.Range(0, 360) * Time.deltaTime;
            Z = Random.Range(0, 360) * Time.deltaTime;
            Saikoro.transform.Rotate(X, Y, Z);
        }
        else
        {

        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            Me = Random.Range(1, 7);
            D = false;
        }
    }
}
