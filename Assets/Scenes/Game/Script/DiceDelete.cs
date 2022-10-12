using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceDelete : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Destroy(gameObject);
        }
    }
}
