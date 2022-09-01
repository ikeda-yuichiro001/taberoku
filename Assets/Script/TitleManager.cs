using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) SceneManager.LoadScene("Description");
        if (Input.GetKeyDown(KeyCode.A)) SceneManager.LoadScene("AdminTool");
        if (Input.GetKeyDown(KeyCode.S)) SceneManager.LoadScene("Setting");
    }
}
