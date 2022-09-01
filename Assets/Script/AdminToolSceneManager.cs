using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdminToolSceneManager : MonoBehaviour
{
    public void OnClick0() { Debug.Log("a"); }
    public void OnClick1() { Debug.Log("a"); }
    public void OnClick2() { SceneManager.LoadScene("Title"); }
}
