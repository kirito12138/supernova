﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trick : MonoBehaviour
{
    public UnityEvent doTrick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Clicked()
    {
        doTrick.Invoke();
    }
}
