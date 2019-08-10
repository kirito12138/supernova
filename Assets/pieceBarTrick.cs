using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pieceBarTrick : MonoBehaviour
{
    public GameObject[] Bars;
    public GameObject[] candiBars;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SwitchBars()
    {
        for (int i=0;i<Bars.Length;i++)
        {
            GameObject temp = Bars[i];
            Bars[i] = candiBars[i];
            candiBars[i] = temp;
        }
    }
}
