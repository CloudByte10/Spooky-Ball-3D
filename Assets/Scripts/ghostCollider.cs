using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Ouch")
        {
            HealthBarController.HitDetected();
        }
    }
}
