using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseDrag : MonoBehaviour
{
    //private bool isMouseDown = false;
    //==========================用于drag=====================================
    private Vector3 lastMousePosition = Vector3.zero;
    private Vector3 offset;
    private Vector3 mp = Vector3.zero;
    //-----------------------------------------------------------------------

    //=====================用于back，move2等=================================
    private Vector3 orgPosition;
    //private bool ifClose = false;
    //private float crtSpeed = 0;
    private float beginTime;
    public float smoothTime = 0.08f;
    public float attachDst = 1.0f;
    private GameObject crtBox = null;
    private Vector3 moveDst;
    private Vector3 crtPosition;
    private Vector3 direction;
    private GameObject[] boxes = new GameObject[6];

    

    enum states
    {
        idle,
        drag,
        move2,
        back,
        inBox,
        reset
    };

    private states state;

    private void Start()
    {
        state = states.idle;
        boxes = GameObject.FindGameObjectsWithTag("EmptyBox");
        crtPosition = this.transform.position;
        orgPosition = this.transform.position;

    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity);

            if (hit!=null && hit.collider.gameObject == this.gameObject)
            {
                toDrag(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }

        }
        if (state == states.drag && Input.GetMouseButtonUp(0))
        {
            bool inBox = false;
            foreach (GameObject item in boxes)
            {
                Vector2 boxPst = new Vector2(item.transform.position.x, item.transform.position.y);
                Vector2 crtPst = new Vector2(this.transform.position.x, this.transform.position.y);
                if (Vector2.Distance(boxPst, crtPst) <= attachDst)
                {
                    toMove2(item, false);
                    inBox = true;
                    break;
                }
            }
            if (inBox == false)
            {
                toBack();
            }
            
        }

        if (state == states.drag)
        {
            MoveCube();
        }
        else if (state == states.back)
        {
            MoveBack();
            Vector2 crtP = new Vector2(this.transform.position.x, this.transform.position.y);
            Vector2 dstP = new Vector2(moveDst.x, moveDst.y);
            if (Vector2.Distance(crtP,dstP)<0.01)
            {
                this.transform.position = moveDst;
                toIdle();
            }
        }
        else if (state == states.move2)
        {
            MoveBack();
            Vector2 crtP = new Vector2(this.transform.position.x, this.transform.position.y);
            Vector2 dstP = new Vector2(moveDst.x, moveDst.y);
            if (Vector2.Distance(crtP, dstP) < 0.01)
            {
                this.transform.position = moveDst;
                toIdle();
            }
        }
        else if (state == states.reset)
        {
            MoveBack();
        }
    }

    private void toIdle()
    {
        print("to state Idle");
        state = states.idle;
    }

    private void toDrag(Vector3 mPst)
    {
        print("to state Drag");
        mp = mPst;
        lastMousePosition = mPst;
        state = states.drag;
        moveDst = crtPosition;
        moveDst.z = 0;
    }

    private void toBack()
    {
        print("to state Back");
        state = states.back;
        moveDst = orgPosition;
        
        if (crtBox != null)
        {
            crtBox.GetComponent<boxScript>().crtPiece = null;
        }
        crtBox = null;
        //var str = string.Format("原始位置：{0},  方向：{1}", crtPosition,direction);
        //print(str);
    }

    private void toReset()      //只负责清楚自身状态并回到等待区，不负责box状态更改。
    {
        print("to state Reset");
        crtBox = null;
        moveDst = orgPosition;
    }

    private void toMove2(GameObject dst,bool ifSwap)    //ifSwap:是否为被动交换位置
    {
        print("to state Move2");
        moveDst = dst.transform.position;
        moveDst.z = 0;
        state = states.move2;
        if (ifSwap==false && dst.GetComponent<boxScript>().crtPiece!=null)
        {
            if (crtBox == null)
            {
                dst.GetComponent<boxScript>().crtPiece.GetComponent<mouseDrag>().move2(null, 0);
            }
            else
            {
                dst.GetComponent<boxScript>().crtPiece.GetComponent<mouseDrag>().move2(crtBox, 1);
            }
            
        }
        crtBox = dst;
        dst.GetComponent<boxScript>().crtPiece = this.gameObject;
    }
    private void MoveCube()
    {
        mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = mp - lastMousePosition;
        offset.z = 0;
        // Debug.Log("offset:" + offset);
        this.transform.position += offset;
        lastMousePosition = mp;
        //Debug.Log(offset);
    }

    private void MoveBack()
    {
        Vector3 z = Vector3.zero;
        this.transform.position = Vector3.SmoothDamp(this.transform.position, moveDst, ref z, smoothTime);
        

    }

    
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        print("碰撞！");
        if (collision.tag == "EmptyBox")
        {
            if (collision.GetComponent<boxScript>().crtPiece == null)
            {
                collision.GetComponent<boxScript>().crtPiece = this.gameObject;
                moveDst = collision.transform.position;
            }
            else
            {

            }
            crtBox = collision.gameObject;

            moveDst = collision.transform.position;
            //collision.GetComponent<boxScript>().crtPiece = this.gameObject;
            //crtBox = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        print("出去了");
        if (collision.tag == "EmptyBox")
        {
            //crtBox = null;
            moveDst = crtPosition;
        }
    }*/

    public bool move2(GameObject dst, int mode)   //mode: 0:回到最下方等待区域   1:移动到dst所在位置
    {

        if (mode == 0)
        {
            if (crtBox!=null)
            {
                crtBox.GetComponent<boxScript>().crtPiece = null;
            }
            toBack();
        }
        else
        {
            toMove2(dst, true);
        }
        return true;

    }
}
