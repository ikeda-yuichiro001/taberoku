using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NamePlate : MonoBehaviour
{
    public Text []Name;
    public RawImage []Color;
    void Start()
    {
        //ikeda‚³‚ñ‚ªì‚é–¼‘O‚âF‚ğŠi”[‚·‚é“z‚ğƒ[ƒh
        Name = new Text[Stage.Menber];
        Color = new RawImage[Stage.Menber];
        for (int c = 0; c < Stage.Menber; c++)
        {
            Name[c].text = ("Ä“¡");
            Color[c].color = new Color32(1,1,1,1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
