using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit detected");
        HealthBarController.HitDetected();
    }
}
