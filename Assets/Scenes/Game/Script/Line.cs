using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private int positionCount;
    public Camera mainCamera;
    public float X,tim;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        // ラインの座標指定を、このラインオブジェクトのローカル座標系を基準にするよう設定を変更
        // この状態でラインオブジェクトを移動・回転させると、描かれたラインもワールド空間に取り残されることなく、一緒に移動・回転
        lineRenderer.useWorldSpace = false;
        positionCount = 0;
    }

    void Update()
    {
        // このラインオブジェクトを、位置はカメラ前方10m、回転はカメラと同じになるようキープさせる
        transform.position = mainCamera.transform.position + mainCamera.transform.forward * 15;
        transform.rotation = mainCamera.transform.rotation;

        if (Input.GetMouseButton(0))
        {
            tim = Time.deltaTime;
            if(tim < 0.1f)
            {
                // 座標指定の設定をローカル座標系にしたため、与える座標にも手を加える
                Vector3 pos = Input.mousePosition;
                pos.z = 10.0f;

                // マウススクリーン座標をワールド座標に直す
                pos = mainCamera.ScreenToWorldPoint(pos);

                // さらにそれをローカル座標に直す。
                //pos = transform.InverseTransformPoint(pos);

                // 得られたローカル座標をラインレンダラーに追加する
                positionCount++;
                lineRenderer.positionCount = positionCount;
                lineRenderer.SetPosition(positionCount - 1, new Vector3(pos.x * X, 20.26f, pos.z * X));
                tim = 0;
            }
        }
        //リセットする
        if (!(Input.GetMouseButton(0)))
        {
            positionCount = 0;
        }
    }
}
