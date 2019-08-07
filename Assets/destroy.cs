using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class destroy : MonoBehaviour
{
    public UnityEvent hit;
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
        if (collision.tag == "Stone")
        {
            hit.Invoke();
        }
    }
}
