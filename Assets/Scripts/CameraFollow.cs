
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    //the target object (player)
    public Transform targetObject;
    
    //distance between camera and target object
    public Vector3 cameraOffset;
    public float cameraDistance = 10.0f;
    
    //smoothing factor
    public float smooth = 0.5f;
    public Transform Target;
    public float SmoothSpeed = 2f;    
    
    public bool lookTarget = false;

    void Start () {
        //cameraOffset = transform.position - targetObject.transform.position;
    }

    void LateUpdate ()
    {
        //camera follows character
        // Vector3 newPosition = targetObject.transform.position + cameraOffset;
        // transform.position = Vector3.Slerp(transform.position, newPosition, smooth);

        transform.position = targetObject.transform.position - targetObject.transform.forward * cameraDistance;
        transform.LookAt (targetObject);
        //transform.rotation = Quaternion.LookRotation(transform.position - targetObject.position);
        transform.position = new Vector3 (transform.position.x, transform.position.y + 4, transform.position.z);

        //camera rotation change
        if (lookTarget)
        {
            transform.LookAt(targetObject);
        }
    }
}