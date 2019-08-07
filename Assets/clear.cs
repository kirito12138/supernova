using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clear : MonoBehaviour
{
    public GameObject o1;
    public GameObject o2;
    public float offset;
    public float smoothTime;
    private Vector3 z1;
    private Vector3 z2;
    private int dir;
    private Vector3 moveDes1;
    private Vector3 moveDes2;
    // Start is called before the first frame update
    void Start()
    {
        moveDes1 = o1.transform.position;
        moveDes2 = o2.transform.position;
        dir = 1;
        FindDes();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
                        Debug.Log("编辑状态游戏退出");
            #else
                        Application.Quit();
                        Debug.Log ("游戏退出");
            #endif
        }
        o1.transform.position = Vector3.SmoothDamp(o1.transform.position, moveDes1, ref z1, smoothTime);
        o2.transform.position = Vector3.SmoothDamp(o2.transform.position, moveDes2, ref z2, smoothTime);
        Vector3 v = Vector3.zero;
        v.y = 180 * Time.deltaTime / 2f;
        o1.GetComponent<Transform>().Rotate(v);
        o2.GetComponent<Transform>().Rotate(v);

        if (Mathf.Abs(o1.transform.position.y - moveDes1.y)<=0.1)
        {
            FindDes();
        }

    }


    private void FindDes()
    {

        z1 = Vector3.zero;
        z2 = Vector3.zero;
        dir *= -1;
        moveDes1.y += offset * dir;
        moveDes2.y += offset * dir;
        
        
    }
}
