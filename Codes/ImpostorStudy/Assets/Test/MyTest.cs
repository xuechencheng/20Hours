using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Mathf.Atan2(1,Mathf.Sqrt(3)) * 180 / Mathf.PI);
        Debug.Log(Mathf.Atan( 1/ Mathf.Sqrt(3)) * 180 / Mathf.PI);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
