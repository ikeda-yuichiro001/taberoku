using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SAIKORO : MonoBehaviour
{
    public int M;
    void Start()
    {

    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            M = Random.Range(1, 7);
            print(M);
            //transform.rotation.x += 10;
        }
    }
}
