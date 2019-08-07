using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flip : MonoBehaviour
{
    private bool ifFlip;
    // Start is called before the first frame update
    public GameObject image;
    private float target;
    private GameObject MC;
    void Start()
    {
        MC = GameObject.Find("Main Camera");
        ifFlip = false;
        target = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (ifFlip)
        {
            //print(Mathf.Abs(image.GetComponent<Transform>().rotation.y));

            Vector3 v = Vector3.zero;
            v.y = 180 * Time.deltaTime / 1.5f;
            image.GetComponent<Transform>().Rotate(v);
            
            if (Mathf.Abs(image.GetComponent<Transform>().rotation.y-target)<0.01)
            {
                ifFlip = false;
                image.GetComponent<Transform>().localEulerAngles = new Vector3(0.0f, 180f*target, 0.0f);
                MC.GetComponent<mouseClick>().enabled = true;
                //image.GetComponent<Transform>().Rotate(0f, 180*target- image.GetComponent<Transform>().rotation.y*180, 0f);
            }
            
            /*else
            {
                Vector3 v = Vector3.zero;
                v.y = 180 * Time.deltaTime / 1.5f;
                image.GetComponent<Transform>().Rotate(v);
                if (Mathf.Abs(image.GetComponent<Transform>().rotation.y) <= 0.01)
                {
                    ifFlip = false;
                    image.GetComponent<Transform>().rotation.Set(0f, 0f, 0f, 0f);
                }
            }*/
            
        }
    }

    public void Flip()
    {
        MC.GetComponent<mouseClick>().enabled = false;
        //this.transform.parent.GetComponent<SpriteRenderer>().flipX = !this.transform.parent.GetComponent<SpriteRenderer>().flipX;
        ifFlip = true;
        if (target == 1)
        {
            target = 0;
        }
        else
        {
            target = 1;
        }
    }
}
