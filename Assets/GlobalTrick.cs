using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalTrick : MonoBehaviour
{
    public GameObject targetBox, targetPiece, targetTrick;
    public bool ifState;
    public int targetState;

    public Vector3 afterPosition1;
    public GameObject bar1;
    public GameObject colliderBar;
    public float targetAngle;
    public Vector3 afterPosition2;
    public GameObject bar2;
    public UnityEvent barTrick;
    private bool trigered, trigering6, trigering3;
    public GameObject depart, destination;
    private float t = 0f;
    // Start is called before the first frame update
    void Start()
    {
        trigered = false;
        trigering6 = false;
        trigering3 = false;
        print("=================111");
        print(bar1.GetComponent<Transform>().position - afterPosition1);
        print(bar2.GetComponent<Transform>().position - afterPosition2);
        print("=================222");
    }

    // Update is called once per frame
    void Update()
    {
        if (targetBox.GetComponent<boxScript>().crtPiece == targetPiece)
        {
            if (!trigered && (!ifState || targetTrick.GetComponent<move>().curState == targetState) && targetPiece.GetComponent<mouseDrag>().ifIdle() == true)
            {
                barTrick.Invoke();
            }
            
        }
        if (trigering6)
        {
            Vector3 v = Vector3.zero;
            v.z = targetAngle * Time.deltaTime / 1f;
            t += Time.deltaTime;
            colliderBar.GetComponent<Transform>().Rotate(v);
            if (t >= 1)
            {
                trigering6 = false;
                colliderBar.GetComponent<Transform>().localEulerAngles = new Vector3(0.0f,0f, targetAngle);
                colliderBar.GetComponent<SpriteRenderer>().enabled = false;
                bar1.GetComponent<SpriteRenderer>().enabled = true;
                bar2.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    public void trick6()
    {
        t = 0f;
        depart.GetComponent<route>().nextPoint = destination;
        trigered = true;
        trigering6 = true;
        colliderBar.GetComponent<SpriteRenderer>().enabled = true;
        bar1.GetComponent<SpriteRenderer>().enabled = false;
        bar2.GetComponent<SpriteRenderer>().enabled = false;
        bar1.transform.position = afterPosition1;
        bar2.transform.position = afterPosition2;
        bar1.GetComponent<Transform>().localEulerAngles = new Vector3(0.0f, 0f, targetAngle);
        bar2.GetComponent<Transform>().localEulerAngles = new Vector3(0.0f, 0f, targetAngle);
    }
    public void trick4()
    {
        t = 0f;
        trigered = true;
        trigering6 = true;
        colliderBar.GetComponent<SpriteRenderer>().enabled = true;
        bar1.GetComponent<SpriteRenderer>().enabled = false;
        bar2.GetComponent<SpriteRenderer>().enabled = false;
        bar1.transform.position = afterPosition1;
        bar2.transform.position = afterPosition2;
        bar1.GetComponent<Transform>().localEulerAngles = new Vector3(0.0f, 0f, targetAngle);
        bar2.GetComponent<Transform>().localEulerAngles = new Vector3(0.0f, 0f, targetAngle);
    }
}
