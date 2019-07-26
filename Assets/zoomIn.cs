using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomIn : MonoBehaviour
{
    public GameObject[] routes;
    public GameObject[] candidateEntrance = new GameObject[8];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ZoomIn()
    {
        print("function zoomin");
        ChangeRoute();
    }

    public void ChangeRoute()
    {
        foreach (GameObject item in routes)
        {
            item.SetActive(!item.activeSelf);
        }
        
        for (int i=0;i< transform.parent.gameObject.GetComponent<mouseDrag>().entrance.Length;i++)
        {
            if (transform.parent.gameObject.GetComponent<mouseDrag>().entrance[i] == null && candidateEntrance[i] == null)
            {
                continue;
            }
            //string s = transform.parent.gameObject.GetComponent<mouseDrag>().entrance[i].name +"   " + candidateEntrance[i].name;
            //print(s);
            GameObject temp = transform.parent.gameObject.GetComponent<mouseDrag>().entrance[i];
            transform.parent.gameObject.GetComponent<mouseDrag>().entrance[i] = candidateEntrance[i];
            candidateEntrance[i] = temp;
            //s = transform.parent.gameObject.GetComponent<mouseDrag>().entrance[i].name + "   " + candidateEntrance[i].name;
            //print(s);
        }

    }
}
