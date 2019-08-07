using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop : MonoBehaviour
{
    public GameObject concrete;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.tag);
        if (collision.name == "随便找的人物")
        {
            concrete.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
