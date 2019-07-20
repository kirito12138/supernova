using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseDrag : MonoBehaviour
{
    public bool isMouseDown = false;
    private Vector3 lastMousePosition = Vector3.zero;
    private Vector3 offset;
    private Vector3 mp = Vector3.zero;
    private string hitTag;
    private Transform tf;
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;
            lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity);
            hitTag = hit.collider.tag;
            tf = hit.collider.transform;
            mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //print("down");
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
            hitTag = "";
            tf = null;
            //print("up");
        }

        if (isMouseDown)
        {
            
            if (tf != null && hitTag == "PuzzlePiece")
            {
                MoveCube();

            }
        }
    }

    void MoveCube()
    {
        mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = mp - lastMousePosition;
        offset.z = 0;
        // Debug.Log("offset:" + offset);
        tf.position += offset;
        lastMousePosition = mp;
        //Debug.Log(offset);
    }
}
