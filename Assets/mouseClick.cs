using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mouseClick : MonoBehaviour
{
    public GameObject btn;
    public bool ifClick;
    // Start is called before the first frame update
    void Start()
    {
        ifClick = true;
        Text t = btn.transform.GetComponent<Text>();
        string s = "GO!";
        t.text = s;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.SetInt("title", 0);
            string SceneName;
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                timer.reloadCount += 1;
            }
            SceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(SceneName);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ddol.IsHaveUsed = false;
            timer.reloadCount = 0;
            timer.t = 0;
            print("退出");
            SceneManager.LoadScene(0);
        }
        if (ifClick && Input.GetMouseButtonDown(0))
        {
            

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity);
            if (hit.collider == null)
            {
                return;
            }
            if (hit.collider.gameObject.tag == "PuzzlePiece")
            {
                if (hit.collider.gameObject.GetComponent<mouseDrag>().crtBox == null || hit.collider.gameObject.GetComponent<mouseDrag>().crtBox.GetComponent<boxScript>().ifOccupied == false)
                {
                    hit.collider.GetComponent<mouseDrag>().toDrag(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                }
                
            }
            if (hit.collider.gameObject.tag == "Trick")
            {
                print("click trick!");
                hit.collider.GetComponent<Trick>().Clicked();
            }

        }
    }
}
