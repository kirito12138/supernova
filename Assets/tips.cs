using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tips : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if ((timer.reloadCount > 4 || timer.t > 150) && this.GetComponent<SpriteRenderer>().enabled == false)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("文字提示").GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<SpriteRenderer>().enabled == false && (timer.reloadCount > 4 || timer.t > 150))
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("文字提示").GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
