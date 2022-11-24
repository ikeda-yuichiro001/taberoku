using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{
    public RawImage back1, back2, back3;
    public Text cap1, cap2, cap3;
    public Text text1, text2, text3;
    bool box1, box2, box3;

    public void TextBox1()
    {
        back1.color += Color.clear * Time.deltaTime / 4;
        cap1.color += Color.clear * Time.deltaTime / 4;
        text1.color += Color.clear * Time.deltaTime / 4;
    }
    public void TextBox2_1()
    {
        if(!box2)
        {
            back2.color += Color.clear * Time.deltaTime / 4;
            cap2.color += Color.clear * Time.deltaTime / 4;
            text2.color += Color.clear * Time.deltaTime / 4;
        }
        else
        {
            back2.color -= Color.clear * Time.deltaTime / 4;
            cap2.color -= Color.clear * Time.deltaTime / 4;
            text2.color -= Color.clear * Time.deltaTime / 4;
            if(back2.color.r <= 0)Main.Phase = 7;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            box2 = true;
        }
    }
    public void TextBox2_2()
    {
        if (!box2)
        {
            back2.color += Color.clear * Time.deltaTime / 4;
            cap2.color += Color.clear * Time.deltaTime / 4;
            text2.color += Color.clear * Time.deltaTime / 4;
        }
        else
        {
            back2.color -= Color.clear * Time.deltaTime / 4;
            cap2.color -= Color.clear * Time.deltaTime / 4;
            text2.color -= Color.clear * Time.deltaTime / 4;
            if (back2.color.r <= 0) Main.Phase = 14;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            box2 = true;
        }
    }
    public void TextBox3()
    {
        back3.color += Color.clear * Time.deltaTime / 4;
        cap3.color += Color.clear * Time.deltaTime / 4;
        text3.color += Color.clear * Time.deltaTime / 4;
    }
}
