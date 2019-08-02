using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public GameObject image;
    public float offsetX;
    private int direction;
    private Vector3 moveDst;
    public GameObject background;
    private Vector3 bgDst;
    private bool ifMove;
    private Vector3 z;
    private Vector3 z1;
    private bool ifBMove;
    // Start is called before the first frame update
    void Start()
    {
        direction = 1;
        ifMove = false;
        ifBMove = false;
        z = Vector3.zero;
        z1 = Vector3.zero;
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
                background.transform.position = bgDst;
                ifMove = false;
                ifBMove = false;
            }

        }
        if (ifBMove)
        {
            background.transform.position = Vector3.SmoothDamp(background.transform.position, bgDst, ref z1, 0.8f);

        }
    }

    public void Move()
    {
        this.GetComponent<SpriteRenderer>().flipX = !this.GetComponent<SpriteRenderer>().flipX;
        direction *= -1;
        moveDst = image.transform.position;
        moveDst.x += (direction * offsetX);
        bgDst = background.transform.position;
        bgDst.x += (direction * offsetX / 2);
        ifMove = true;
        ifBMove = true;
    }
}
