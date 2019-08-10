using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxBarTrick : MonoBehaviour
{
    public GameObject targetBox, bar, moveBar;
    public int targetBarIndex;
    public bool changeRoad;
    public GameObject depart, newDes;
    private bool running;
    private GameObject crtBar;
    private float targetAngle;
    private float t, ttt;
    // Start is called before the first frame update
    void Start()
    {
        ttt = 0;
        t = 0;
        running = false;
        targetAngle = bar.GetComponent<barVar>().angle;
    }

    // Update is called once per frame
    void Update()
    {
        //ttt += Time.deltaTime;
        if (!running && !bar.GetComponent<barVar>().ifTriggered && targetBox.GetComponent<boxScript>().crtPiece != null)
        {
            

            crtBar = targetBox.GetComponent<boxScript>().crtPiece.GetComponent<pieceBarTrick>().Bars[targetBarIndex];
            /*if (ttt > 2)
            {
                print(crtBar.tag);
                print(crtBar.GetComponent<barVar>().ifTriggered);
                print("===========================================");
                ttt = 0;
            }*/
            if (crtBar.tag != "PuzzlePiece" && crtBar.GetComponent<barVar>().ifTriggered == false)
            {
                TrickBegin();
            }
        }  
        if (running)
        {
            Vector3 v = Vector3.zero;
       
            v.z = targetAngle * Time.deltaTime / 1f;
            t += Time.deltaTime;
            moveBar.GetComponent<Transform>().Rotate(v);
            bar.GetComponent<Transform>().Rotate(v);
            v = Vector3.zero;
      
            v.z = crtBar.GetComponent<barVar>().angle * Time.deltaTime / 1f;
            crtBar.GetComponent<Transform>().Rotate(v);
            if (t >= 1)
            {
                running = false;
                moveBar.SetActive(false);
                bar.GetComponent<SpriteRenderer>().enabled = true;
                crtBar.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }


    private void TrickBegin()
    {
        t = 0;
        if (changeRoad)
        {
            depart.GetComponent<route>().nextPoint = newDes;
        }
     
        moveBar.SetActive(true);
        bar.GetComponent<SpriteRenderer>().enabled = false;
        crtBar.GetComponent<SpriteRenderer>().enabled = false;
        bar.GetComponent<barVar>().Use();
        crtBar.GetComponent<barVar>().Use();
        running = true;
    }

}
