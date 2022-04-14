
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    //the target object (player)
    public Transform targetObject;
    
    //distance between camera and target object
    public Vector3 cameraOffset;
    
    //smoothing factor
    public float smooth = 0.5f;
    
    public bool lookTarget = false;

    void Start () {
        cameraOffset = transform.position - targetObject.transform.position;
    }

    void LateUpdate ()
    {
        //camera follows character
        Vector3 newPosition = targetObject.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, smooth);

        //camera rotation change
        if (lookTarget)
        {
            transform.LookAt(targetObject);
        }
    }
}