using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class title : MonoBehaviour
{
    private GameObject canvas;
    private GameObject camera1;
    private bool away;
    private float t;
    private Vector3 z = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        away = false;
        t = 0;
        canvas = GameObject.Find("Canvas");
        camera1 = GameObject.Find("Main Camera");
        if (PlayerPrefs.GetInt("title") == 1)
        {
            canvas.SetActive(false);
            camera1.GetComponent<mouseClick>().enabled = false;
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("title") == 1)
        {
            if (Input.anyKeyDown)
            {
                t = 0;
                away = true;
                canvas.SetActive(true);
                camera1.GetComponent<mouseClick>().enabled = true;
                PlayerPrefs.SetInt("title", 0);
            }
        }
        if (away == true)
        {
            t += Time.deltaTime;
            
            this.transform.position = Vector3.SmoothDamp(this.transform.position, new Vector3(-100, 0, 0), ref z, 2f);
            if (t>2)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
