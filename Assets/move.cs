using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class move : MonoBehaviour
{
    public GameObject image;
    public float offsetX;
    public float offsetY;
    private int direction;
    private Vector3 moveDst;
    public GameObject background;
    private Vector3 bgDst;
    private bool ifMove;
    private Vector3 z;
    private Vector3 z1;
    private bool ifBMove;
    private GameObject MC;
    public int curState;
    public UnityEvent changeBar;
    // Start is called before the first frame update
    void Start()
    {
        MC = GameObject.Find("Main Camera");
        direction = 1;
        ifMove = false;
        ifBMove = false;
        z = Vector3.zero;
        z1 = Vector3.zero;
        curState = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (ifMove)
        {
            image.transform.position = Vector3.SmoothDamp(image.transform.position, moveDst, ref z, 0.8f);

            if (Mathf.Abs(image.transform.position.x - moveDst.x)+ Mathf.Abs(image.transform.position.y - moveDst.y) <= 0.1)
            {
                image.transform.position = moveDst;
                background.transform.position = bgDst;
                ifMove = false;
                ifBMove = false;
                MC.GetComponent<mouseClick>().enabled = true;
                curState *= -1;
                changeBar.Invoke();
            }

        }
        if (ifBMove)
        {
            background.transform.position = Vector3.SmoothDamp(background.transform.position, bgDst, ref z1, 0.8f);

        }
    }

    public void Move()
    {
        MC.GetComponent<mouseClick>().enabled = false;
        this.GetComponent<SpriteRenderer>().flipX = !this.GetComponent<SpriteRenderer>().flipX;
        direction *= -1;
        moveDst = image.transform.position;
        moveDst.x += (direction * offsetX);
        moveDst.y += (direction * offsetY);
        bgDst = background.transform.position;
        bgDst.x += (direction * offsetX / 2);
        bgDst.y += (direction * offsetY / 2);
        ifMove = true;
        ifBMove = true;
    }
}
