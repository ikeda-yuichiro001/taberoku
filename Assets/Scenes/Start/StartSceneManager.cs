using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    public void OnClick0() { SceneManager.LoadScene("Game"); }
    public void OnClick1() { SceneManager.LoadScene("Title"); }
}
