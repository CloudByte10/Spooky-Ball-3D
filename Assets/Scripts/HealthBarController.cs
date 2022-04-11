using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    private static Image HealthBarImage;

    public static void SetHealthValue(float value){
        HealthBarImage.fillAmount = value;

        if(HealthBarImage.fillAmount < 0.2f){
            SetBarColor(Color.red);
        }else if(HealthBarImage.fillAmount < 0.4f){
            SetBarColor(Color.yellow);
        }else{
            SetBarColor(Color.green);
        }
    }

    public static void SetBarColor(Color healthColor){
        HealthBarImage.color = healthColor;
    }

    // Start is called before the first frame update
    void Start()
    {
        HealthBarImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
