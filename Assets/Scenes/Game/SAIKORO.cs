using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SAIKORO : MonoBehaviour
{
    public static int M;
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
            M = Random.Range(1, 7);
            if (M == 1) Saikoro.transform.Rotate(-90, 0, 0);
            if (M == 2) Saikoro.transform.Rotate(0, 0, 0);
            if (M == 3) Saikoro.transform.Rotate(90, 0, 0);
            if (M == 4) Saikoro.transform.Rotate(180, 0, 0);
            if (M == 5) Saikoro.transform.Rotate(0, 0, -90);
            if (M == 6) Saikoro.transform.Rotate(0, 0, 90);
            D = false;
        }
    }
}
