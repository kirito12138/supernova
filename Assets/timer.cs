using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    public static float t, lt = 0;
    public static int reloadCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        /*if (t - lt > 2)
        {
            print(t);
            print(reloadCount);
            lt = t;
        }*/
        if (SceneManager.GetActiveScene().buildIndex != 3)
        {
            Destroy(this.gameObject);
        }

    }
}
