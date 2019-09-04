using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class largeTrick : MonoBehaviour
{
    public GameObject image;
    private bool ifLarge;
    private Vector3 originPst;
    public Vector3 targetPst;
    private Vector3 z;
    private Vector3 moveDst;
    public float scale1;
    public float scale2;
    private float targetScale;
    public float scaleSpeed;
    private bool ifScale;
    public float moveTime;
    private float distance;
    public GameObject minus;
    private Vector3 firstPst;
    private Vector3 offset;
    private GameObject MC;
    private bool iconState;
    public bool ifChangeIcon;
    
    //public GameObject background;
    //private Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        iconState = true;
        MC = GameObject.Find("Main Camera");
        originPst = image.transform.position;
        firstPst = originPst;
        print(originPst);
        ifLarge = false;
        z = Vector3.zero;
        moveDst = originPst;
        ifScale = false;
        targetScale = scale2;
        distance = Vector3.Distance(originPst, targetPst);
        offset = targetPst - originPst;
        //dir = image.transform.position - moveDst;
        //dir = Vector3.Normalize(dir);
    }

    // Update is called once per frame
    void Update()
    {
        if (ifLarge)
        {
            //image.transform.position = Vector3.SmoothDamp(image.transform.position, moveDst, ref z, 0.8f);
            Vector3 dir = moveDst - image.transform.position;
            dir = Vector3.Normalize(dir);
            float speed = distance / moveTime;

            image.transform.Translate(dir * speed * Time.deltaTime);
            //background.transform.Translate(dir * speed / 4 * Time.deltaTime);
            if (Mathf.Abs(image.transform.position.x - moveDst.x) <= 0.1)
            {
                image.transform.position = moveDst;
                ifLarge = false;
                MC.GetComponent<mouseClick>().enabled = true;
            }

        }
        if (ifScale)
        {
            float s = image.transform.localScale.x;
            //float b = background.transform.localScale.x;
            image.transform.localScale = new Vector3(s + Time.deltaTime * scaleSpeed, s + Time.deltaTime * scaleSpeed, s + Time.deltaTime * scaleSpeed);
            //background.transform.localScale = new Vector3(b + Time.deltaTime * scaleSpeed / 2, b + Time.deltaTime * scaleSpeed / 2, b + Time.deltaTime * scaleSpeed / 2);
            //print(s + Time.deltaTime * scaleSpeed);
            if (Mathf.Abs(image.transform.localScale.x - targetScale) <= 0.01)
            {
                image.transform.localScale = new Vector3(targetScale, targetScale, targetScale);
                ifScale = false;
            }
        }
    }

    public void LargeTrick()
    {
        if (ifChangeIcon)
        {
            print(this.name);
            this.GetComponent<SpriteRenderer>().enabled = !iconState;
            minus.SetActive(iconState);
            iconState = !iconState;
        }
        
        MC.GetComponent<mouseClick>().enabled = false;
        ifLarge = true;
        ifScale = true;
        if (this.GetComponentInParent<mouseDrag>().crtBox!=null)
        {
            if (Vector3.Equals(moveDst, originPst))
            {
                moveDst = this.GetComponentInParent<mouseDrag>().crtBox.transform.position;
            }
            originPst = this.GetComponentInParent<mouseDrag>().crtBox.transform.position;
            print("现在有框");

        }
        else
        {
            if (Vector3.Equals(moveDst, originPst))
            {
                moveDst = firstPst;
            }
            originPst = firstPst;
            print("现在没有框");
        }
        if (Vector3.Equals(moveDst, originPst))
        {
            print("到放大后位置");
            moveDst = originPst + offset;
        }
        else
        {
            print("返回原来位置");
            moveDst = originPst;
        }
        //dir = dir * -1;
        if (targetScale == scale1)
        {
            targetScale = scale2;
        }
        else
        {
            targetScale = scale1;
        }
        scaleSpeed *= -1;
    }


}
