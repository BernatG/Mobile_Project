using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void Nivel1()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Nivel2()
    {
        SceneManager.LoadScene("SampleScene 1");
    }
}
