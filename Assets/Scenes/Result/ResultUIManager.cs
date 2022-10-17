using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUIManager : MonoBehaviour
{
    public Text Winner;
    public Text PastWinner;
    void Start()
    {
        DATA_.winner.Load();
    }

    // Update is called once per frame
    void Update()
    {
        Winner.text = "aaaaa";
    }
}
