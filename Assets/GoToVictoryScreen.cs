 using UnityEngine;
 using System.Collections;
 using UnityEngine.SceneManagement;
 
 public class GoToVictoryScreen : MonoBehaviour 
 {
     void OnTriggerEnter(Collider other)
     {
        SceneManager.LoadScene("VictoryScreen");
     }
 }