using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ReturnButtonController : MonoBehaviour
{
    public string mainMenu;

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
