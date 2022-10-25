using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceNumber : MonoBehaviour
{
    public static int number;
    void OnTriggerStay(Collider collider)
    {
        if (Main.Phase == 3)
        {
            if (collider.gameObject.name == "1")
            {
                number = 6;
                Invoke("NumberDisplay", 1.5f);
            }
            else if (collider.gameObject.name == "2")
            {
                number = 5;
                Invoke("NumberDisplay", 1.5f);
            }
            else if (collider.gameObject.name == "3")
            {
                number = 4;
                Invoke("NumberDisplay", 1.5f);
            }
            else if (collider.gameObject.name == "4")
            {
                number = 3;
                Invoke("NumberDisplay", 1.5f);
            }
            else if (collider.gameObject.name == "5")
            {
                number = 2;
                Invoke("NumberDisplay", 1.5f);
            }
            else if (collider.gameObject.name == "6")
            {
                number = 1;
                Invoke("NumberDisplay", 1.5f);
            }
            //print("サイコロの目の確認");
        }
    }
    void NumberDisplay()
    {
        if (number > 0)
        {
            Dice.DiceDelet = false;
            Dice.Wait = true;
            Debug.Log("サイコロの目は..." + number);
            Player.Len = number;
            number = 0;
            Main.Phase = 4;
        }
    }
}
