using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    private static Image HealthBarImage;
    private static int start = 0;

    public static void SetHealthValue(float value){
        HealthBarImage.fillAmount = value;

        if (HealthBarImage.fillAmount <= 0.0f)
        {
            //end game
        }
        else if(HealthBarImage.fillAmount < 0.2f){
            SetBarColor(Color.red);
        }else if(HealthBarImage.fillAmount < 0.4f){
            SetBarColor(Color.yellow);
        }else{
            SetBarColor(Color.green);
        }
    }
    public static void HitDetected()
    {
        float v;
        if (start < 2)
        {
            SetHealthValue(1.0f);
            start++;
        }
        else
        {
            v = GetValue();
            v -= 0.1f;
            SetHealthValue(v);
        }
    }

    public static void SetBarColor(Color healthColor){
        HealthBarImage.color = healthColor;
    }

    public static float GetValue()
    {
        return HealthBarImage.fillAmount;
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
