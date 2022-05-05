using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostCollider : MonoBehaviour
{
    public void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Ouch")
        {
            HealthBarController.HitDetected();
        }
        else if (obj.gameObject.tag == "Point")
        {
            PointSystem.BallFound();
            Destroy(obj.gameObject);
        }
        else if (obj.gameObject.tag == "End")
        {
            GoToVictoryScreen.Victorious();
        }
    }
}
