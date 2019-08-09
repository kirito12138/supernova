using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightFire : MonoBehaviour
{
    public GameObject target, fire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < 0.415)
        {
            fire.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
