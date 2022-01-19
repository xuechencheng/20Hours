using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Matrix4x4 lookAtM11 = Matrix4x4.LookAt(new Vector3( 2, 1, 5), new Vector3(8, 5, 1), Vector3.up);


        Vector3 center = new Vector3( 1, 2, 3);
        Vector3 offset = new Vector3( 0, 0, 1);
        //Matrix4x4.LookAt(frameBounds.center - new Vector3(0, 0, m_depthFitSize * 0.5f), frameBounds.center, Vector3.up)

        Matrix4x4 lookAtM = Matrix4x4.LookAt(center - offset, center, Vector3.up);

        //Matrix4x4 lookAtM = Matrix4x4.LookAt(new Vector3( 0, 0, 0), new Vector3( 0, 11, 11), Vector3.up);
        Vector3 ori = new Vector3( 0, -1, 1);
        Debug.Log(lookAtM.MultiplyVector(ori));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
