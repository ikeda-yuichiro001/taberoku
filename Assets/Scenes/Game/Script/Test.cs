using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public RawImage fade;

    void Start()
    {

        fade.color = Color.black;
    }
    void Update()
    {
        fade.color -= Color.black * 5;
        if (fade.color.a <= 0) Destroy(this);
    }
}
