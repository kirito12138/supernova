using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ddol : MonoBehaviour
{
    public GameObject CloneTemp;

    public static bool IsHaveUsed = false;

    private GameObject clone;
    // Start is called before the first frame update
    void Start()
    {
        if (!IsHaveUsed)
        {
            clone = Instantiate(CloneTemp, transform.position, transform.rotation) as GameObject;

            IsHaveUsed = true;
            Debug.Log("this log obviously show create");
            DontDestroyOnLoad(clone.transform.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
