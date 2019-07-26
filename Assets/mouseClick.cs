﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity);
            if (hit.collider == null)
            {
                return;
            }
            if (hit.collider.gameObject.tag == "PuzzlePiece")
            {
                hit.collider.GetComponent<mouseDrag>().toDrag(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
            if (hit.collider.gameObject.tag == "Trick")
            {
                print("click trick!");
                hit.collider.GetComponent<Trick>().Clicked();
            }

        }
    }
}
