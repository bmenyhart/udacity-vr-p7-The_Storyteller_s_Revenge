using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class rotate : MonoBehaviour {

    Camera m_MainCamera;
    private Vector3 n;
    private Quaternion newRotation;

    void Start()
    {
        //This gets the Main Camera from the scene
        m_MainCamera = Camera.main;
    }
        // Update is called once per frame
        void Update () {
        transform.LookAt(transform.position + m_MainCamera.transform.rotation *  Vector3.forward);
    }
}

 

