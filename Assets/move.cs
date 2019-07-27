using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public GameObject image;
    public float offsetX;
    private int direction;
    private Vector3 moveDst;
    private bool ifMove;
    private Vector3 z;
    // Start is called before the first frame update
    void Start()
    {
        direction = 1;
        ifMove = false;
        z = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (ifMove)
        {
            image.transform.position = Vector3.SmoothDamp(image.transform.position, moveDst, ref z, 0.8f);
            if (Mathf.Abs(image.transform.position.x - moveDst.x)<=0.1)
            {
                image.transform.position = moveDst;
                ifMove = false;
            }
        }
    }

    public void Move()
    {
        this.GetComponent<SpriteRenderer>().flipX = !this.GetComponent<SpriteRenderer>().flipX;
        direction *= -1;
        moveDst = image.transform.position;
        moveDst.x += (direction * offsetX);
        ifMove = true;
    }
}
