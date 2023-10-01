using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public void Jugar()
    {
        /*
        if(SceneManager.GetActiveScene().name == "MainScene")
        {
            SceneManager.LoadScene("MainScene");
        }
        else
        {
        }
        */
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartMenu()
    {
        SceneManager.LoadScene(0);
    }
}
