using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class GameLogicMainMenu : MonoBehaviour
{
    public GameObject player1;


    public Dictionary<int, PlayerMenu> players = new Dictionary<int, PlayerMenu>();
    int idPlayer = 0;

    void Awake()
    {

        AirConsole.instance.onMessage += OnMessage;
        AirConsole.instance.onReady += OnReady;
        AirConsole.instance.onConnect += OnConnect;

        List<int> connectedDevices = AirConsole.instance.GetControllerDeviceIds();
        if (connectedDevices != null)
        {
            player1.SetActive(true);
            players.Add(connectedDevices[0], player1.GetComponent<PlayerMenu>());
        }
    }

    void OnReady(string code)
    {
        //Since people might be coming to the game from the AirConsole store once the game is live, 
        //I have to check for already connected devices here and cannot rely only on the OnConnect event 
        List<int> connectedDevices = AirConsole.instance.GetControllerDeviceIds();
        foreach (int deviceID in connectedDevices)
        {
            AddNewPlayer(deviceID);
        }
    }

    void OnConnect(int device)
    {
        if (idPlayer < 4)
        {
            AddNewPlayer(device);
        }
    }

    private void AddNewPlayer(int deviceID)
    {

        if (players.ContainsKey(deviceID))
        {
            return;
        }

        idPlayer += 1;
    }

    void OnMessage(int from, JToken data)
    {
        Debug.Log("message: " + data);

        //When I get a message, I check if it's from any of the devices stored in my device Id dictionary
        if (players.ContainsKey(from) && data["action"] != null)
        {
            //I forward the command to the relevant player script, assigned by device ID
            players[from].ButtonInput(data["action"].ToString());
        }
    }

    void OnDestroy()
    {
        if (AirConsole.instance != null)
        {
            AirConsole.instance.onMessage -= OnMessage;
            AirConsole.instance.onReady -= OnReady;
            AirConsole.instance.onConnect -= OnConnect;
        }
    }
}
