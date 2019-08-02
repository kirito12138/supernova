using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class forkRoad : MonoBehaviour
{
    public UnityEvent changeRoute;
    public int candidateEntry;
    public GameObject piece;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FindRoad()
    {
        int nextEntry = this.GetComponent<toNextBox>().nextEntrNum;
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("EmptyBox");
        foreach (GameObject item in boxes)
        {
            if (item.GetComponent<boxScript>().crtPiece == null)
            {
                return;
            }
        }
        GameObject nextPiece = piece.GetComponent<mouseDrag>().crtBox.GetComponent<boxScript>().nextBox.GetComponent<boxScript>().crtPiece;
        if (nextPiece.GetComponent<mouseDrag>().entrance[nextEntry] == null)
        {
            //print("换了路了啦");
            //changeRoute.Invoke();
            this.GetComponent<toNextBox>().nextEntrNum = candidateEntry;
        }
    }
}
