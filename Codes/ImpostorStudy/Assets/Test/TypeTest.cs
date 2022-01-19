using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class TypeTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        System.Type Type = System.Type.GetType("RefTest");
        Vector2[][] opaths = new Vector2[0][];
        MethodInfo method = Type.GetMethod("Hello", BindingFlags.Static | BindingFlags.NonPublic);
        method.Invoke(null,null);

        Debug.Log(Vector2.Scale(new Vector2(2, 3), new Vector2(4, 5)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class RefTest {
    private static void Hello() {
        Debug.Log("Hello");
    }
}