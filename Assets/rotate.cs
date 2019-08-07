using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class rotate : MonoBehaviour
{
    private bool ifFlip;
    // Start is called before the first frame update
    public GameObject image;
    private float target;
    private GameObject MC;
    public GameObject stone;
    public GameObject originImg;
    public GameObject imgWithoutStone;
    public GameObject brokenImg;
    public GameObject chara;
    private bool ifEnter;
    void Start()
    {
        ifEnter = false;
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
            if (target == 1)
            {
                v.z = 180 * Time.deltaTime / 1.5f;
            }
            else
            {
                v.z = -180 * Time.deltaTime / 1.5f;
            }
            
            image.GetComponent<Transform>().Rotate(v);

            if (Mathf.Abs(image.GetComponent<Transform>().rotation.z - target/2) < 0.01)
            {
                ifFlip = false;
                image.GetComponent<Transform>().localEulerAngles = new Vector3(0.0f, 0.0f, 180f * target/2);
                MC.GetComponent<mouseClick>().enabled = true;
                //image.GetComponent<Transform>().Rotate(0f, 180*target- image.GetComponent<Transform>().rotation.y*180, 0f);
            }

        }
        if (!ifEnter)
        {
            if (chara.GetComponent<character>().begin == 1 && chara.GetComponent<character>().crtBox == this.GetComponentInParent<mouseDrag>().crtBox)
            {
                ifEnter = true;
                StoneTrick();
            }
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

    public void StoneTrick()
    {
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("EmptyBox");
        if (target == 0)
        {
            return;
        }
        foreach (GameObject item in boxes)
        {
            if (item.GetComponent<boxScript>().crtPiece == null)
            {
                return;
            }
        }
        originImg.SetActive(false);
        imgWithoutStone.SetActive(true);
        stone.SetActive(true);
    }

    public void ChangeImg()
    {
        imgWithoutStone.SetActive(false);
        brokenImg.SetActive(true);
        
    }
}
