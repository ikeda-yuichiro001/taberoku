using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    public InputField Prefab;
    public GameObject panel , DestroyOBJ;
    public int PlayerNumber;
    void Start()
    {
        PlayerNumber = SettingSceneUIManager.n+10;
        InputField[] PlayerName = new InputField[PlayerNumber];
        for (int a = 0; a < PlayerNumber; a++)
        {
            if (a < PlayerNumber / 2)
            {
                PlayerName[a] = Instantiate(Prefab, new Vector3(-130, 160 - (80 * a), 0), Quaternion.identity);
                PlayerName[a].transform.SetParent(this.panel.transform, false);
            }
            else if (a >= PlayerNumber / 2)
            {
                PlayerName[a] = Instantiate(Prefab, new Vector3(240, 160 - (80 * (a - 5)), 0), Quaternion.identity);
                PlayerName[a].transform.SetParent(this.panel.transform, false);
            }
        }
        Destroy(DestroyOBJ);
    }
    void Update()
    {

    }
}
