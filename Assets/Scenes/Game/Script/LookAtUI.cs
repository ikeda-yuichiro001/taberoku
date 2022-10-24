using UnityEngine;

public class LookAtUI : MonoBehaviour
{
    RectTransform rect;
    void Start() => rect = GetComponent<RectTransform>();
    void Update() => rect.LookAt(Camera.main.transform.position);
}