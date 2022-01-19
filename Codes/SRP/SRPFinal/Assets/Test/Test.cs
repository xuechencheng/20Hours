using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int num = 1;
        Debug.LogError(num.ReinterpretAsFloat());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
