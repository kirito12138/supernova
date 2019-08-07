using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomMove : MonoBehaviour
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
    private Vector3 firstPst;
    private Vector3 offset;
    //private Vector3 dir;
    // Start is called before the first frame update
    private int moveDir;
    private bool ifTrick;
    private bool ifReScale;
    private int curState;
    public GameObject camera;
    void Start()
    {
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

        moveDir = -1;
        ifTrick = false;
        curState = 0;
        ifReScale = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (ifLarge)
        {
            //image.transform.position = Vector3.SmoothDamp(image.transform.position, moveDst, ref z, 0.8f);
            Vector3 dir = moveDst - image.transform.position;
            dir = Vector3.Normalize(dir);
            float speed = distance / moveTime;

            image.transform.Translate(dir * speed * Time.deltaTime);

            if (Mathf.Abs(image.transform.position.x - moveDst.x) <= 0.1)
            {
                image.transform.position = moveDst;
                ifLarge = false;
            }

        }
        if (ifScale)
        {
            float s = image.transform.localScale.x;
            image.transform.localScale = new Vector3(s + Time.deltaTime * scaleSpeed, s + Time.deltaTime * scaleSpeed, s + Time.deltaTime * scaleSpeed);

            //print(s + Time.deltaTime * scaleSpeed);
            if (Mathf.Abs(image.transform.localScale.x - targetScale) <= 0.01)
            {
                image.transform.localScale = new Vector3(targetScale, targetScale, targetScale);
                ifScale = false;
            }
        }*/
        if (ifTrick)
        {
            if (ifLarge)
            {
                //image.transform.position = Vector3.SmoothDamp(image.transform.position, moveDst, ref z, 0.8f);
                Vector3 dir = moveDst - image.transform.position;
                dir = Vector3.Normalize(dir);
                float speed = distance / moveTime;

                image.transform.Translate(dir * speed * Time.deltaTime);

                if (Mathf.Abs(image.transform.position.y - moveDst.y) <= 0.1)
                {
                    image.transform.position = moveDst;
                    ifLarge = false;
                    
                }


            }
            if (ifScale)
            {
                float s = image.transform.localScale.x;
                image.transform.localScale = new Vector3(s + Time.deltaTime * scaleSpeed, s + Time.deltaTime * scaleSpeed, s + Time.deltaTime * scaleSpeed);

                //print(s + Time.deltaTime * scaleSpeed);
                if (Mathf.Abs(image.transform.localScale.x - targetScale) <= 0.01)
                { 
                    image.transform.localScale = new Vector3(targetScale, targetScale, targetScale);
                    ifScale = false;
                    
                    targetScale = scale2;
                    scaleSpeed *= -1;
                }
            }
            ifReScale = !(ifLarge || ifScale);
            if (ifReScale)
            {
                
                float s = image.transform.localScale.x;
                image.transform.localScale = new Vector3(s + Time.deltaTime * scaleSpeed, s + Time.deltaTime * scaleSpeed, s + Time.deltaTime * scaleSpeed);

                //print(s + Time.deltaTime * scaleSpeed);
                if (Mathf.Abs(image.transform.localScale.x - targetScale) <= 0.01)
                {
                    image.transform.localScale = new Vector3(targetScale, targetScale, targetScale);
                    ifReScale = false;
                }
            }
            ifTrick = ifLarge || ifScale || ifReScale;
            if (!ifTrick)
            {
                camera.GetComponentInParent<mouseClick>().enabled = true;
            }
        }
    }

    public void LargeTrick()
    {
        camera.GetComponentInParent<mouseClick>().enabled = false;
        this.GetComponent<SpriteRenderer>().flipX = !this.GetComponent<SpriteRenderer>().flipX;
        moveDir *= -1;
        curState = 0;
        ifTrick = true;

        ifLarge = true;
        ifScale = true;
        if (this.GetComponentInParent<mouseDrag>().crtBox != null)
        {
            if (Vector3.Equals(moveDst, originPst))
            {
                moveDst = image.transform.position;
                originPst = image.transform.position;
            }
            else
            {
                originPst = image.transform.position - offset;
            }
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
            print("-----------------");
            print("到放大后位置");
            print(originPst);
            print(offset);
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