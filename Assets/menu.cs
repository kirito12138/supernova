using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject[] levels;
    public GameObject b1, b2, b3;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("title", 1);
        Screen.SetResolution(1600, 900, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {


            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity);
            if (hit.collider.gameObject.name == "开始游戏")
            {
                SceneManager.LoadScene(1);
            }
            else if (hit.collider.gameObject.name == "选择关卡")
            {
                b1.SetActive(false);
                b2.SetActive(false);
                b3.SetActive(false);
                foreach (GameObject l in levels)
                {
                    l.SetActive(true);
                }
            }
            else if (hit.collider.gameObject.name == "退出")
            {
                Application.Quit();
            }
            else if (hit.collider.gameObject.name == "1")
            {
                SceneManager.LoadScene(1);
            }
            else if (hit.collider.gameObject.name == "2")
            {
                SceneManager.LoadScene(2);
            }
            else if (hit.collider.gameObject.name == "3")
            {
                SceneManager.LoadScene(3);
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Application.Quit();
        }
    }
}
