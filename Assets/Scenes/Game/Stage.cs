using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public Vector3[] Linepos;
    public GameObject player;
    public static GameObject[] players;
    public static int[] masu;
    public static bool[] Goal;
    public GameObject stage, table, cam;
    public LineRenderer Line;
    public GameObject G;//�R�s�[��
    public static GameObject[] grid;//�R�s�[�����I�u�W�F�N�g�����锠
    public int A;
    public static int Menber;

    void StageCreate()
    {
        Menber = OPTION.menberLen;
        stage.transform.localScale *= Menber;
        cam.transform.position *= Menber;
        grid = new GameObject[25 + (5 * Menber)];
        players = new GameObject[Menber];
        masu = new int[Menber];
        Goal = new bool[Menber]; 
        var pos = new Vector3[Line.positionCount];
        int cnt = Line.GetPositions(pos);
        for (int len = 0; len < grid.Length; len++)//�}�X�̐���
        {
            A = (cnt / grid.Length) * len;
            pos[len] = Line.GetPosition(A);
            grid[len] = Instantiate(G, pos[len], Quaternion.identity);//Random.Range(-0.3f, 0.3f)
            grid[len].transform.SetParent(stage.transform, false);
            //print(A);
        }
        for (int len2 = 0; len2 < Menber; len2++)//�v���C���[�̐���
        {
            players[len2] = Instantiate(player,
                grid[0].transform.position + new Vector3(0,2,0) ,
                Quaternion.identity);
            masu[len2] = 0;
            Goal[len2] = false;
        }
        print("�X�e�[�W�ƃv���C���[�𐶐�����ZOI!");
        //print("Oops,I did it!");
    }
}