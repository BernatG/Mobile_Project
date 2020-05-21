using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using NDream.AirConsole;


public class PlayerMenu : MonoBehaviour
{
    private bool playTablero;
    private bool exit;
    public LevelLoader levelLoader;
    public AudioClip audioPlayButton;
    public AudioSource audioEffectClick;

    public void ButtonInput(string input)
    {

        switch (input)
        {
            case "playTablero":
                audioEffectClick.Play();
                playTablero = true;                
                break;
            case "exit":
                AirConsole.instance.NavigateHome();
                exit = true;
                break;

            case "playTablero-up":
                playTablero = false;
                break;
            case "exit-up":
                exit = false;
                break;
        }
    }

    private void FixedUpdate()
    {
        if(playTablero)
        {
            List<int> connectedDevicesSwiming = AirConsole.instance.GetControllerDeviceIds();
            foreach (int deviceID in connectedDevicesSwiming)
            {
                AirConsole.instance.Message(deviceID, "tableroReady");
            }
            levelLoader.OnMovieEnded(1);
        }

        if(exit)
        {
            Application.Quit();
        }
    }
}
