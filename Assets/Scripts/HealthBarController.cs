using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBarController : MonoBehaviour
{
    private static Image HealthBarImage;
    private static int start = 0;

    public static void SetHealthValue(float value){
        HealthBarImage.fillAmount = value;

        if (HealthBarImage.fillAmount <= 0.0f)
        {
            //restart
            //Scene thisScene = SceneManager.GetActiveScene();
            //SceneManager.LoadScene(thisScene.name);

            SceneManager.LoadScene("DeathScreen");
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
        
        v = GetValue();
        v -= 0.1f;
        SetHealthValue(v);
       
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
        SetHealthValue(1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
