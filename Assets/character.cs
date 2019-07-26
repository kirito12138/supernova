using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class character : MonoBehaviour
{
    public GameObject crtBox;
    public GameObject crtDes;
    public float speed;
    public float ladderSpeed;
    public int beginEntrance;
    private enum states
    {
        idle,
        run,
        die
    }
    private states state;
    // Start is called before the first frame update
    void Start()
    {
        state = states.idle;
        crtDes = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == states.run)
        {
            if (crtDes == null)
            {
                state = states.idle;
                return;
            }
            Vector3 dir = crtDes.transform.position - this.transform.position;
            dir.z = 0;
            dir = Vector3.Normalize(dir);
            if (crtDes.tag == "Ladder")
            {
                transform.Translate(dir * ladderSpeed * Time.deltaTime, Space.World);
            }
            else
            {
                transform.Translate(dir * speed * Time.deltaTime, Space.World);
            }
            Vector3 crtP = this.transform.position;
            Vector3 crtD = crtDes.transform.position;
            crtP.z = 0;
            crtD.z = 0;
            if (Vector3.Distance(crtP, crtD)<0.01)
            {
                if (crtDes.tag == "Destination")
                {
                    crtDes = getNextBoxEntr();
                }
                else if (crtDes.tag == "End")
                {
                    print("Congratulations!");
                    state = states.idle;
                }
                else if (crtDes.tag == "GlobalTeleport")
                {
                    GetComponent<Renderer>().enabled = false;
                    state = states.idle;
                    Invoke("GTeleport", 1f);
                }
                else
                {
                    crtDes = crtDes.GetComponent<route>().nextPoint;
                }
                
            }
        }
        else if (state == states.die)
        {
            Invoke("RloadScene", 3f);
  
        }
    }

    public void RloadScene()
    {
        string SceneName;
        SceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(SceneName);
        return;
    }


    public void GTeleport()
    {
        crtBox = crtBox.GetComponent<boxScript>().nextBox;
        crtDes = crtBox.GetComponent<boxScript>().crtPiece.GetComponent<mouseDrag>().entrance[crtDes.GetComponent<toNextBox>().nextEntrNum];
        this.transform.position = crtDes.transform.position;
        this.gameObject.GetComponent<Renderer>().enabled = true;
        state = states.run;
        return;
    }

    private GameObject getNextBoxEntr()      //碰到有当前box终点，且仍有下一个盒子时调用
    {
        crtBox = crtBox.GetComponent<boxScript>().nextBox;
        if (crtBox.GetComponent<boxScript>().crtPiece == null)
        {
            return null;
        }
        return crtBox.GetComponent<boxScript>().crtPiece.GetComponent<mouseDrag>().entrance[crtDes.GetComponent<toNextBox>().nextEntrNum];
    }

    public void toRun()
    {
        GameObject[] pieces = GameObject.FindGameObjectsWithTag("PuzzlePiece");
        foreach (GameObject item in pieces)
        {
            if (item.GetComponent<mouseDrag>().crtBox == null)
            {
                return;
            }
        }
        crtDes = crtBox.GetComponent<boxScript>().crtPiece.GetComponent<mouseDrag>().entrance[beginEntrance];
        print(crtDes.name);
        state = states.run;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            state = states.die;
        }
    }
}
