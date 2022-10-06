using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int Num = 0, Len = 0;
    bool gool;
    void Start()
    {

    }
    void Update()
    {
        for (Num = 0; Num < Stage.Menber;)
        {
            if(Stage.players[Num])
            if (Input.GetKeyDown(KeyCode.M))
            {
                Len = SAIKORO.M;
                for (int l = 0; l < Len; l++)
                {
                    Stage.masu[Num]++;
                    Stage.players[Num].transform.position = Stage.grid[Stage.masu[Num]].transform.position;
                    if (Stage.masu[Num] > Stage.grid.Length) Stage.masu[Num]--;
                }
                Num++;
            }
            if (Stage.masu[Num] == Stage.grid.Length)// && Skip[Num] == 0
            {
                Stage.Goal[Num] = true;
                Num++;
            }
            //Stage.Goal[Num] ? Num++:Num--;
            return;
        }
    }
}
