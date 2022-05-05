 using UnityEngine;
 using System.Collections;
 using UnityEngine.SceneManagement;
 
 public class GoToVictoryScreen : MonoBehaviour 
 {
     public static void Victorious()
     {
        SceneManager.LoadScene("VictoryScreen");
     }
 }