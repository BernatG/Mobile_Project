using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NDream.AirConsole;

public class ReadyPlayers : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public ChangeSkinPlayer Player1;
    public ChangeSkinPlayer Player2;
    public ChangeSkinPlayer Player3;
    public ChangeSkinPlayer Player4;

    public LevelLoader levelLoader;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player1.ready && Player2.ready && Player3.ready && Player4.ready && SceneManager.GetActiveScene().buildIndex == 0)
        {
            
            List<int> connectedDevices = AirConsole.instance.GetControllerDeviceIds();
            AirConsole.instance.Message(connectedDevices[0], "mainMenu");

            levelLoader.OnMovieEnded(1);
        }
    }
}
