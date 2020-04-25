using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reiniciar : MonoBehaviour
{
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Level 2");

        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("Selector");

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("QUIT!");
            Application.Quit();

        }
    }
}